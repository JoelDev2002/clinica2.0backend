public interface ICitaService
{
  CitaResponse GetCitaById(long id);
  List<CitaResponse> GetAllCitas();
  CitaResponse CreateCita(CitaRequest citaRequest);
  // CitaResponse UpdateCita(long id, CitaRequest citaRequest);
  CitaResponse CompleteCita(long id, CitaCompletadaRequest citaRequest);
  CitaResponse ReprogramarCita(long id, ReprogramarCitaRequest cita);
  void DeleteCita(long id);
}