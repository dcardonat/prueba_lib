namespace Libellus.Web.Areas.GestionAcademica.Models.Grupo
{
    using PagedList;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    /// <summary>
    /// View model para la distribución de estudiantes por grupo.
    /// </summary>
    public class DistribucionEstudianteGrupoViewModel
    {
        /// <summary>
        /// Identificador del registro.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtiene o establece el id del nivel educativo.
        /// </summary>
        public int IdNivel { get; set; }

        /// <summary>
        /// Obtiene o establece el la salida ocupacional o profundización.
        /// </summary>
        public int IdActividadComplementaria { get; set; }

        /// <summary>
        /// Obtiene o establece la descripción del nivel educativo.
        /// </summary>
        [Display(Name = "Nivel")]
        public string Nivel { get; set; }

        /// <summary>
        /// Obtiene o establece la cantidad de estudiantes por grupo.
        /// </summary>
        public int EstudiantesPorGrupo { get; set; }

        /// <summary>
        /// Otiene o establece la cantidad de estudiantes matriculados.
        /// </summary>
        public int EstudiantesMatriculados { get; set; }

        /// <summary>
        /// Obtiene o establece el id del grado.
        /// </summary>
        public int IdGrado { get; set; }

        /// <summary>
        /// Obtiene o establece la descripción del grado.
        /// </summary>
        public string Grado { get; set; }

        /// <summary>
        /// Obtiene o establece el id del grupo.
        /// </summary>
        public int IdGrupo { get; set; }

        /// <summary>
        /// Obtiene o establece la descripción del grupo.
        /// </summary>
        [Display(Name = "Grupo")]
        public string Grupo { get; set; }

        /// <summary>
        /// Obtiene o establece la información de los grupos por grado.
        /// </summary>
        public IList<SelectListItem> Grupos { get; set; }

        /// <summary>
        /// Obtiene o establece el id del horario.
        /// </summary>
        public int IdHorario { get; set; }

        /// <summary>
        /// Obtiene o establece la descripción del horario.
        /// </summary>
        [Display(Name = "Horario")]
        public string Horario { get; set; }

        /// <summary>
        /// Obtiene o establece los horaios que serán asocados a un grupo.
        /// </summary>
        public IList<SelectListItem> Horarios { get; set; }

        /// <summary>
        /// Obtiene o establece la cantidad de grupos por grado.
        /// </summary>
        public int CantidadGruposPorGrado { get; set; }

        /// <summary>
        /// Obtiene o establece los estudiantes de un grupo.
        /// </summary>
        public IPagedList<EstudianteViewModel> Estudiantes { get; set; }
    }
}