public interface IPacienteService
{
    PacienteResponse createPaciente(PacienteRequest pacienteRequest);
    PacienteResponse updatePaciente(long id, PacienteRequest pacienteRequest);
    PacienteResponse getPacienteById(long id);
    List<PacienteResponse> getPacientes();
    void deletePaciente(long id);
}