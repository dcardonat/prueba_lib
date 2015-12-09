namespace Libellus.Web.Areas.Administracion.Models.Docente
{
    using System.Collections.Generic;

    /// <summary>
    /// Define la información del docente para ser administrada en las vistas de creación y edición.
    /// </summary>
    public class DocenteViewModel
    {
        /// <summary>
        /// Inicializa una nueva instancia de tipo DocenteViewModel.
        /// </summary>
        public DocenteViewModel()
        {
            this.DatosPersonales = new DatosPersonalesViewModel();
            this.DatosResidenciales = new DatosResidencialesViewModel();
            this.EstudiosRealizados = new List<EstudiosRealizadosViewModel>();
            this.ExperienciaDocente = new List<ExperienciaDocenteViewModel>();
            this.EstadoHorario = new EstadoHorarioViewModel();
            this.DocumentosSoporte = new List<DocumentosSoporteViewModel>();
        }

        /// <summary>
        /// Obtiene o establece el identificador interno del docente.
        /// </summary>
        public int IdDocente { get; set; }

        /// <summary>
        /// Obtiene o establece la información de los datos personales del docente.
        /// </summary>
        public DatosPersonalesViewModel DatosPersonales { get; set; }

        /// <summary>
        /// Obtiene o establece la información de los datos residenciales del docente.
        /// </summary>
        public DatosResidencialesViewModel DatosResidenciales { get; set; }

        /// <summary>
        /// Obtiene o establece la información de los estudios realizados del docente.
        /// </summary>
        public List<EstudiosRealizadosViewModel> EstudiosRealizados { get; set; }

        /// <summary>
        /// Obtiene o establece la información de la experiencia laboral del docente.
        /// </summary>
        public List<ExperienciaDocenteViewModel> ExperienciaDocente { get; set; }

        /// <summary>
        /// Obtiene o establece la información de los datos de estado en el sistema y horario del docente.
        /// </summary>
        public EstadoHorarioViewModel EstadoHorario { get; set; }

        /// <summary>
        /// Obtiene o establece la información de los documentos de soporte asociados al docente.
        /// </summary>
        public List<DocumentosSoporteViewModel> DocumentosSoporte { get; set; }
    }
}