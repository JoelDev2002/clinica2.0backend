using System.ComponentModel.DataAnnotations;

public class CitaCompletadaRequest
{
  [Required(ErrorMessage = "la observacion es obligatoria")]
  public string Observaciones { get; set; }="";

  [Required(ErrorMessage = "La receta es obligatoria")]
  public string Receta { get; set; }="";
}