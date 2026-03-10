using System.ComponentModel.DataAnnotations;

public class PacienteRequest
{
  [Required (ErrorMessage ="El campo nombre es obligatorio")]
  [StringLength(100, ErrorMessage = "El campo nombre no puede tener más de 100 caracteres")]
  public string Nombre{get;set;}="";

  [Required (ErrorMessage ="El campo edad es obligatorio")]
  [Range(0, 120, ErrorMessage = "El campo edad debe estar entre 0 y 120")]
  public int Edad{get;set;}

  [Required (ErrorMessage ="El campo contacto es obligatorio")]
  [Phone(ErrorMessage = "El campo contacto debe ser un número de teléfono válido")]
  public string Contacto{get;set;}=""; //ejemplo peruano: +51 987654321
}