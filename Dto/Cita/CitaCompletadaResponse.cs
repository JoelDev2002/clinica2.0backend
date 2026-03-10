public class CitaCompletadaResponse
{
  public int Id { get; set; }
  public string TipoCita { get; set; }="";
  public DateTime Fecha { get; set; }
  public int MedicoNombre { get; set; }
  public int PacienteNombre { get; set; }
  public string Observaciones { get; set; }="";
  public string Receta { get; set; }="";
}