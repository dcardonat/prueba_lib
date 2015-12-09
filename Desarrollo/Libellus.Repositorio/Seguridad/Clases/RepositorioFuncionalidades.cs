namespace Libellus.Repositorio.Seguridad
{
    using Libellus.Entidades;
    using Libellus.Repositorio.Base;
    using Libellus.Repositorio.Contextos;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;

    /// <summary>
    /// Define la clase para la persistencia con la DB de Libellus central para los parametros de Funcionalidades.
    /// </summary>
    public class RepositorioFuncionalidades : RepositorioBase<Funcionalidad>, IRepositorioFuncionalidades
    {
        #region Constructores

        /// <summary>
        /// Inicializa una nueva instancia de tipo RepositorioFuncionalidades con el DbContext a trabajar.
        /// </summary>
        /// <param name="contextoLibellus">DbContext a trabajar.</param>
        public RepositorioFuncionalidades(LibellusDbContext contextoLibellus)
        {
            this.ContextoLibellus = contextoLibellus;
        }

        #endregion Constructores

        #region Metodos

        /// <summary>
        /// Consulta todas las funcionalidades del sistema.
        /// </summary>
        /// <returns>IEnumerable de Funcionalidade.</returns>
        public IEnumerable<Funcionalidad> ConsultarFuncionalidades()
        {
            return ContextoLibellus.Funcionalidades;
        }

        /// <summary>
        /// Consulta una funcionalidad especifica.
        /// </summary>
        /// <param name="idFuncionalidad">Identificador de la funcionalidad.</param>
        /// <returns>Retorna una funcionalidad especifica.</returns>
        public Funcionalidad ConsultarFuncionalidad(decimal idFuncionalidad)
        {
            return this.ContextoLibellus.Funcionalidades.Find(idFuncionalidad);
        }

        /// <summary>
        /// Conlusta una funcionalidad por medio de una Url ralativa Ej:/controller/action.
        /// </summary>
        /// <param name="urlRelativa">Ej:/controller/action.</param>
        /// <returns>Objeto Funcionalidade.</returns>
        public Funcionalidad ConsultarFuncionalidadPorUrl(string urlRelativa)
        {
            urlRelativa = urlRelativa.TrimEnd('/').ToLower();
            Funcionalidad funcionalidad = this.ContextoLibellus.Funcionalidades.FirstOrDefault(f => f.Url.ToLower() == urlRelativa && f.Categoria == ConstantesMenu.TipoMenuAccion);
            return funcionalidad;
        }

        /// <summary>
        /// Retorna una collección de funcionalidades para un nombre de rol determinado
        /// </summary>
        /// <param name="nombreRol">Nombre del rol.</param>
        public IEnumerable<Funcionalidad> ConsultarFuncionalidadesPorRol(int id)
        {
            Rol rol = ContextoLibellus.Roles.Single(u => u.Id == id);
            IEnumerable<RolesFuncionalidades> rolesFuncionalidades = rol.RolesFuncionalidades.ToList();
            var consulta = (from p in rolesFuncionalidades select p.Funcionalidad).ToList();
            return consulta;
        }

        /// <summary>
        /// Verifica si un usuario esta autorizado para acceder a una URL determinada.
        /// </summary>
        /// <param name="urlRelativa">Url para verificar su acceso.</param>
        /// <param name="usuario">Nombre de usuario de red.</param>
        /// <returns>retorna el resultado de la validación.</returns>
        public bool ValidarAcceso(string urlRelativa, string usuario, int idSede)
        {
            bool respuesta = false;
            var funcionalidad = this.ConsultarFuncionalidadPorUrl(urlRelativa);

            if (funcionalidad != null)
            {
                var funcionalidadesUsuario = this.ConsultarFuncionalidadesPorUsuario(usuario, idSede);
                respuesta = funcionalidadesUsuario.Any(fn => fn.Id == funcionalidad.Id && fn.Estado == true);
            }

            return respuesta;

        }

        /// <summary>
        /// Retorna una collección de las funcionalidades asociadas a un usuario.
        /// </summary>
        /// <param name="usuario">Nombre  de usuario.</param>
        /// <returns>IEnumerable de tipo Funcionalidade.</returns>
        public IEnumerable<Funcionalidad> ConsultarFuncionalidadesPorUsuario(string usuario, int idSede)
        {
            int idRol = 0;
            List<Funcionalidad> funcionalidadesUsuario = new List<Funcionalidad>();
            var usuarioConsultado = ContextoLibellus.Usuario.Include(u => u.UsuariosRoles).SingleOrDefault(u => u.NombreUsuario == usuario);

            if (usuarioConsultado != null)
            {
                idRol = usuarioConsultado.UsuariosRoles.Where(x => x.IdSede == idSede).Select(r => r.IdRol).FirstOrDefault();
            }

            funcionalidadesUsuario =
                               (from f in ContextoLibellus.Funcionalidades
                                where (
                                from e in f.RolesFuncionalidades
                                where idRol == e.Rol.Id
                                select e
                                ).Any()
                                orderby f.OrdenMenu ascending
                                select f).ToList();
            return funcionalidadesUsuario;
        }

        /// <summary>
        /// Retorna la colección de items para el menu de la aplicación asociados a un usuario.
        /// </summary>
        /// <param name="usuario">Nombre  de usuario.</param>
        /// <param name="idSede">Identificador de la sede.</param>
        /// <returns>IEnumerable de tipo Funcionalidade.</returns>
        public IEnumerable<Funcionalidad> ConsultarMenuItemsPorUsuario(string usuario, int idSede)
        {
            List<string> idsRoles = new List<string>();
            List<Funcionalidad> funcionalidadesUsuario = new List<Funcionalidad>();
            var usuarioConsultado = ContextoLibellus.UsuariosRoles.Where(x => x.IdSede == idSede).Include(u => u.Rol).SingleOrDefault(u => u.Usuario.NombreUsuario == usuario);

            if (usuarioConsultado != null)
            {
                var rol = usuarioConsultado.Rol;
                idsRoles.Add(rol.Id.ToString());
            }

            if (idsRoles.Count() > 0)
            {
                funcionalidadesUsuario = ConsultarMenuItemsPorRoles(idsRoles).ToList();
            }

            return funcionalidadesUsuario;
        }

        /// <summary>
        /// Retorna una colección de items para el menu de la aplicación, para una lista de IDs de roles determinada.
        /// </summary>
        /// <param name="idsRoles">Lista IDs de roles.</param>
        /// <returns>IEnumerable Funcionalidade.</returns>
        private IEnumerable<Funcionalidad> ConsultarMenuItemsPorRoles(List<string> idsRoles)
        {
            var menuItems =
             from f in ContextoLibellus.Funcionalidades
             where (from e in f.RolesFuncionalidades where idsRoles.Contains(e.Rol.Id.ToString()) select e).Any()
             && f.Categoria == ConstantesMenu.CategoriaFuncionalidadMenu
             orderby f.OrdenMenu ascending
             select f;

            var menuItemsRoles = AgregarPadres(ContextoLibellus.Funcionalidades.ToList(), menuItems.ToList());
            return menuItemsRoles.OrderBy(mi => mi.OrdenMenu).ToList();
        }

        /// <summary>
        /// Adiciona los items padres de una funcionalidad necesarios para mostrar correctamente las opciones del menu del sistema.
        /// </summary>
        /// <param name="listaFuncionalidades">Lista de Funcionalidades del sistema.</param>
        /// <param name="menuItems">Funcionalidades del sistema categoria 'menu'.</param>
        /// <param name="menuItemHijo">Elemneto al cual se le buscara el padre para adicionarlo a la colección de items del menu.</param>
        /// <returns>Lista de Funcionalidades.</returns>
        private List<Funcionalidad> AgregarPadres(IEnumerable<Funcionalidad> listaFuncionalidades, List<Funcionalidad> menuItems, Funcionalidad menuItemHijo = null)
        {
            if (menuItemHijo == null)
            {
                var menuItemsHijos = menuItems.Where(mi => mi.IdPadre != null).ToList();

                foreach (var item in menuItemsHijos)
                {
                    var tienePadre = menuItems.Any(f => f.Id == item.IdPadre);
                    if (!tienePadre)
                    {
                        menuItems = AgregarPadres(listaFuncionalidades, menuItems, item);
                    }
                }
                return menuItems;
            }
            else
            {
                var padre = listaFuncionalidades.FirstOrDefault(i => i.Id == menuItemHijo.IdPadre);
                if (padre != null)
                {
                    menuItems.Add(padre);
                    var tienePadre = menuItems.Any(f => f.Id == padre.IdPadre);
                    if (!tienePadre)
                    {
                        menuItems = AgregarPadres(listaFuncionalidades, menuItems, padre);
                    }

                }
                return menuItems;
            }
        }

        #endregion
    }
}
