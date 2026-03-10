public interface IPacienteBd
{
  List<Paciente> GetPacientes();
  Paciente GetPacienteById(long id);
  Paciente CreatePaciente(Paciente paciente);
  Paciente UpdatePaciente(long id, Paciente paciente);
  void DeletePaciente(long id);
}