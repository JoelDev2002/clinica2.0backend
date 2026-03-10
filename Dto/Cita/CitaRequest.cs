using System.ComponentModel.DataAnnotations;

public class CitaRequest
{
  [Required (ErrorMessage = "El nombre es obligatorio")]
  public string TipoCita { get; set; }="";

  [Required(ErrorMessage = "La fecha es obligatorio")]
  [DataType(DataType.DateTime, ErrorMessage = "La fecha debe ser una fecha válida")]
  public DateTime Fecha { get; set; } //ejemplo de fecha: 2024-06-30T14:30:00

  [Required(ErrorMessage = "El id del paciente es obligatorio")]
  public long PacienteId { get; set; }

  [Required(ErrorMessage = "El id del medico es obligatorio")]
  public long MedicoId { get; set; }
}