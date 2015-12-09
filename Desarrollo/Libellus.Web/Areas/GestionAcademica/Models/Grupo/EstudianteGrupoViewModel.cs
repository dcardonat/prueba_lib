namespace Libellus.Web.Areas.GestionAcademica.Models.Grupo
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using Libellus.Mensajes;

    /// <summary>
    /// View model para la administración de estudiantes por grupo.
    /// </summary>
    public class EstudianteGrupoViewModel
    {
        /// <summary>
        /// Inicializa una instancia de la clase EstudianteGrupoViewModel.
        /// </summary>
        public EstudianteGrupoViewModel()
        {
            this.DistribucionEstudiantesGrupo = new List<DistribucionEstudianteGrupoViewModel>();
        }

        /// <summary>
        /// Obtiene o establece el año para la configuración.
        /// </summary>
        [Display(Name = "Año")]
        public int IdAnioLectivo { get; set; }

        /// <summary>
        /// Obtiene o establece el nivel educativo.
        /// </summary>
        [Display(Name = "Nivel")]
        public int IdNivel { get; set; }

        /// <summary>
        /// Obtiene o establece la información de los niveles educativos.
        /// </summary>
        public IEnumerable<SelectListItem> Niveles { get; set; }        

        /// <summary>
        /// Obtiene o establece la distribución de grupos por grupo.
        /// </summary>
        public IList<DistribucionEstudianteGrupoViewModel> DistribucionEstudiantesGrupo { get; set; }
    }
}