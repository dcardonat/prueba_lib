namespace Libellus.Repositorio.Contextos
{
    using Libellus.Entidades;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity;

    /// <summary>
    /// 
    /// </summary>
    public class LibellusSeguridadDbContext : IdentityDbContext<ApplicationUser>
    {
          #region Constructores

        /// <summary>
        /// Inicializa una nueva instancia de tipo LibellusDbContext.
        /// </summary>
        public LibellusSeguridadDbContext()
            : base("name=LibellusSeguridadDbContext")
        {
            //// Se establece el inicializador de la base de datos a null para usar Code First con una base de datos ya existente.
            Database.SetInitializer<LibellusSeguridadDbContext>(null);
            Configuration.ProxyCreationEnabled = false;
        }

        /// <summary>
        /// Inicializa una nueva instancia de tipo LibellusDbContext con la cadena de conexión de la DB a trabajar.
        /// </summary>
        /// <param name="cadenaConexion">Cadena de conexión con la que se trabajará.</param>
        public LibellusSeguridadDbContext(string cadenaConexion)
            : base(cadenaConexion)
        {
            //// Se establece el inicializador de la base de datos a null para usar Code First con una base de datos ya existente.
            Database.SetInitializer<LibellusSeguridadDbContext>(null);
            Configuration.ProxyCreationEnabled = false;
        }

        #endregion Constructores

        #region Propiedades

        /// <summary>
        /// Define la información de la tabla ActividadesComplementarias.
        /// </summary>
        public virtual DbSet<ActividadComplementaria> ActividadesComplementarias { get; set; }

        /// <summary>
        /// Obtiene o establece la informacion de la tabla Asignaturas.
        /// </summary>
        public virtual DbSet<Asignatura> Asignaturas { get; set; }

        /// <summary>
        /// Obtiene o establece la informacion de la tabla Aulas.
        /// </summary>
        public virtual DbSet<Aula> Aulas { get; set; }

        /// <summary>
        /// Obtiene o establece la informacion de la tabla Funcionalidades.
        /// </summary>
        public virtual DbSet<Funcionalidad> Funcionalidades { get; set; }

        /// <summary>
        /// Define la información de la tabla Maestros.
        /// </summary>
        public virtual DbSet<Maestro> Maestros { get; set; }

        /// <summary>
        /// Define la informacion de la tabla Roles.
        /// </summary>
        public virtual DbSet<Rol> Roles { get; set; }

        /// <summary>
        /// Obtiene o establece la informacion de la tabla RolesFuncionalidades.
        /// </summary>
        public virtual DbSet<RolFuncionalidad> RolesFuncionalidades { get; set; }

        /// <summary>
        /// Define la información de la tabla Sedes.
        /// </summary>
        public virtual DbSet<Sede> Sedes { get; set; }

        /// <summary>
        /// Define la información de la tabla TipoMaestros.
        /// </summary>
        public virtual DbSet<TipoMaestro> TipoMaestros { get; set; }

        /// <summary>
        /// Define la informacion de la tabla TiposFuncionalidades.
        /// </summary>
        public virtual DbSet<TipoFuncionalidad> TiposFuncionalidades { get; set; }

        /// <summary>
        /// Define la información de la tabla Usuarios.
        /// </summary>
        public virtual DbSet<Usuario> Usuario { get; set; }

        /// <summary>
        /// Obtiene o establece la informacion de la tabla UsuariosRol.
        /// </summary>
        public virtual DbSet<UsuarioRol> UsuarioRol { get; set; }

        #endregion Propiedades

        #region Eventos

        /// <summary>
        /// Injecta las configuraciones de las entidades en el modelo de la DB Libellus.
        /// </summary>
        /// <param name="modelBuilder">Modelo a configurar.</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            this.ConfigurarSedes(modelBuilder);
            this.ConfigurarUsuarios(modelBuilder);
            this.ConfigurarFuncionalidades(modelBuilder);
            this.ConfigurarRoles(modelBuilder);
            this.ConfigurarTiposFuncionalidades(modelBuilder);
        }

        #endregion Eventos

        #region Métodos privados

        /// <summary>
        /// Configura la estructura de la entidad Funcionalidades.
        /// </summary>
        /// <param name="modelBuilder">Modelo a asociar.</param>
        protected void ConfigurarFuncionalidades(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Funcionalidad>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Funcionalidad>()
                .Property(e => e.Descripcion)
                .IsFixedLength();

            modelBuilder.Entity<Funcionalidad>()
                .Property(e => e.Accion)
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
        /// Configura la estructura de la entidad Roles.
        /// </summary>
        /// <param name="modelBuilder">Modelo a asociar.</param>
        protected void ConfigurarRoles(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rol>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Rol>()
                .HasMany(e => e.RolesFuncionalidades)
                .WithOptional(e => e.Rol)
                .HasForeignKey(e => e.IdRol);

            modelBuilder.Entity<Rol>()
                .HasMany(e => e.UsuariosRoles)
                .WithRequired(e => e.Roles)
                .HasForeignKey(e => e.IdRol)
                .WillCascadeOnDelete(false);
        }

        /// <summary>
        /// Configura la estructura de la entidad Sedes.
        /// </summary>
        /// <param name="modelBuilder">Modelo a asociar.</param>
        protected void ConfigurarSedes(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sede>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Sede>()
                .HasMany(e => e.Maestros)
                .WithRequired(e => e.Sede)
                .HasForeignKey(e => e.IdSede)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sede>()
                .HasOptional(e => e.Rol)
                .WithRequired(e => e.Sede);

            modelBuilder.Entity<Sede>()
                .HasMany(e => e.UsuariosRoles)
                .WithRequired(e => e.Sede)
                .HasForeignKey(e => e.IdSede)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sede>()
                .HasMany(e => e.ActividadesComplementarias)
                .WithRequired(e => e.Sede)
                .HasForeignKey(e => e.IdSede)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sede>()
                .HasMany(e => e.Aulas)
                .WithRequired(e => e.Sede)
                .HasForeignKey(e => e.IdSede)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sede>()
                .HasMany(e => e.Asignaturas)
                .WithRequired(e => e.Sede)
                .HasForeignKey(e => e.IdSede)
                .WillCascadeOnDelete(false);
        }

        /// <summary>
        /// Configura la estructura de la entidad TipoFuncionalidad.
        /// </summary>
        /// <param name="modelBuilder">Modelo a asociar.</param>
        protected void ConfigurarTiposFuncionalidades(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TipoFuncionalidad>()
             .Property(e => e.Nombre)
             .IsUnicode(false);

            modelBuilder.Entity<TipoFuncionalidad>()
                .HasMany(e => e.Funcionalidades)
                .WithOptional(e => e.TipoFuncionalidad)
                .HasForeignKey(e => e.IdTipo);
        }

        /// <summary>
        /// COnfigurar la estructura de la entidad Usuarios.
        /// </summary>
        /// <param name="modelBuilder">Modelo a asociar.</param>
        protected void ConfigurarUsuarios(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>()
               .Property(e => e.Login)
               .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Contrasena)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.UsuariosRoles)
                .WithRequired(e => e.Usuarios)
                .HasForeignKey(e => e.IdUsuario)
                .WillCascadeOnDelete(false);
        }

        #endregion Métodos privados


        /// <summary>
        /// Configurar la estructura del AplicationUser
        /// </summary>
        /// <param name="modelBuilder">Modelo a asociar.</param>
        protected void ConfigurarAplicationUser(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            ///base.OnModelCreating(modelBuilder);

            var identityUser = modelBuilder.Entity<ApplicationUser>().ToTable("dbo.Usuarios");
            identityUser.Property(p => p.Id).HasColumnName("Id");
            identityUser.Property(p => p.PasswordHash).HasColumnName("Contrasena");
            identityUser.Property(p => p.UserName).HasColumnName("Login");
            //identityUser.Property(p => p.SecurityStamp).HasColumnName("FirmaDeSeguridad");

            modelBuilder.Entity<ApplicationUser>().ToTable("dbo.Usuarios");
            modelBuilder.Entity<IdentityUserRole>().ToTable("dbo.UsuariosRoles");
            //modelBuilder.Entity<IdentityUserLogin>().ToTable("UsuariosXLogin");

            var identityRole = modelBuilder.Entity<IdentityRole>().ToTable("dbo.Roles");
            identityRole.Property(p => p.Name).HasColumnName("Nombre");

            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
        }
    }
}
