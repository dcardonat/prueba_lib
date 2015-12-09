namespace Libellus.Negocio.Matriculas
{
    using Libellus.Entidades;
    using Libellus.Entidades.Constantes;
    using Libellus.Entidades.Enumerados;
    using Libellus.Negocio.UnidadesDeTrabajo;
    using Libellus.Utilidades;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    /// <summary>
    /// Define las reglas de negocio para la generacion de cupos.
    /// </summary>
    public class NegocioCupos : NegocioBase, INegocioCupos
    {
        /// <summary>
        /// Inicualiza una nueva instancia de la clase.
        /// </summary>
        /// <param name="unidadDeTrabajoLibellus">Unidad de trabajo con la que se trabaja.</param>
        public NegocioCupos(IUnidadDeTrabajoLibellus unidadDeTrabajoLibellus)
        {
            this.UnidadDeTrabajoLibellus = unidadDeTrabajoLibellus;
        }

        /// <summary>
        /// Genera un nuevo cupo para un estudiante.
        /// </summary>
        /// <param name="cupo">Entidad con la informacion del cupo.</param>
        /// <returns>Retorna mensaje indicando el resultado de la operación.</returns>
        public int GenerarCupo(Cupo cupo)
        {
            Maestro tipoEstudiante;
            Maestro estadoEstudiante = this.UnidadDeTrabajoLibellus.RepositorioMaestros.ConsultarMaestrosPorConsecutivo(ConsecutivoMaestros.EstadoEstudianteActivo.GetHashCode(), Utilidades.ContextoLibellus.ObtenerSedeActual);
            Maestro estadoMatricula = this.UnidadDeTrabajoLibellus.RepositorioMaestros.ConsultarMaestrosPorConsecutivo(ConsecutivoMaestros.EstadoMatriculaEstudiantePreInscrito.GetHashCode(), Utilidades.ContextoLibellus.ObtenerSedeActual);
            cupo.Estudiante.IdEstado = estadoEstudiante.Id;
            Maestro maestro = this.UnidadDeTrabajoLibellus.RepositorioMaestros.ConsultarMaestrosPorConsecutivo((int)ConsecutivoMaestros.EstadoMatriculaEstudiantePreInscrito, Utilidades.ContextoLibellus.ObtenerSedeActual);
            cupo.Matriculas.Add(new Matricula { IdEstado = maestro.Id });

            if (cupo.IdEstudiante > 0)
            {
                tipoEstudiante = this.UnidadDeTrabajoLibellus.RepositorioMaestros.ConsultarMaestrosPorConsecutivo(ConsecutivoMaestros.EstudianteAntiguo.GetHashCode(), Utilidades.ContextoLibellus.ObtenerSedeActual);
                cupo.IdTipoEstudiante = tipoEstudiante.Id;

                EstudianteDatosPersonales estudiante = cupo.Estudiante;
                cupo.Estudiante = null;

                this.UnidadDeTrabajoLibellus.RepositorioCupos.Insert(cupo);
                this.UnidadDeTrabajoLibellus.RepositorioEstudiante.ActualizarEstudiante(estudiante);
                this.UnidadDeTrabajoLibellus.SaveChanges();
            }
            else
            {
                tipoEstudiante = this.UnidadDeTrabajoLibellus.RepositorioMaestros.ConsultarMaestrosPorConsecutivo(ConsecutivoMaestros.EstudianteNuevo.GetHashCode(), 1);

                cupo.IdTipoEstudiante = tipoEstudiante.Id;
                cupo.Estudiante.FechaCreacion = DateTime.Now;
                Usuario usuario = this.UnidadDeTrabajoLibellus.RepositorioUsuarios.ConsultarUsurioPorNombreUsuario(cupo.Estudiante.Usuario.Identificacion);
                if (usuario == null)
                {
                    cupo.Estudiante.Usuario.NombreUsuario = cupo.Estudiante.Usuario.Identificacion;
                    cupo.Estudiante.Usuario.Clave = Utilidades.EncripcionLibellus.Cifrar(cupo.Estudiante.FechaNacimiento.ToShortDateString().Replace("/", string.Empty));
                    cupo.Estudiante.Usuario.IdEstado = (byte)Entidades.Enumerados.EstadoUsuario.Activo.GetHashCode();
                    cupo.Estudiante.Usuario.UsuariosRoles.Add(new UsuarioRol()
                    {
                        IdRol = (int)Roles.Estudiante,
                        IdSede = Utilidades.ContextoLibellus.ObtenerSedeActual
                    });
                }
                else
                {
                    usuario.Correo = cupo.Estudiante.Usuario.Correo;
                    cupo.Estudiante.Usuario = usuario;
                }

                this.UnidadDeTrabajoLibellus.RepositorioCupos.Insert(cupo);
                this.UnidadDeTrabajoLibellus.SaveChanges();
            }

            this.EnvioInformacionCupo(cupo);
            return cupo.IdEstudiante;
        }

        /// <summary>
        /// Realiza el envio de correo electronico.
        /// </summary>
        /// <param name="cupo">Cupo generado.</param>
        private void EnvioInformacionCupo(Cupo cupo)
        {
            Dictionary<string, string> parametros = this.ObtenerParametrosCorreo();
            string rutaPlantillasEmail = UtilidadesApp.ObtenerRutaCompleta(String.Format("{0}/{1}", parametros[ConstantesApp.RutaPlantillaEmails], parametros[ConstantesApp.PlantillaEmailCupoGenerado]));
            string mensajeTexto = String.Format(File.ReadAllText(rutaPlantillasEmail),
                string.Format("{0} {1} {2}", cupo.Estudiante.Nombre, cupo.Estudiante.PrimerApellido, cupo.Estudiante.SegundoApellido),
                cupo.Estudiante.Usuario.NombreUsuario,
                EncripcionLibellus.Descifrar(cupo.Estudiante.Usuario.Clave),
                "1010"); //TODO: DLR, Obtener el codigo del colegio desde el sistema.

            UtilidadesApp.EnviarCorreoElectronico(mensajeTexto, "Registro de usuario",
                   parametros[ConstantesApp.ServidorSmtpCorreoElectronico],
                   Convert.ToInt16(parametros[ConstantesApp.PuertoSmtpCorreoElectronico]),
                   parametros[ConstantesApp.UsuarioCorreoElectronico],
                   parametros[ConstantesApp.ClaveAccesoCorreoElectronico],
                   parametros[ConstantesApp.AliasCorreoElectronico],
                   cupo.Estudiante.Usuario.Correo);
        }

        /// <summary>
        /// Obtiene los parametros para el envio de correo.
        /// </summary>
        /// <returns>Coleccion de parametros del sistema.</returns>
        private Dictionary<string, string> ObtenerParametrosCorreo()
        {
            List<ParametrosNegocio> parametros = this.UnidadDeTrabajoLibellus.RepositorioParametros.Get().ToList();
            Dictionary<string, string> data = new Dictionary<string, string>();

            if (parametros != null && parametros.Count > 0)
            {
                foreach (var item in parametros)
                {
                    data.Add(item.Nombre, item.Valor);
                }
            }

            return data;
        }
    }
}