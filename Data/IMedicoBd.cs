public interface IMedicoBd
{
  List<Medico> GetMedicos();
  Medico GetMedicoById(long id);
  Medico CreateMedico(Medico medico);
  Medico UpdateMedico(long id, Medico medico);
  void DeleteMedico(long id);
}