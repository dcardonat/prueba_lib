// --------------------------------------------------------------------------
// <copyright file="MapeoMaestros.cs" company="InterGrupo S.A.">
//     COPYRIGHT(C) 2015, Intergrupo S.A
// </copyright>
// <author>José Manuel Gómez López</author>
// <email>jmgomez@intergrupo.com</email>
// <date>13/04/2015</date>
// <summary>Establece el mapeo de la estructura de las entidades del módulo maestros en el modelo de LibellusDbContext.</summary>
// --------------------------------------------------------------------------

namespace Libellus.Repositorio.MapeoEntidades
{
    using Libellus.Entidades;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;

    /// <summary>
    /// Establece el mapeo de la estructura de las entidades del módulo maestros en el modelo de LibellusDbContext.
    /// </summary>
    public static class MapeoAdministracion
    {
        #region Métodos públicos

        /// <summary>
        /// Establece el mapeo de las entidades del módulo Activaciones 4G.
        /// </summary>
        /// <param name="modelBuilder">Modelo a mapear.</param>
        public static void EstablecerMapeo(DbModelBuilder modelBuilder)
        {
            EstablecerMapeoSedes(modelBuilder);
            EstablecerMapeoActividadesComplementarias(modelBuilder);
            EstablecerMapeoTipoMaestros(modelBuilder);
            EstablecerMapeoMaestros(modelBuilder);
            EstablecerMapeoUsuarioAdministrativo(modelBuilder);
            EstablecerMapeoUsuarios(modelBuilder);
            EstablecerMapeoFuncionalidades(modelBuilder);
            EstablecerMapeoRoles(modelBuilder);
            EstablecerMapeoAsignaturas(modelBuilder);
            EstablecerMapeoAulas(modelBuilder);
            EstablecerMapeoSalidasOcupacionales(modelBuilder);
            EstablecerMapeoGradosPorNivel(modelBuilder);
            EstablecerMapeoSoportePorRoles(modelBuilder);
            EstablecerMapeoSoportePorRolesDocumentos(modelBuilder);
            EstablecerMapeoRolesFuncionalidades(modelBuilder);
            EstablecerMapeoRolesUsuarios(modelBuilder);
            EstablecerMapeoInsitucionEducativa(modelBuilder);
            EstablecerMapeoRegistroLegalizacion(modelBuilder);
            EstablecerMapeoIntensidadHoraria(modelBuilder);
            EstablecerMapeoParametrizacionInstitucional(modelBuilder);
            EstablecerMapeoPaises(modelBuilder);
            EstablecerMapeoDepartamentos(modelBuilder);
            EstablecerMapeoMunicipios(modelBuilder);
            EstablecerMapeoDocenteArchivos(modelBuilder);
            EstablecerMapeoDocenteDatosPersonales(modelBuilder);
            EstablecerMapeoDocenteDatosResidenciales(modelBuilder);
            EstablecerMapeoDocenteDocumentosSoporte(modelBuilder);
            EstablecerMapeoDocenteEstados(modelBuilder);
            EstablecerMapeoDocenteEstudios(modelBuilder);
            EstablecerMapeoDocenteExperienciaLaboral(modelBuilder);
            EstablecerMapeoProyeccionCuposPorNivel(modelBuilder);
            EstablecerMapeoAnioLectivo(modelBuilder);
            EstablecerMapeoParametrizacionEscolar(modelBuilder);
            EstablecerMapeoGradosParametrizacion(modelBuilder);
            EstablecerMapeoNivelesParametrizacion(modelBuilder);
            EstablecerMapeoAreasNivel(modelBuilder);
            EstablecerMapeoPeriodosParametrizacion(modelBuilder);
            EstablecerMapeoAperturaExtemporaneaPeriodos(modelBuilder);
            EstablecerMapeoParametrosNegocio(modelBuilder);
            EstablecerMapeoEstadoUsuario(modelBuilder);
            EstablecerMapeoGruposPorGrado(modelBuilder);
        }

        #endregion Métodos públicos

        #region Cofiguración de tablas

        /// <summary>
        /// Configura la estructura de la entidad ProyeccionCuposPorNivel.
        /// </summary>
        /// <param name="modelBuilder">Modelo a asociar.</param>
        private static void EstablecerMapeoProyeccionCuposPorNivel(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProyeccionCuposPorNivel>()
                .ToTable("ProyeccionCuposPorNiveles", "dbo")
                .HasKey(e => e.Id);

            modelBuilder.Entity<ProyeccionCuposPorNivel>()
                .HasRequired<Maestro>(e => e.NivelEducativo)
                .WithMany(e => e.NivelesEducativosGrupos)
                .HasForeignKey(e => e.IdNivel)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProyeccionCuposPorNivel>()
                .HasRequired<Sede>(e => e.Sede)
                .WithMany(e => e.CuposPorNiveles)
                .HasForeignKey(e => e.IdSede)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProyeccionCuposPorNivel>()
              .HasRequired<AnioLectivo>(e => e.AnioLectivo)
              .WithMany(e => e.ProyeccionCuposPorNivel)
              .HasForeignKey(e => e.IdAnioLectivo)
              .WillCascadeOnDelete(false);
        }

        /// <summary>
        /// Configura la estructura de la entidad SoportePorRol.
        /// </summary>
        /// <param name="modelBuilder">Modelo a asociar.</param>
        private static void EstablecerMapeoSoportePorRoles(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SoportePorRol>()
                .ToTable("SoportePorRoles", "dbo")
                .HasKey(e => e.Id);

            modelBuilder.Entity<SoportePorRol>()
                .HasRequired<AnioLectivo>(e => e.AnioLectivo)
                .WithMany(e => e.SoportePorRoles)
                .HasForeignKey(e => e.IdAnioLectivo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SoportePorRol>()
                .HasRequired<Maestro>(e => e.RolInstitucional)
                .WithMany(e => e.RolesInstitucionales)
                .HasForeignKey(e => e.IdRolInstitucional)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SoportePorRol>()
                .HasOptional<Maestro>(e => e.NivelEducativo)
                .WithMany(e => e.NivelesEducativos)
                .HasForeignKey(e => e.IdNivelEducativo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SoportePorRol>()
                .HasRequired<Sede>(e => e.Sede)
                .WithMany(e => e.SoportePorRoles)
                .HasForeignKey(e => e.IdSede)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SoportePorRol>()
                .Property(e => e.Estado)
                .IsRequired();
        }

        /// <summary>
        /// Configura la estructura de la entidad SoportePorRolDocumento.
        /// </summary>
        /// <param name="modelBuilder"></param>
        private static void EstablecerMapeoSoportePorRolesDocumentos(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SoportePorRolesDocumento>()
                .ToTable("SoportePorRolesDocumentos", "dbo")
                .HasKey(e => e.Id);

            modelBuilder.Entity<SoportePorRolesDocumento>()
                .HasRequired<SoportePorRol>(e => e.SoportePorRol)
                .WithMany(e => e.Documentos)
                .HasForeignKey(e => e.IdSoportePorRoles)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SoportePorRolesDocumento>()
                .HasRequired<Maestro>(e => e.TipoDocumentoSoporte)
                .WithMany(e => e.DocumentosSoporte)
                .HasForeignKey(e => e.IdTipoDocumentoSoporte)
                .WillCascadeOnDelete(false);
        }

        /// <summary>
        /// Configura la estructura de la entidad ActividadesComplementarias.
        /// </summary>
        /// <param name="modelBuilder">Modelo a asociar.</param>
        private static void EstablecerMapeoActividadesComplementarias(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActividadComplementaria>()
                .ToTable("ActividadesComplementarias", "dbo")
                .HasKey(e => e.Id);

            modelBuilder.Entity<ActividadComplementaria>()
                .Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsRequired()
                .IsUnicode(false);

            modelBuilder.Entity<ActividadComplementaria>()
                .HasRequired<Sede>(e => e.Sede)
                .WithMany(e => e.ActividadesComplementarias)
                .HasForeignKey(e => e.IdSede)
                .WillCascadeOnDelete(false);
        }

        /// <summary>
        /// Configura la estructura de la entidad Asignaturas.
        /// </summary>
        /// <param name="modelBuilder">Modelo a asociar.</param>
        private static void EstablecerMapeoAsignaturas(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Asignatura>()
                .ToTable("Asignaturas", "dbo")
                .HasKey(e => e.Id);

            modelBuilder.Entity<Asignatura>()
                .Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsRequired()
                .IsUnicode(false);

            modelBuilder.Entity<Asignatura>()
                .HasRequired<Maestro>(e => e.Maestro)
                .WithMany(e => e.Asignaturas)
                .HasForeignKey(e => e.IdMaestro)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Asignatura>()
                .HasRequired<Sede>(e => e.Sede)
                .WithMany(e => e.Asignaturas)
                .HasForeignKey(e => e.IdSede)
                .WillCascadeOnDelete(false);
        }

        /// <summary>
        /// Configura la estructura de la entidad Aulas.
        /// </summary>
        /// <param name="modelBuilder">Modelo a asociar.</param>
        private static void EstablecerMapeoAulas(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aula>()
                .ToTable("Aulas", "dbo")
                .HasKey(e => e.Id);

            modelBuilder.Entity<Aula>()
                .Property(e => e.Descripcion)
                .HasMaxLength(30)
                .IsRequired()
                .IsUnicode(false);

            modelBuilder.Entity<Aula>()
                .HasRequired<Sede>(e => e.Sede)
                .WithMany(e => e.Aulas)
                .HasForeignKey(e => e.IdSede)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Aula>()
                .HasRequired<Maestro>(e => e.Maestro)
                .WithMany(e => e.Aulas)
                .HasForeignKey(e => e.IdMaestro)
                .WillCascadeOnDelete(false);
        }

        /// <summary>
        /// Configura la estructura de la entidad Funcionalidades.
        /// </summary>
        /// <param name="modelBuilder">Modelo a asociar.</param>
        private static void EstablecerMapeoFuncionalidades(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Funcionalidad>()
               .ToTable("Funcionalidades", "dbo")
               .HasKey(e => e.Id);

            modelBuilder.Entity<Funcionalidad>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Funcionalidad>()
                .Property(e => e.Descripcion)
                .IsFixedLength();

            modelBuilder.Entity<Funcionalidad>()
                .Property(e => e.IdPadre);

            modelBuilder.Entity<Funcionalidad>()
                .Property(e => e.Url)
                .IsUnicode(false);

            modelBuilder.Entity<Funcionalidad>()
                .HasMany(e => e.Funcionalidades)
                .WithOptional(e => e.FuncionalidadPadre)
                .HasForeignKey(e => e.IdPadre);

            modelBuilder.Entity<Funcionalidad>()
                .HasMany(e => e.RolesFuncionalidades)
                .WithRequired(e => e.Funcionalidad)
                .HasForeignKey(e => e.IdFuncionalidad)
                .WillCascadeOnDelete(false);
        }

        /// <summary>
        /// Configura la estructura de la entidad Maestros.
        /// </summary>
        /// <param name="modelBuilder">Modelo a asociar.</param>
        private static void EstablecerMapeoMaestros(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Maestro>()
                .ToTable("Maestros", "dbo")
                .HasKey(e => e.Id);

            modelBuilder.Entity<Maestro>()
                .HasMany(e => e.Cargos)
                .WithOptional(e => e.Cargo)
                .HasForeignKey(e => e.IdCargo);

            modelBuilder.Entity<Maestro>()
                .HasMany(e => e.GruposSanguineos)
                .WithRequired(e => e.GrupoSanguineo)
                .HasForeignKey(e => e.IdGrupoSanguineo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Maestro>()
                .HasMany(e => e.TiposIdentificaciones)
                .WithRequired(e => e.TipoIdentificacion)
                .HasForeignKey(e => e.IdTipoIdentificacion)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Maestro>()
                .HasMany(e => e.ParametrizacionInstitucionalHorarios)
                .WithRequired(e => e.Horario)
                .HasForeignKey(e => e.IdHorario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Maestro>()
                .HasMany(e => e.ParametrizacionInstitucionalNivelesEducativos)
                .WithRequired(e => e.NivelEducativo)
                .HasForeignKey(e => e.IdNivelEducativo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Maestro>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Maestro>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Maestro>()
                .HasMany(e => e.DocenteDatosPersonalesTipoDocumento)
                .WithRequired(e => e.TipoDocumento)
                .HasForeignKey(e => e.IdTipoDocumento)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Maestro>()
                .HasMany(e => e.DocenteDatosPersonalesSexo)
                .WithRequired(e => e.Sexo)
                .HasForeignKey(e => e.IdSexo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Maestro>()
                .HasMany(e => e.DocenteDatosPersonalesGrupoSanguineo)
                .WithRequired(e => e.GrupoSanguineo)
                .HasForeignKey(e => e.IdGrupoSanguineo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Maestro>()
                .HasMany(e => e.DocenteDatosPersonalesEstadoCivil)
                .WithRequired(e => e.EstadoCivil)
                .HasForeignKey(e => e.IdEstadoCivil)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Maestro>()
                .HasMany(e => e.DocenteDatosPersonalesRolInstitucional)
                .WithRequired(e => e.RolInstitucional)
                .HasForeignKey(e => e.IdRolInstitucional)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Maestro>()
                .HasMany(e => e.DocenteDatosResidenciales)
                .WithRequired(e => e.Estrato)
                .HasForeignKey(e => e.IdEstrato)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Maestro>()
                .HasMany(e => e.DocenteEstados)
                .WithRequired(e => e.Estado)
                .HasForeignKey(e => e.IdEstado)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Maestro>()
                .HasMany(e => e.DocenteHorario)
                .WithRequired(e => e.Horario)
                .HasForeignKey(e => e.IdHorario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Maestro>()
                .HasMany(e => e.DocenteEstudiosClasificacion)
                .WithRequired(e => e.Clasificacion)
                .HasForeignKey(e => e.IdClasificacion)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Maestro>()
                .HasMany(e => e.DocenteEstudiosEstadoEstudio)
                .WithRequired(e => e.EstadoEstudio)
                .HasForeignKey(e => e.IdEstado)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Maestro>()
                .HasMany(e => e.DocenteDatosPersonalesGradoEscalafon)
                .WithRequired(e => e.GradoEscalafon)
                .HasForeignKey(e => e.IdGradoEscalafon)
                .WillCascadeOnDelete(false);
        }

        /// <summary>
        /// Configura la estructura de la entidad Roles.
        /// </summary>
        /// <param name="modelBuilder">Modelo a asociar.</param>
        private static void EstablecerMapeoRoles(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rol>()
               .ToTable("Roles", "dbo")
               .HasKey(e => e.Id);

            modelBuilder.Entity<Rol>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Rol>()
                .HasMany(e => e.UsuariosRoles)
                .WithRequired(e => e.Rol)
                .HasForeignKey(e => e.IdRol)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Rol>()
             .HasMany(e => e.RolesFuncionalidades)
             .WithRequired(e => e.Rol)
             .HasForeignKey(e => e.IdRol)
             .WillCascadeOnDelete(false);
        }

        /// <summary>
        /// Configura la estructura de la entidad UsuarioRol.
        /// </summary>
        /// <param name="modelBuilder">Modelo a asociar.</param>
        private static void EstablecerMapeoRolesUsuarios(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsuarioRol>()
              .ToTable("UsuariosRoles", "dbo")
              .HasKey(e => e.Id);

            modelBuilder.Entity<UsuarioRol>()
                .Property(e => e.IdRol);

            modelBuilder.Entity<UsuarioRol>()
                .Property(e => e.IdSede);

            modelBuilder.Entity<UsuarioRol>()
                .Property(e => e.IdUsuario);
        }

        /// <summary>
        /// Configura la estructura de la entidad RolesFuncionalidades.
        /// </summary>
        /// <param name="modelBuilder">Modelo a asociar.</param>
        private static void EstablecerMapeoRolesFuncionalidades(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RolesFuncionalidades>()
                .ToTable("RolesFuncionalidades", "dbo")
                .HasKey(e => e.Id);

            modelBuilder.Entity<RolesFuncionalidades>()
                .Property(e => e.IdFuncionalidad);

            modelBuilder.Entity<RolesFuncionalidades>()
                .Property(e => e.IdRol);
        }

        /// <summary>
        /// Configura la estructura de la entidad Sedes.
        /// </summary>
        /// <param name="modelBuilder">Modelo a asociar.</param>
        private static void EstablecerMapeoSedes(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sede>()
              .ToTable("Sedes", "dbo")
              .HasKey(e => e.Id);

            modelBuilder.Entity<Sede>()
                .Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsRequired();

            modelBuilder.Entity<Sede>()
                .Property(e => e.Seccion)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsRequired();

            modelBuilder.Entity<Sede>()
                .HasRequired<InstitucionEducativa>(e => e.InstitucionEducativa)
                .WithMany(e => e.Sedes)
                .HasForeignKey(e => e.IdInstitucionEducativa)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sede>()
                .HasMany(e => e.Maestros)
                .WithRequired(e => e.Sede)
                .HasForeignKey(e => e.IdSede)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sede>()
                .HasMany(e => e.Roles)
                .WithRequired(e => e.Sede)
                .HasForeignKey(e => e.IdSede)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sede>()
                .HasMany(e => e.ParametrizacionInstitucional)
                .WithRequired(e => e.Sede)
                .HasForeignKey(e => e.IdSede)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sede>()
              .HasMany(e => e.UsuariosRoles)
              .WithRequired(e => e.Sede)
              .HasForeignKey(e => e.IdSede)
              .WillCascadeOnDelete(false);
        }

        /// <summary>
        /// Configura la estructura de la entidad TipoMaestros.
        /// </summary>
        /// <param name="modelBuilder">Modelo a asociar.</param>
        private static void EstablecerMapeoTipoMaestros(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TipoMaestro>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<TipoMaestro>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<TipoMaestro>()
                .HasMany(e => e.Maestros)
                .WithRequired(e => e.TipoMaestro)
                .HasForeignKey(e => e.IdTipoMaestro)
                .WillCascadeOnDelete(false);
        }

        /// <summary>
        /// COnfigurar la estructura de la entidad Usuarios.
        /// </summary>
        /// <param name="modelBuilder">Modelo a asociar.</param>
        private static void EstablecerMapeoUsuarios(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>()
                .ToTable("Usuarios", "dbo")
                .HasKey(e => e.Id);

            modelBuilder.Entity<Usuario>()
            .Property(e => e.Correo)
              .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
             .Property(e => e.Clave)
             .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
              .Property(e => e.NombreUsuario)
              .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.IdEstado);

            modelBuilder.Entity<Usuario>()
               .Property(e => e.Identificacion)
            .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.UsuariosAdministrativos)
                .WithRequired(e => e.Usuario)
                .HasForeignKey(e => e.IdUsuario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
              .HasMany(e => e.UsuariosRoles)
              .WithRequired(e => e.Usuario)
              .HasForeignKey(e => e.IdUsuario)
              .WillCascadeOnDelete(false);
        }

        /// <summary>
        /// Configura la estructura de la entidad UsuariosAdministrativos.
        /// </summary>
        /// <param name="modelBuilder">Modelo a asociar.</param>
        private static void EstablecerMapeoUsuarioAdministrativo(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsuarioAdministrativo>()
                .ToTable("UsuariosAdministrativos", "dbo")
                .HasKey(e => e.Id);

            modelBuilder.Entity<UsuarioAdministrativo>()
                .Property(e => e.Nombres)
                .IsUnicode(false);

            modelBuilder.Entity<UsuarioAdministrativo>()
                .Property(e => e.Apellidos)
                .IsUnicode(false);

            modelBuilder.Entity<UsuarioAdministrativo>()
                .Property(e => e.Telefono)
                .IsUnicode(false);

            modelBuilder.Entity<UsuarioAdministrativo>()
                .Property(e => e.Direccion)
                .IsUnicode(false);

            modelBuilder.Entity<UsuarioAdministrativo>()
                .Property(e => e.Celular)
                .IsUnicode(false);
        }

        /// <summary>
        /// Configura la estructura de la entidad SalidasOcupacionales.
        /// </summary>
        /// <param name="modelBuilder">Modelo a asociar.</param>
        private static void EstablecerMapeoSalidasOcupacionales(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SalidaOcupacional>()
                .ToTable("SalidasOcupacionales", "dbo")
                .HasKey(e => e.Id);

            modelBuilder.Entity<SalidaOcupacional>()
                .Property(e => e.Descripcion)
                .HasMaxLength(30)
                .IsRequired()
                .IsUnicode(false);

            modelBuilder.Entity<SalidaOcupacional>()
                .HasRequired<Sede>(e => e.Sede)
                .WithMany(e => e.SalidasOcupacionales)
                .HasForeignKey(e => e.IdSede)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SalidaOcupacional>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);
        }

        /// <summary>
        /// Configura la estructura de la entidad GradosPorNivel.
        /// </summary>
        /// <param name="modelBuilder">Modelo a asociar.</param>
        private static void EstablecerMapeoGradosPorNivel(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GradosPorNivel>()
                .ToTable("GradosPorNivel", "dbo")
                .HasKey(e => e.Id);

            modelBuilder.Entity<GradosPorNivel>()
                .HasRequired<Maestro>(e => e.Nivel)
                .WithMany(e => e.Niveles)
                .HasForeignKey(e => e.IdNivel)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GradosPorNivel>()
                .HasRequired<Maestro>(e => e.Grado)
                .WithMany(e => e.Grados)
                .HasForeignKey(e => e.IdGrado)
                .WillCascadeOnDelete(false);
        }

        /// <summary>
        /// Configura la estructura de la entidad InstitucionEducativa.
        /// </summary>
        /// <param name="modelBuilder">Modelo a asociar.</param>
        private static void EstablecerMapeoInsitucionEducativa(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InstitucionEducativa>()
                .ToTable("InstitucionEducativa", "dbo")
                .HasKey(e => e.Id);

            modelBuilder.Entity<InstitucionEducativa>()
                .Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsRequired();

            modelBuilder.Entity<InstitucionEducativa>()
                .Property(e => e.ResolucionAprobacion)
                .HasMaxLength(600)
                .IsUnicode(false);

            modelBuilder.Entity<InstitucionEducativa>()
                .Property(e => e.Nit)
                .HasMaxLength(15)
                .IsUnicode(false);

            modelBuilder.Entity<InstitucionEducativa>()
                .Property(e => e.CodigoDane)
                .HasMaxLength(15)
                .IsUnicode(false);

            modelBuilder.Entity<InstitucionEducativa>()
                .Property(e => e.Rut)
                .HasMaxLength(200)
                .IsUnicode(false);

            modelBuilder.Entity<InstitucionEducativa>()
                .Property(e => e.Logo)
                .HasColumnType("image");

            modelBuilder.Entity<InstitucionEducativa>()
                .Property(e => e.Direccion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsRequired();

            modelBuilder.Entity<InstitucionEducativa>()
                .Property(e => e.Telefono)
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsRequired();

            modelBuilder.Entity<InstitucionEducativa>()
                .Property(e => e.Fax)
                .HasMaxLength(15)
                .IsUnicode(false);

            modelBuilder.Entity<InstitucionEducativa>()
                .Property(e => e.PaginaWeb)
                .HasMaxLength(100)
                .IsUnicode(false);
        }

        /// <summary>
        /// Configura la estructura de la entidad RegistroLegalizacion.
        /// </summary>
        /// <param name="modelBuilder">Modelo a asociar.</param>
        private static void EstablecerMapeoRegistroLegalizacion(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RegistroLegalizacion>()
                .ToTable("RegistrosLegalizacion", "dbo")
                .HasKey(e => e.Id);

            modelBuilder.Entity<RegistroLegalizacion>()
                .Property(e => e.TipoRegistro)
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsRequired();

            modelBuilder.Entity<RegistroLegalizacion>()
                .Property(e => e.FechaExpedicion)
                .HasColumnType("date");

            modelBuilder.Entity<RegistroLegalizacion>()
                .Property(e => e.TextoLegalizacion)
                .HasMaxLength(600)
                .IsUnicode(false)
                .IsRequired();

            modelBuilder.Entity<RegistroLegalizacion>()
                .Property(e => e.VigenciaDesde)
                .HasColumnType("date");

            modelBuilder.Entity<RegistroLegalizacion>()
                .Property(e => e.VigenciaHasta)
                .HasColumnType("date");

            modelBuilder.Entity<RegistroLegalizacion>()
                .HasRequired<InstitucionEducativa>(e => e.InstitucionEducativa)
                .WithMany(e => e.RegistrosLegalizacion)
                .HasForeignKey(e => e.IdInstitucionEducativa)
                .WillCascadeOnDelete(false);
        }

        /// <summary>
        /// Configura la estructura de la entidad IntensidadHoraria.
        /// </summary>
        /// <param name="modelBuilder">Modelo a asociar.</param>
        private static void EstablecerMapeoIntensidadHoraria(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IntensidadHoraria>()
                .ToTable("IntensidadHoraria", "dbo")
                .HasKey(e => e.Id);

            modelBuilder.Entity<IntensidadHoraria>()
                .HasRequired<AnioLectivo>(e => e.AnioLectivo)
                .WithMany(e => e.IntensidadesHorarias)
                .HasForeignKey(e => e.IdAnioLectivo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<IntensidadHoraria>()
                .HasRequired<Asignatura>(e => e.Asignatura)
                .WithMany(e => e.IntensidadesHorarias)
                .HasForeignKey(e => e.IdAsignatura)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<IntensidadHoraria>()
                .HasRequired<Maestro>(e => e.Grado)
                .WithMany(e => e.IntensidadesHorarias)
                .HasForeignKey(e => e.IdGrado)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<IntensidadHoraria>()
                .HasRequired<Sede>(e => e.Sede)
                .WithMany(e => e.IntensidadesHorarias)
                .HasForeignKey(e => e.IdSede)
                .WillCascadeOnDelete(false);
        }

        /// <summary>
        /// Configura la estructura de la entidad Paises.
        /// </summary>
        /// <param name="modelBuilder">Modelo a asociar.</param>
        private static void EstablecerMapeoPaises(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pais>()
                .ToTable("Paises", "dbo")
                .HasKey(e => e.Id);

            modelBuilder.Entity<Pais>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Pais>()
                .HasMany(e => e.Departamentos)
                .WithRequired(e => e.Paises)
                .HasForeignKey(e => e.IdPais)
                .WillCascadeOnDelete(false);
        }

        /// <summary>
        /// Configura la estructura de la entidad Departamentos.
        /// </summary>
        /// <param name="modelBuilder">Modelo a asociar.</param>
        private static void EstablecerMapeoDepartamentos(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Departamento>()
                .ToTable("Departamentos", "dbo")
                .HasKey(e => e.Id);

            modelBuilder.Entity<Departamento>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Departamento>()
                .HasMany(e => e.Municipios)
                .WithRequired(e => e.Departamentos)
                .HasForeignKey(e => e.IdDepartamento)
                .WillCascadeOnDelete(false);
        }

        /// <summary>
        /// Configura la estructura de la entidad Municipio.
        /// </summary>
        /// <param name="modelBuilder">Modelo a asociar.</param>
        private static void EstablecerMapeoMunicipios(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Municipio>()
                .ToTable("Municipios", "dbo")
                .HasKey(e => e.Id);

            modelBuilder.Entity<Municipio>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Municipio>()
                .HasMany(e => e.DocenteDatosPersonales)
                .WithRequired(e => e.Municipio)
                .HasForeignKey(e => e.IdMunicipioNacimiento)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Municipio>()
                .HasMany(e => e.DocenteDatosResidenciales)
                .WithRequired(e => e.Municipio)
                .HasForeignKey(e => e.IdMunicipio)
                .WillCascadeOnDelete(false);
        }

        /// <summary>
        /// Configura la estructura de la entidad ParametrizacionInstitucional.
        /// </summary>
        /// <param name="modelBuilder">Modelo a asociar.</param>
        private static void EstablecerMapeoParametrizacionInstitucional(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ParametrizacionInstitucional>()
                .ToTable("ParametrizacionInstitucional", "dbo")
                .HasKey(e => e.Id);

            modelBuilder.Entity<ParametrizacionInstitucional>()
                .HasRequired<AnioLectivo>(e => e.AnioLectivo)
                .WithMany(e => e.ParametrizacionesInstitucionales)
                .HasForeignKey(e => e.IdAnioLectivo)
                .WillCascadeOnDelete(false);
        }

        /// <summary>
        /// Configura la estructura de la entidad IntensidadHoraria.
        /// </summary>
        /// <param name="modelBuilder">Modelo a asociar.</param>
        private static void EstablecerMapeoDocenteArchivos(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DocenteArchivo>()
                .ToTable("DocentesArchivos", "dbo")
                .HasKey(e => e.Id);
        }

        /// <summary>
        /// Configura la estructura de la entidad DocenteDatosPersonales.
        /// </summary>
        /// <param name="modelBuilder">Modelo a asociar.</param>
        private static void EstablecerMapeoDocenteDatosPersonales(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DocenteDatosPersonales>()
                .ToTable("DocentesDatosPersonales", "dbo")
                .HasKey(e => e.Id);

            modelBuilder.Entity<DocenteDatosPersonales>()
                .Property(e => e.Nombres)
                .IsUnicode(false);

            modelBuilder.Entity<DocenteDatosPersonales>()
                .Property(e => e.Apellidos)
                .IsUnicode(false);

            modelBuilder.Entity<DocenteDatosPersonales>()
                .Property(e => e.CorreoElectronico)
                .IsUnicode(false);

            modelBuilder.Entity<DocenteDatosPersonales>()
                .HasMany(e => e.DocenteArchivos)
                .WithRequired(e => e.DocenteDatosPersonales)
                .HasForeignKey(e => e.IdDocente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DocenteDatosPersonales>()
                .HasMany(e => e.DocenteDatosResidenciales)
                .WithRequired(e => e.DocenteDatosPersonales)
                .HasForeignKey(e => e.IdDocente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DocenteDatosPersonales>()
                .HasMany(e => e.DocenteDocumentosSoporte)
                .WithRequired(e => e.DocenteDatosPersonales)
                .HasForeignKey(e => e.IdDocente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DocenteDatosPersonales>()
                .HasMany(e => e.DocenteEstados)
                .WithRequired(e => e.DocenteDatosPersonales)
                .HasForeignKey(e => e.IdDocente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DocenteDatosPersonales>()
                .HasMany(e => e.DocenteEstudios)
                .WithRequired(e => e.DocenteDatosPersonales)
                .HasForeignKey(e => e.IdDocente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DocenteDatosPersonales>()
                .HasMany(e => e.DocenteExperienciaLaboral)
                .WithRequired(e => e.DocenteDatosPersonales)
                .HasForeignKey(e => e.IdDocente)
                .WillCascadeOnDelete(false);
        }

        /// <summary>
        /// Configura la estructura de la entidad DocenteDatosResidenciales.
        /// </summary>
        /// <param name="modelBuilder">Modelo a asociar.</param>
        private static void EstablecerMapeoDocenteDatosResidenciales(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DocenteDatosResidenciales>()
                .ToTable("DocentesDatosResidenciales", "dbo")
                .HasKey(e => e.Id);

            modelBuilder.Entity<DocenteDatosResidenciales>()
                .Property(e => e.Direccion)
                .IsUnicode(false);

            modelBuilder.Entity<DocenteDatosResidenciales>()
                .Property(e => e.Barrio)
                .IsUnicode(false);

            modelBuilder.Entity<DocenteDatosResidenciales>()
                .Property(e => e.Telefono)
                .IsUnicode(false);

            modelBuilder.Entity<DocenteDatosResidenciales>()
                .Property(e => e.TelefonoMovil)
                .IsUnicode(false);
        }

        /// <summary>
        /// Configura la estructura de la entidad IntensidadHoraria.
        /// </summary>
        /// <param name="modelBuilder">Modelo a asociar.</param>
        private static void EstablecerMapeoDocenteDocumentosSoporte(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DocenteDocumentoSoporte>()
                .ToTable("DocentesDocumentosSoporte", "dbo")
                .HasKey(e => e.Id);

            modelBuilder.Entity<DocenteDocumentoSoporte>()
                .HasRequired<SoportePorRolesDocumento>(e => e.SoportePorRolesDocumentos)
                .WithMany(e => e.DocentesDocumentosSoporte)
                .HasForeignKey(e => e.IdDocumento)
                .WillCascadeOnDelete(false);
        }

        /// <summary>
        /// Configura la estructura de la entidad IntensidadHoraria.
        /// </summary>
        /// <param name="modelBuilder">Modelo a asociar.</param>
        private static void EstablecerMapeoDocenteEstados(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DocenteEstado>()
                .ToTable("DocentesEstados", "dbo")
                .HasKey(e => e.Id);

            modelBuilder.Entity<DocenteEstado>()
                .Property(e => e.ObservacionesEstado)
                .IsUnicode(false);
        }

        /// <summary>
        /// Configura la estructura de la entidad DocenteEstudio.
        /// </summary>
        /// <param name="modelBuilder">Modelo a asociar.</param>
        private static void EstablecerMapeoDocenteEstudios(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DocenteEstudio>()
                .ToTable("DocentesEstudios", "dbo")
                .HasKey(e => e.Id);

            modelBuilder.Entity<DocenteEstudio>()
                .Property(e => e.InstitucionEducativa)
                .IsUnicode(false);

            modelBuilder.Entity<DocenteEstudio>()
                .Property(e => e.Titulo)
                .IsUnicode(false);
        }

        /// <summary>
        /// Configura la estructura de la entidad DocenteExperienciaLaboral.
        /// </summary>
        /// <param name="modelBuilder">Modelo a asociar.</param>
        private static void EstablecerMapeoDocenteExperienciaLaboral(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DocenteExperienciaLaboral>()
                .ToTable("DocentesExperienciaLaboral", "dbo")
                .HasKey(e => e.Id);

            modelBuilder.Entity<DocenteExperienciaLaboral>()
                .Property(e => e.NombreInstitucion)
                .IsUnicode(false);

            modelBuilder.Entity<DocenteExperienciaLaboral>()
                .Property(e => e.MotivoRetiro)
                .IsUnicode(false);

            modelBuilder.Entity<DocenteExperienciaLaboral>()
                .Property(e => e.AreasCompetencia)
                .IsUnicode(false);
        }

        /// <summary>
        /// Configura la estructura de la entidad AnioLectivo.
        /// </summary>
        /// <param name="modelBuilder">Modelo a asociar.</param>
        private static void EstablecerMapeoAnioLectivo(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnioLectivo>()
                .ToTable("AnioLectivo", "dbo")
                .HasKey(e => e.Id);

            modelBuilder.Entity<AnioLectivo>()
                .HasRequired<Sede>(e => e.Sede)
                .WithMany(e => e.AniosLectivos)
                .HasForeignKey(e => e.IdSede)
                .WillCascadeOnDelete(false);
        }

        /// <summary>
        /// Configura la estructura de la entidad ParametrizacionEscolar.
        /// </summary>
        /// <param name="modelBuilder">Modelo a asociar.</param>
        private static void EstablecerMapeoParametrizacionEscolar(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ParametrizacionEscolar>()
                .ToTable("ParametrizacionEscolar", "dbo")
                .HasKey(e => e.Id);

            modelBuilder.Entity<ParametrizacionEscolar>()
                .HasRequired<AnioLectivo>(e => e.AnioLectivo)
                .WithMany(e => e.ParametrizacionesEscolares)
                .HasForeignKey(e => e.IdAnioLectivo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ParametrizacionEscolar>()
                .HasRequired<Maestro>(e => e.TipoParametrizacion)
                .WithMany(e => e.TiposParametrizacion)
                .HasForeignKey(e => e.IdTipoParametrizacion)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ParametrizacionEscolar>()
                .HasOptional<Maestro>(e => e.Semestre)
                .WithMany(e => e.Semestres)
                .HasForeignKey(e => e.IdSemestre)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ParametrizacionEscolar>()
                .HasRequired<Maestro>(e => e.JornadaAcademica)
                .WithMany(e => e.JornadasAcademicas)
                .HasForeignKey(e => e.IdJornadaAcademica)
                .WillCascadeOnDelete(false);
        }

        /// <summary>
        /// Configura la estructura de la entidad GradosParametrizacion.
        /// </summary>
        /// <param name="modelBuilder">Modelo a asociar.</param>
        private static void EstablecerMapeoGradosParametrizacion(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GradoParametrizacion>()
                .ToTable("GradosParametrizacion", "dbo")
                .HasKey(e => e.Id);

            modelBuilder.Entity<GradoParametrizacion>()
                .HasRequired<ParametrizacionEscolar>(e => e.ParametrizacionEscolar)
                .WithMany(e => e.GradosParametrizacion)
                .HasForeignKey(e => e.IdParametrizacionEscolar)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GradoParametrizacion>()
                .HasRequired<Maestro>(e => e.Grado)
                .WithMany(e => e.GradosPorParametrizacion)
                .HasForeignKey(e => e.IdGrado)
                .WillCascadeOnDelete(false);
        }

        /// <summary>
        /// Configura la estructura de la entidad NivelesParametrizacion.
        /// </summary>
        /// <param name="modelBuilder">Modelo a asociar.</param>
        private static void EstablecerMapeoNivelesParametrizacion(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NivelParametrizacion>()
                .ToTable("NivelesParametrizacion", "dbo")
                .HasKey(e => e.Id);

            modelBuilder.Entity<NivelParametrizacion>()
                .HasRequired<ParametrizacionEscolar>(e => e.ParametrizacionEscolar)
                .WithMany(e => e.NivelesParametrizacion)
                .HasForeignKey(e => e.IdParametrizacionEscolar)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NivelParametrizacion>()
                .HasRequired<Maestro>(e => e.Nivel)
                .WithMany(e => e.NivelesParametrizacion)
                .HasForeignKey(e => e.IdNivel)
                .WillCascadeOnDelete(false);
        }

        /// <summary>
        /// Configura la estructura de la entidad AreasNivel.
        /// </summary>
        /// <param name="modelBuilder">Modelo a asociar.</param>
        private static void EstablecerMapeoAreasNivel(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AreaNivel>()
                .ToTable("AreasNivel", "dbo")
                .HasKey(e => e.Id);

            modelBuilder.Entity<AreaNivel>()
                .HasRequired<NivelParametrizacion>(e => e.NivelParametrizacion)
                .WithMany(e => e.AreasNivel)
                .HasForeignKey(e => e.IdNivelParametrizacion)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AreaNivel>()
                .HasRequired<Maestro>(e => e.Area)
                .WithMany(e => e.AreasNivel)
                .HasForeignKey(e => e.IdArea)
                .WillCascadeOnDelete(false);
        }

        /// <summary>
        /// Configura la estructura de la entidad PeriodosParametrizacion.
        /// </summary>
        /// <param name="modelBuilder">Modelo a asociar.</param>
        private static void EstablecerMapeoPeriodosParametrizacion(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PeriodoParametrizacion>()
                .ToTable("PeriodosParametrizacion", "dbo")
                .HasKey(e => e.Id);

            modelBuilder.Entity<PeriodoParametrizacion>()
                .HasRequired<ParametrizacionEscolar>(e => e.ParametrizacionEscolar)
                .WithMany(e => e.PeriodosParametrizacion)
                .HasForeignKey(e => e.IdParametrizacionEscolar)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PeriodoParametrizacion>()
                .Property(e => e.FechaFinal)
                .HasColumnType("date");

            modelBuilder.Entity<PeriodoParametrizacion>()
                .Property(e => e.FechaInicial)
                .HasColumnType("date");
        }

        /// <summary>
        /// Configura la estructura de la entidad PeriodosParametrizacion.
        /// </summary>
        /// <param name="modelBuilder">Modelo a asociar.</param>
        private static void EstablecerMapeoAperturaExtemporaneaPeriodos(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AperturaExtemporaneaPeriodo>()
                .ToTable("AperturaExtemporaneaPeriodos", "dbo")
                .HasKey(e => e.Id);

            modelBuilder.Entity<AperturaExtemporaneaPeriodo>()
                .HasRequired<PeriodoParametrizacion>(e => e.PeriodoParametrizacion)
                .WithMany(e => e.AperturaExtemporaneaPeriodos)
                .HasForeignKey(e => e.IdPeriodo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AperturaExtemporaneaPeriodo>()
                .Property(e => e.MotivoApertura)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<AperturaExtemporaneaPeriodo>()
                .Property(e => e.FechaInicial)
                .HasColumnType("date")
                .IsRequired();

            modelBuilder.Entity<AperturaExtemporaneaPeriodo>()
                .Property(e => e.FechaFinal)
                .HasColumnType("date")
                .IsRequired();
        }

        /// <summary>
        /// Configura la estructura de la entidad ParametrosNegocio.
        /// </summary>
        /// <param name="modelBuilder">Modelo a asociar.</param>
        public static void EstablecerMapeoParametrosNegocio(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ParametrosNegocio>()
               .ToTable("ParametrosNegocio", "dbo")
               .HasKey(e => e.Nombre);

            modelBuilder.Entity<ParametrosNegocio>()
              .Property(e => e.Nombre)
              .IsUnicode(false);

            modelBuilder.Entity<ParametrosNegocio>()
                .Property(e => e.Valor)
                .IsUnicode(false);
        }

        /// <summary>
        /// Configura la estructura de la entidad UsuariosEstado.
        /// </summary>
        /// <param name="modelBuilder">Modelo a asociar.</param>
        public static void EstablecerMapeoEstadoUsuario(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsuariosEstado>()
               .ToTable("UsuariosEstado", "dbo")
               .HasKey(e => e.Id);

            modelBuilder.Entity<UsuariosEstado>()
               .Property(e => e.Descripcion)
               .IsUnicode(false);

            modelBuilder.Entity<UsuariosEstado>()
                .HasMany(e => e.Usuarios)
                .WithRequired(e => e.UsuariosEstado)
                .HasForeignKey(e => e.IdEstado)
                .WillCascadeOnDelete(false);
        }

        /// <summary>
        /// Configura la estructura de la entidad GruposPorGrado.
        /// </summary>
        /// <param name="modelBuilder">Modelo a asociar.</param>
        private static void EstablecerMapeoGruposPorGrado(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GruposPorGrado>()
               .ToTable("GruposPorGrado", "dbo")
               .HasKey(e => e.Id);

            modelBuilder.Entity<GruposPorGrado>()
               .HasRequired<Maestro>(e => e.Grado)
               .WithMany(e => e.GradosGrupo)
               .HasForeignKey(e => e.IdGrado)
               .WillCascadeOnDelete(false);

            modelBuilder.Entity<GruposPorGrado>()
               .HasRequired<Maestro>(e => e.Grupo)
               .WithMany(e => e.Grupos)
               .HasForeignKey(e => e.IdGrupo)
               .WillCascadeOnDelete(false);
        }

        #endregion Cofiguración de tablas
    }
}
