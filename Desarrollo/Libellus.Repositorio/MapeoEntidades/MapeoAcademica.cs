namespace Libellus.Repositorio.MapeoEntidades
{
    using Libellus.Entidades;
    using System.Data.Entity;

    /// <summary>
    /// Establece el mapeo de la estructura de las entidades del módulo gestion academica en el modelo de LibellusDbContext.
    /// </summary>
    public static class MapeoAcademica
    {
        #region Metodos Publicos

        /// <summary>
        /// Establece el mapeo de las entidades del módulo Activaciones 4G.
        /// </summary>
        /// <param name="modelBuilder">Modelo a mapear.</param>
        public static void EstablecerMapeo(DbModelBuilder modelBuilder)
        {
            EstablecerMapeoRangosDesempenio(modelBuilder);
            EstablecerMapeoAspectosEvaluativos(modelBuilder);
            EstablecerMapeoParametrosPromocion(modelBuilder);
            EstablecerMapeoGrupos(modelBuilder);
            EstablecerMapeoEstudiantesGrupos(modelBuilder);
        }

        #endregion

        # region Configuracion de tablas

        /// <summary>
        /// Configura la estructura de la entidad RangosDesempenio.
        /// </summary>
        /// <param name="modelBuilder">Modelo a asociar.</param>
        private static void EstablecerMapeoRangosDesempenio(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RangosDesempenio>()
              .ToTable("RangosDesempenio", "dbo")
              .HasKey(e => e.Id);

            modelBuilder.Entity<RangosDesempenio>()
                .HasRequired<Maestro>(e => e.DesempenioEvaluativo)
                .WithMany(e => e.RangoDesempenio)
                .HasForeignKey(e => e.IdDesempenio)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RangosDesempenio>()
                .HasRequired<Sede>(e => e.Sede)
                .WithMany(e => e.RangoDesempenio)
                .HasForeignKey(e => e.IdSede)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RangosDesempenio>()
              .HasRequired<AnioLectivo>(e => e.AnioLectivo)
              .WithMany(e => e.RangosDesempenio)
              .HasForeignKey(e => e.IdAnioLectivo)
              .WillCascadeOnDelete(false);
        }

        /// <summary>
        /// Configura la estructura de la entidad AspectosEvaluativos.
        /// </summary>
        /// <param name="modelBuilder">Modelo a asociar.</param>
        private static void EstablecerMapeoAspectosEvaluativos(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspectoEvaluativo>()
               .ToTable("AspectosEvaluativos", "dbo")
               .HasKey(e => e.Id);

            modelBuilder.Entity<AspectoEvaluativo>()
                 .HasRequired<Maestro>(e => e.Evaluativo)
                 .WithMany(e => e.AspectosEvaluativos)
                 .HasForeignKey(e => e.IdAspectoEvaluativo)
                 .WillCascadeOnDelete(false);

            modelBuilder.Entity<AspectoEvaluativo>()
                 .HasRequired<Maestro>(e => e.IntensidadHoraria)
                 .WithMany(e => e.IntensidadHoraria)
                 .HasForeignKey(e => e.IdIntensidadHoraria)
                 .WillCascadeOnDelete(false);

            modelBuilder.Entity<AspectoEvaluativo>()
                .Property(e => e.Porcentaje)
                .IsRequired();

            modelBuilder.Entity<AspectoEvaluativo>()
                .HasRequired<Sede>(e => e.Sede)
                .WithMany(e => e.AspectosEvaluativos)
                .HasForeignKey(e => e.IdSede)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AspectoEvaluativo>()
                .HasRequired<AnioLectivo>(e => e.AnioLectivo)
                .WithMany(e => e.AspectosEvaluativos)
                .HasForeignKey(e => e.IdAnioLectivo)
                .WillCascadeOnDelete(false);
        }

        /// <summary>
        /// Configura la estructura de la entidad ParametrosPromocion.
        /// </summary>
        /// <param name="modelBuilder">Modelo a asociar.</param>
        private static void EstablecerMapeoParametrosPromocion(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ParametroPromocion>()
                .ToTable("ParametrosPromocion", "dbo")
                .HasKey(e => e.Id);

            modelBuilder.Entity<ParametroPromocion>()
                 .HasRequired<Maestro>(e => e.EvaluacionAprendizaje)
                 .WithMany(e => e.ParametrosPromocion)
                 .HasForeignKey(e => e.IdEvaluacionAprendizaje)
                 .WillCascadeOnDelete(false);

            modelBuilder.Entity<ParametroPromocion>()
                .HasRequired<Maestro>(e => e.CalificacionMaxima)
                .WithMany(e => e.CalificacionMaxima)
                .HasForeignKey(e => e.IdCalificacionMaxima)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ParametroPromocion>()
               .HasRequired<Maestro>(e => e.CalificacionMinima)
               .WithMany(e => e.CalificacionMinima)
               .HasForeignKey(e => e.IdCalificacionMinima)
               .WillCascadeOnDelete(false);

            modelBuilder.Entity<ParametroPromocion>()
                .HasRequired<Sede>(e => e.Sede)
                .WithMany(e => e.ParametrosPromocion)
                .HasForeignKey(e => e.IdSede)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ParametroPromocion>()
                .Property(e => e.MinimoAreasReprobadas)
                .IsRequired();

            modelBuilder.Entity<ParametroPromocion>()
                .Property(e => e.MaximoAreasMejoramiento)
                .IsRequired();

            modelBuilder.Entity<ParametroPromocion>()
                .Property(e => e.MinimoAreaReprobacion)
                .IsRequired();

            modelBuilder.Entity<ParametroPromocion>()
            .HasRequired<AnioLectivo>(e => e.AnioLectivo)
            .WithMany(e => e.ParametrosPromocion)
            .HasForeignKey(e => e.IdAnioLectivo)
            .WillCascadeOnDelete(false);
        }

        /// <summary>
        /// Configura la estructura de la entidad Grupos.
        /// </summary>
        /// <param name="modelBuilder">Modelo a asociar.</param>
        private static void EstablecerMapeoGrupos(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Grupo>()
              .ToTable("Grupos", "dbo")
              .HasKey(e => e.Id);

            modelBuilder.Entity<Grupo>()
            .HasRequired<AnioLectivo>(e => e.AnioLectivo)
            .WithMany(e => e.Grupos)
            .HasForeignKey(e => e.IdAnioLectivo)
            .WillCascadeOnDelete(false);

            modelBuilder.Entity<Grupo>()
           .HasRequired<GruposPorGrado>(e => e.GruposPorGrado)
           .WithMany(e => e.Grupos)
           .HasForeignKey(e => e.IdGrupoPorGrado)
           .WillCascadeOnDelete(false);

            modelBuilder.Entity<Grupo>()
           .HasRequired<Maestro>(e => e.Horario)
           .WithMany(e => e.Horarios)
           .HasForeignKey(e => e.IdHorario)
           .WillCascadeOnDelete(false);

            modelBuilder.Entity<Grupo>()
          .HasMany(e => e.EstudiantesPorGrupo)
          .WithRequired(e => e.Grupo)
          .HasForeignKey(e => e.IdGrupo)
          .WillCascadeOnDelete(false);
        }

        /// <summary>
        /// Configura la estructura de la entidad EstudiantesPorGrupo.
        /// </summary>
        /// <param name="modelBuilder">Modelo a asociar.</param>
        private static void EstablecerMapeoEstudiantesGrupos(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EstudiantePorGrupo>()
              .ToTable("EstudiantesPorGrupo", "dbo")
              .HasKey(e => e.Id);

            modelBuilder.Entity<EstudiantePorGrupo>()
                .HasRequired<EstudianteDatosPersonales>(e => e.Estudiante)
                .WithMany(e => e.EstudiantesPorGrupo)
                .HasForeignKey(e => e.IdEstudiante)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EstudiantePorGrupo>()
                .HasRequired<Grupo>(e => e.Grupo)
                .WithMany(e => e.EstudiantesPorGrupo)
                .HasForeignKey(e => e.IdGrupo)
                .WillCascadeOnDelete(false);
        }

        #endregion
    }
}
