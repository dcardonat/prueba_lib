namespace Libellus.Repositorio.Administracion
{
    using System.Linq;
    using Libellus.Entidades;
    using Libellus.Repositorio.Base;
    using Libellus.Repositorio.Contextos;

    /// <summary>
    /// Define la persistencia con la DB de Libellus para la parametrizacion escolar.
    /// </summary>
    public class RepositorioParametrizacionEscolar : RepositorioBase<ParametrizacionEscolar>, IRepositorioParametrizacionEscolar
    {
        #region Constructor

        /// <summary>
        /// Inicializa una nueva instancia de tipo RepositorioParametrizacionEscolar con el DbContext a trabajar.
        /// </summary>
        /// <param name="contextoLibellus">DbContext a trabajar.</param>
        public RepositorioParametrizacionEscolar(LibellusDbContext contexto)
        {
            this.ContextoLibellus = contexto;
        }

        #endregion Constructor

        /// <summary>
        /// Actualiza un registro de parametrizacion escolar con sus propiedades.
        /// </summary>
        /// <param name="parametrizacion">Entidad con los datos de la parametrizacion.</param>
        public void Actualizar(ParametrizacionEscolar parametrizacion)
        {
            var parametrizacionBD = this.ContextoLibellus.ParametrizacionEscolar.Find(parametrizacion.Id);
            this.ContextoLibellus.Entry(parametrizacionBD).CurrentValues.SetValues(parametrizacion);
            this.ContextoLibellus.Entry(parametrizacionBD).State = System.Data.Entity.EntityState.Modified;

            #region Actualizar los grados de la parametrizacion

            if (parametrizacion.GradosParametrizacionSeleccionados.Any())
            {
                foreach (var grado in parametrizacionBD.GradosParametrizacion.ToList())
                {
                    if (!parametrizacion.GradosParametrizacionSeleccionados.Any(g => g == grado.IdGrado))
                    {
                        this.ContextoLibellus.GradosParametrizacion.Remove(grado);
                    }
                }

                foreach (var gradoNuevo in parametrizacion.GradosParametrizacion)
                {
                    if (!parametrizacionBD.GradosParametrizacion.Any(g => g.IdGrado == gradoNuevo.IdGrado))
                    {
                        parametrizacionBD.GradosParametrizacion.Add(gradoNuevo);
                    }
                }
            }
            else
            {
                var gradosEliminar = this.ContextoLibellus.GradosParametrizacion.Where(x => x.ParametrizacionEscolar.Id == parametrizacion.Id);
                foreach (var grado in gradosEliminar)
                {
                    this.ContextoLibellus.GradosParametrizacion.Remove(grado);
                }
            }

            #endregion Actualizar los grados de la parametrizacion

            #region Actualiza las areas por nivel

            if (parametrizacion.NivelesParametrizacion != null && parametrizacion.NivelesParametrizacion.Any())
            {
                foreach (var nivel in parametrizacion.NivelesParametrizacion)
                {
                    if (nivel.Id == 0)
                    {
                        nivel.ParametrizacionEscolar = parametrizacionBD;
                        this.ContextoLibellus.NivelesParametrizacion.Add(nivel);
                    }
                    else
                    {
                        var nivelBD = parametrizacionBD.NivelesParametrizacion.Single(e => e.Id == nivel.Id);
                        foreach (var area in nivel.AreasNivel)
                        {
                            if (area.Id == 0)
                            {
                                area.NivelParametrizacion = nivelBD;
                                this.ContextoLibellus.AreasNivel.Add(area);
                            }
                        }
                    }
                }

                if (parametrizacionBD.NivelesParametrizacion != null)
                {
                    foreach (var nivelEliminar in parametrizacionBD.NivelesParametrizacion.ToList())
                    {
                        var nivel = parametrizacion.NivelesParametrizacion.FirstOrDefault(e => e.Id == nivelEliminar.Id);
                        if (nivel != null)
                        {
                            foreach (var areaEliminar in nivelEliminar.AreasNivel.Where(n => !nivel.AreasNivel.Any(x => x.Id == n.Id)).ToList())
                            {
                                this.ContextoLibellus.AreasNivel.Remove(areaEliminar);
                            }
                        }
                        else
                        {
                            foreach (var area in nivelEliminar.AreasNivel.ToList())
                            {
                                this.ContextoLibellus.AreasNivel.Remove(area);
                            }

                            this.ContextoLibellus.NivelesParametrizacion.Remove(nivelEliminar);
                        }
                    }
                }
            }
            else
            {
                var nivelesEliminar = this.ContextoLibellus.NivelesParametrizacion.Where(n => n.ParametrizacionEscolar.Id == parametrizacion.Id);
                foreach (var nivel in nivelesEliminar)
                {
                    foreach (var area in nivel.AreasNivel.ToList())
                    {
                        this.ContextoLibellus.AreasNivel.Remove(area);
                    }

                    this.ContextoLibellus.NivelesParametrizacion.Remove(nivel);
                }
            }

            #endregion Actualiza las areas por nivel

            #region Actualiza los periodos de la parametrización

            if (parametrizacion.PeriodosParametrizacion != null && parametrizacion.PeriodosParametrizacion.Any())
            {
                foreach (var periodo in parametrizacion.PeriodosParametrizacion)
                {
                    if (periodo.Id == 0)
                    {
                        periodo.ParametrizacionEscolar = parametrizacionBD;
                        this.ContextoLibellus.PeriodosParametrizacion.Add(periodo);
                    }
                    else
                    {
                        //if (!this.ContextoLibellus.Set<GradoParametrizacion>().Local.Any(e => e.Id == periodo.Id))
                        //{
                        this.ContextoLibellus.PeriodosParametrizacion.Attach(periodo);
                        //}

                        //var gradoDB = this.ContextoLibellus.GradosParametrizacion.Single(x => x.Id == periodo.Id);
                        //this.ContextoLibellus.Entry(gradoDB).CurrentValues.SetValues(periodo);
                        this.ContextoLibellus.Entry(periodo).State = System.Data.Entity.EntityState.Modified;
                    }
                }

                if (parametrizacionBD.PeriodosParametrizacion != null)
                {
                    foreach (var periodoEliminar in parametrizacionBD.PeriodosParametrizacion.Where(x => !parametrizacion.PeriodosParametrizacion.Any(u => u.Id == x.Id)).ToList())
                    {
                        this.ContextoLibellus.PeriodosParametrizacion.Remove(periodoEliminar);
                    }
                }
            }
            else
            {
                parametrizacionBD.PeriodosParametrizacion = null;
                var periodosEliminar = this.ContextoLibellus.PeriodosParametrizacion.Where(x => x.ParametrizacionEscolar.Id == parametrizacion.Id);
                foreach (var periodo in periodosEliminar)
                {
                    this.ContextoLibellus.PeriodosParametrizacion.Remove(periodo);
                }
            }

            #endregion Actualiza los periodos de la parametrización
        }

        /// <summary>
        /// Elimina un registro de parametrizacion escolar.
        /// </summary>
        /// <param name="id">Identificador del registro.</param>
        public void Eliminar(int id)
        {
            ParametrizacionEscolar parametrizacion = this.GetById(id);
            if (parametrizacion != null)
            {
                foreach (var periodo in parametrizacion.PeriodosParametrizacion.ToList())
                {
                    this.ContextoLibellus.PeriodosParametrizacion.Remove(periodo);
                }

                foreach (var grado in parametrizacion.GradosParametrizacion.ToList())
                {
                    this.ContextoLibellus.GradosParametrizacion.Remove(grado);
                }

                foreach (var nivel in parametrizacion.NivelesParametrizacion.ToList())
                {
                    foreach (var area in nivel.AreasNivel.ToList())
                    {
                        this.ContextoLibellus.AreasNivel.Remove(area);
                    }

                    this.ContextoLibellus.NivelesParametrizacion.Remove(nivel);
                }

                this.ContextoLibellus.Entry(parametrizacion).State = System.Data.Entity.EntityState.Deleted;
            }
        }

        /// <summary>
        /// Elimina el grado de la parametrizacion escolar.
        /// </summary>
        /// <param name="grado">Grado que se va a eliminar.</param>
        public void EliminarGrado(GradoParametrizacion grado)
        {
            this.ContextoLibellus.Entry(grado).State = System.Data.Entity.EntityState.Deleted;
        }
    }
}