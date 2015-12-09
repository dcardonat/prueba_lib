namespace Libellus.Repositorio.MapeoEntidades
{
    using Libellus.Entidades;
    using System.Data.Entity;

    /// <summary>
    /// Establece el mapeo de la estructura de las entidades del módulo de gestion de matricula en el modelo de LibellusDbContext.
    /// </summary>
    public static class MapeoMatricula
    {
        #region Métodos públicos

        /// <summary>
        /// Establece el mapeo de todas las configuraciones internas.
        /// </summary>
        /// <param name="modelBuilder">Modelo a mapear.</param>
        public static void EstablecerMapeo(DbModelBuilder modelBuilder)
        {
            EstablecerMapeoEstudiantesDatosPersonales(modelBuilder);
            EstablecerMapeoEstudiantesDatosResidenciales(modelBuilder);
            EstablecerMapeoCupos(modelBuilder);
            EstablecerMapeoEstudiantesArchivos(modelBuilder);
            EstablecerMapeoEstudiantesAntecedentesAcademicos(modelBuilder);
            EstablecerMapeoMatriculaDocumentosSoporte(modelBuilder);
            EstablecerMapeoMatriculas(modelBuilder);
            EstablecerMapeoCancelacionMatricula(modelBuilder);
            EstablecerMapeoEstudiantesDatosFamiliares(modelBuilder);
            EstablecerMapeoFamiliaresEstudiante(modelBuilder);
        }

        #endregion Métodos públicos

        #region Configuración de tablas

        /// <summary>
        /// Establece las configuraciones de la entidad para la tabla Cupos.
        /// </summary>
        /// <param name="modelBuilder">Modelo a mapear.</param>
        private static void EstablecerMapeoCupos(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cupo>()
                .ToTable("Cupos", "dbo")
                .HasKey(e => e.Id);

            modelBuilder.Entity<Cupo>()
                .HasRequired<EstudianteDatosPersonales>(e => e.Estudiante)
                .WithMany(e => e.Cupos)
                .HasForeignKey(e => e.IdEstudiante)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Cupo>()
                .HasRequired<AnioLectivo>(e => e.AnioLectivo)
                .WithMany(e => e.Cupos)
                .HasForeignKey(e => e.IdAnioLectivo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Cupo>()
                .HasRequired<GradosPorNivel>(e => e.GradoPorNivel)
                .WithMany(e => e.Cupos)
                .HasForeignKey(e => e.IdGradoPorNivel)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Cupo>()
                .HasRequired<Sede>(e => e.Sede)
                .WithMany(e => e.Cupos)
                .HasForeignKey(e => e.IdSede)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Cupo>()
                .HasRequired<Maestro>(e => e.TipoEstudiante)
                .WithMany(e => e.Cupos)
                .HasForeignKey(e => e.IdTipoEstudiante)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Cupo>()
                .HasOptional<SalidaOcupacional>(e => e.SalidaOcupacional)
                .WithMany(e => e.Cupos)
                .HasForeignKey(e => e.IdSalidaOcupacional)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Cupo>()
                .HasOptional<Maestro>(e => e.Profundizacion)
                .WithMany()
                .HasForeignKey(e => e.IdProfundizacion)
                .WillCascadeOnDelete(false);
        }

        /// <summary>
        /// Establece las configuraciones de la tabla EstudiantesDatosPersonales.
        /// </summary>
        /// <param name="modelBuilder">Modelo a mapear.</param>
        private static void EstablecerMapeoEstudiantesDatosPersonales(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EstudianteDatosPersonales>()
                .ToTable("EstudiantesDatosPersonales", "dbo")
                .HasKey(e => e.Id);

            modelBuilder.Entity<EstudianteDatosPersonales>()
                .Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<EstudianteDatosPersonales>()
                .Property(e => e.PrimerApellido)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<EstudianteDatosPersonales>()
                .Property(e => e.SegundoApellido)
                .HasMaxLength(50);

            modelBuilder.Entity<EstudianteDatosPersonales>()
                .Property(e => e.FechaNacimiento)
                .HasColumnType("date")
                .IsRequired();

            modelBuilder.Entity<EstudianteDatosPersonales>()
                .HasRequired<Usuario>(e => e.Usuario)
                .WithRequiredDependent(e => e.Estudiante);

            modelBuilder.Entity<EstudianteDatosPersonales>()
                .HasRequired<Maestro>(e => e.Sexo)
                .WithMany()
                .HasForeignKey(e => e.IdSexo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EstudianteDatosPersonales>()
                .HasOptional<Maestro>(e => e.GrupoSanguineo)
                .WithMany()
                .HasForeignKey(e => e.IdGrupoSanguineo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EstudianteDatosPersonales>()
                .HasOptional<Municipio>(e => e.MunicipioNacimiento)
                .WithMany()
                .HasForeignKey(e => e.IdMunicipioNacimiento)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EstudianteDatosPersonales>()
                .HasRequired<Maestro>(e => e.Estado)
                .WithMany()
                .HasForeignKey(e => e.IdEstado)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EstudianteDatosPersonales>()
                .Ignore(e => e.ActualizarAntecedentes);
        }

        /// <summary>
        /// Establece las configuraciones de la tabla EstudiantesDatosResidenciales.
        /// </summary>
        /// <param name="modelBuilder">Modelo a mapear.</param>
        private static void EstablecerMapeoEstudiantesDatosResidenciales(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EstudianteDatosResidenciales>()
                .ToTable("EstudiantesDatosResidenciales", "dbo")
                .HasKey(e => e.Id);

            modelBuilder.Entity<EstudianteDatosResidenciales>()
                .Property(e => e.Direccion)
                .HasMaxLength(50);

            modelBuilder.Entity<EstudianteDatosResidenciales>()
                .Property(e => e.Barrio)
                .HasMaxLength(30);

            modelBuilder.Entity<EstudianteDatosResidenciales>()
                .Property(e => e.TelefonoFijo)
                .HasMaxLength(15)
                .IsRequired();

            modelBuilder.Entity<EstudianteDatosResidenciales>()
                .Property(e => e.TelefonoMovil)
                .HasMaxLength(15);

            modelBuilder.Entity<EstudianteDatosResidenciales>()
                .HasRequired<EstudianteDatosPersonales>(e => e.DatosPersonales)
                .WithRequiredDependent(e => e.DatosResidenciales);

            modelBuilder.Entity<EstudianteDatosResidenciales>()
                .HasOptional<Municipio>(e => e.Municipio)
                .WithMany()
                .HasForeignKey(e => e.IdMunicipio)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EstudianteDatosResidenciales>()
                .HasOptional<Maestro>(e => e.Estrato)
                .WithMany()
                .HasForeignKey(e => e.IdEstrato);
        }

        /// <summary>
        /// Establece las configuraciones de la tabla EstudiantesArchivos.
        /// </summary>
        /// <param name="modelBuilder">Modelo a mapear.</param>
        private static void EstablecerMapeoEstudiantesArchivos(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EstudianteArchivo>()
                .ToTable("EstudiantesArchivos", "dbo")
                .HasKey(e => e.Id);

            modelBuilder.Entity<EstudianteArchivo>()
                .HasRequired<EstudianteDatosPersonales>(e => e.DatosPersonales)
                .WithRequiredDependent(e => e.Archivos);

            modelBuilder.Entity<EstudianteArchivo>()
                .Property(e => e.Foto)
                .HasColumnType("image");
        }

        /// <summary>
        /// Establece las configuraciones de la tabla EstudiantesAntecedentesAcademicos
        /// </summary>
        /// <param name="modelBuilder"></param>
        private static void EstablecerMapeoEstudiantesAntecedentesAcademicos(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EstudianteAntecedenteAcademico>()
                .ToTable("EstudiantesAntecedentesAcademicos")
                .HasKey(e => e.Id);

            modelBuilder.Entity<EstudianteAntecedenteAcademico>()
                .Property(e => e.InstitucionEducativa)
                .IsRequired()
                .IsUnicode(false)
                .HasMaxLength(100);

            modelBuilder.Entity<EstudianteAntecedenteAcademico>()
                .Property(e => e.Observacion)
                .HasMaxLength(600)
                .IsUnicode(false);

            modelBuilder.Entity<EstudianteAntecedenteAcademico>()
                .HasRequired<EstudianteDatosPersonales>(e => e.Estudiante)
                .WithMany(e => e.AntecedentesAcademicos)
                .HasForeignKey(e => e.IdEstudiante)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EstudianteAntecedenteAcademico>()
                .HasRequired<Maestro>(e => e.TipoInstitucion)
                .WithMany()
                .HasForeignKey(e => e.IdTipoInstitucion)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EstudianteAntecedenteAcademico>()
                .HasRequired<Maestro>(e => e.Grado)
                .WithMany()
                .HasForeignKey(e => e.IdGrado)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EstudianteAntecedenteAcademico>()
                .HasRequired<Maestro>(e => e.MotivoRetiro)
                .WithMany()
                .HasForeignKey(e => e.IdMotivoRetiro)
                .WillCascadeOnDelete(false);
        }

        /// <summary>
        /// Establece las configuraciones de la tabla Matriculas.
        /// </summary>
        /// <param name="modelBuilder"></param>
        private static void EstablecerMapeoMatriculas(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Matricula>()
               .ToTable("Matriculas", "dbo")
               .HasKey(e => e.Id);

            modelBuilder.Entity<Matricula>()
              .HasRequired<Cupo>(e => e.Cupo)
              .WithMany(e => e.Matriculas)
              .HasForeignKey(e => e.IdCupo)
              .WillCascadeOnDelete(false);

            modelBuilder.Entity<Matricula>()
             .HasRequired<Maestro>(e => e.Estado)
             .WithMany(e => e.Matriculas)
             .HasForeignKey(e => e.IdEstado)
             .WillCascadeOnDelete(false);

            modelBuilder.Entity<Matricula>()
               .HasMany(e => e.CancelacionMatricula)
               .WithRequired(e => e.Matriculas)
               .HasForeignKey(e => e.IdMatricula)
               .WillCascadeOnDelete(false);

            modelBuilder.Entity<Matricula>()
              .HasMany(e => e.MatriculasDocumentos)
              .WithRequired(e => e.Matricula)
              .HasForeignKey(e => e.IdMatricula)
              .WillCascadeOnDelete(false);
        }

        /// <summary>
        /// Establece las configuraciones de la tabla MatriculaDocumentosSoporte.
        /// </summary>
        /// <param name="modelBuilder">Modelo a mapear.</param>
        private static void EstablecerMapeoMatriculaDocumentosSoporte(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MatriculasDocumentos>()
                .ToTable("MatriculasDocumentos", "dbo")
                .HasKey(e => e.Id);

            modelBuilder.Entity<MatriculasDocumentos>()
               .HasRequired<SoportePorRolesDocumento>(e => e.SoportePorRolesDocumentos)
               .WithMany(e => e.MatriculaDocumentosSoporte)
               .HasForeignKey(e => e.IdDocumento)
               .WillCascadeOnDelete(false);
        }

        /// <summary>
        /// Establece las configuraciones de la tabla CancelacionMatriculas.
        /// </summary>
        /// <param name="modelBuilder"></param>
        private static void EstablecerMapeoCancelacionMatricula(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CancelacionMatriculas>()
                .ToTable("CancelacionMatriculas", "dbo")
                .HasKey(e => e.Id);

            modelBuilder.Entity<CancelacionMatriculas>()
                .Property(e => e.Observacion)
                .IsUnicode(false);

            modelBuilder.Entity<CancelacionMatriculas>()
            .HasRequired<Maestro>(e => e.MotivoRetiro)
            .WithMany(e => e.CancelacionMatriculas)
            .HasForeignKey(e => e.IdMotivoRetiro)
            .WillCascadeOnDelete(false);
        }

        /// <summary>
        /// Establece las configuraciones de la tabla DatosFamiliaresEstudiante.
        /// </summary>
        /// <param name="modelBuilder">Modelo a mapear.</param>
        private static void EstablecerMapeoFamiliaresEstudiante(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FamiliarEstudiante>()
                .ToTable("FamiliaresEstudiente", "dbo")
                .HasKey(e => e.Id);

            modelBuilder.Entity<FamiliarEstudiante>()
                .Property(e => e.Identificacion)
                .HasMaxLength(15)
                .IsRequired()
                .IsUnicode(false);

            modelBuilder.Entity<FamiliarEstudiante>()
                .Property(e => e.Nombres)
                .HasMaxLength(100)
                .IsRequired()
                .IsUnicode(false);

            modelBuilder.Entity<FamiliarEstudiante>()
                .Property(e => e.Direccion)
                .HasMaxLength(50)
                .IsUnicode(false);

            modelBuilder.Entity<FamiliarEstudiante>()
                .Property(e => e.Barrio)
                .HasMaxLength(30)
                .IsUnicode(false);

            modelBuilder.Entity<FamiliarEstudiante>()
                .Property(e => e.Telefono)
                .HasMaxLength(15)
                .IsRequired()
                .IsUnicode(false);

            modelBuilder.Entity<FamiliarEstudiante>()
                .Property(e => e.Celular)
                .HasMaxLength(15)
                .IsUnicode(false);

            modelBuilder.Entity<FamiliarEstudiante>()
                .Property(e => e.Correo)
                .HasMaxLength(50)
                .IsUnicode(false);

            modelBuilder.Entity<FamiliarEstudiante>()
                .HasRequired<Maestro>(e => e.TipoIdentificacion)
                .WithMany()
                .HasForeignKey(e => e.IdTipoIdentificacion)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FamiliarEstudiante>()
                .HasOptional<Municipio>(e => e.Municipio)
                .WithMany()
                .HasForeignKey(e => e.IdMunicipio)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FamiliarEstudiante>()
                .HasOptional<Maestro>(e => e.Estrato)
                .WithMany()
                .HasForeignKey(e => e.IdEstrato)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FamiliarEstudiante>()
                .HasRequired<Maestro>(e => e.NivelEscolaridad)
                .WithMany()
                .HasForeignKey(e => e.IdNivelEscolaridad)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FamiliarEstudiante>()
                .HasOptional<Maestro>(e => e.EstadoCivil)
                .WithMany()
                .HasForeignKey(e => e.IdEstadoCivil)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FamiliarEstudiante>()
                .HasOptional<Maestro>(e => e.Parentesco)
                .WithMany()
                .HasForeignKey(e => e.IdParentesco)
                .WillCascadeOnDelete(false);
        }

        /// <summary>
        /// Establece las configuraciones de la tabla FamiliaresEstudiantes.
        /// </summary>
        /// <param name="modelBuilder">Modelo a mapear.</param>
        private static void EstablecerMapeoEstudiantesDatosFamiliares(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EstudianteDatosFamiliares>()
                .ToTable("EstudiantesDatosFamiliares", "dbo")
                .HasKey(e => e.Id);

            modelBuilder.Entity<EstudianteDatosFamiliares>()
                .HasRequired<EstudianteDatosPersonales>(e => e.Estudiante)
                .WithRequiredDependent(e => e.DatosFamiliares);

            modelBuilder.Entity<EstudianteDatosFamiliares>()
                .HasOptional<FamiliarEstudiante>(e => e.Padre)
                .WithMany()
                .HasForeignKey(e => e.IdPadre)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EstudianteDatosFamiliares>()
                .HasOptional<FamiliarEstudiante>(e => e.Madre)
                .WithMany()
                .HasForeignKey(e => e.IdMadre)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EstudianteDatosFamiliares>()
                .HasRequired<FamiliarEstudiante>(e => e.Acudiente)
                .WithMany()
                .HasForeignKey(e => e.IdAcudiente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EstudianteDatosFamiliares>()
                .Ignore(e => e.TieneMadre)
                .Ignore(e => e.TienePadre);
        }

        #endregion Configuración de tablas
    }
}