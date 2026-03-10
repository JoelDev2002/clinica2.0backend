using System.ComponentModel.DataAnnotations;

public class ReprogramarCitaRequest
    {
        [Required(ErrorMessage ="La fecha es obligatoria")]
        [DataType(DataType.DateTime, ErrorMessage = "La fecha debe ser una fecha válida")]
        public DateTime NuevaFecha { get; set; }
    }