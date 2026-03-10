public class Cita
{
  public long CitaId { get; set; }
  public string TipoCita { get; set; }="";
  public DateTime Fecha { get; set; }
  public string Observaciones { get; set; }="";
  public string Receta { get; set; }="";
  public string Estado { get; set; }="";
  public long PacienteId { get; set; }
  public long MedicoId { get; set; }
}