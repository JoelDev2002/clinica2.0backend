public class CitaResponse
{
  public long CitaId { get; set; }
  public string TipoCita { get; set; }="";
  public DateTime Fecha { get; set; }
  public string Estado { get; set; }="";
  public string MedicoNombre { get; set; }="";
  public string PacienteNombre { get; set; }="";
  public string Obervaciones { get; set; }="";
  public string Receta { get; set; }="";
}