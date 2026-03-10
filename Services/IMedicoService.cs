public interface IMedicoService
{
    MedicoResponse createMedico(MedicoRequest medicoRequest);
    MedicoResponse updateMedico(long id, MedicoRequest medicoRequest);
    MedicoResponse getMedicoById(long id);
    List<MedicoResponse> GetMedicos();
    void deleteMedico(long id);
}