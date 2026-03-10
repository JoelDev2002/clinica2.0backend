public interface ICitaBd
{
  Cita CreateCita(Cita cita);
  List<Cita> GetCitas();
  Cita GetCitaById(long id);
  Cita UpdateCita(long id,Cita cita);
  void DeleteCita(long id);
}