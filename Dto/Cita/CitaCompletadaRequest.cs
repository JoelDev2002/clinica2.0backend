using System.ComponentModel.DataAnnotations;

public class CitaCompletadaRequest
{
  [Required(ErrorMessage = "la observacion es obligatoria")]
  [StringLength(200,MinimumLength =3,ErrorMessage ="este campo debe contener entre 3 y 200 caracteres")]
  public string Observaciones { get; set; }="";

  [Required(ErrorMessage = "La receta es obligatoria")]
  [StringLength(200,MinimumLength =3,ErrorMessage ="este campo debe contener entre 3 y 200 caracteres")]
  public string Receta { get; set; }="";
}