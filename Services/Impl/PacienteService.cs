public class PacienteService : IPacienteService
{
    private readonly IPacienteBd PacienteBd;

    public PacienteService(IPacienteBd pacienteBd)
    {
        PacienteBd = pacienteBd;
    }

    public PacienteResponse createPaciente(PacienteRequest pacienteRequest)
    {
        var isContactExisting = PacienteBd.GetPacientes()
            .Exists(p => p.Contacto == pacienteRequest.Contacto);

        if (isContactExisting) throw new ConflictException("contacto ya existente,intentar con otro");

        Paciente paciente = new Paciente
        {
            Nombre = pacienteRequest.Nombre,
            Edad = pacienteRequest.Edad,
            Contacto = pacienteRequest.Contacto
        };

        Paciente createdPaciente = PacienteBd.CreatePaciente(paciente);

        return new PacienteResponse
        {
            PacienteId = createdPaciente.PacienteId,
            Nombre = createdPaciente.Nombre,
            Edad = createdPaciente.Edad,
            Contacto = createdPaciente.Contacto
        };
    }

    public void deletePaciente(long id)
    {
        var pacienteExitsente = PacienteBd.GetPacienteById(id);

        if (pacienteExitsente == null) throw new NotFoundException("El paciente no existe");

        PacienteBd.DeletePaciente(pacienteExitsente.PacienteId);
    }

    public PacienteResponse getPacienteById(long id)
    {
        var pacienteExitsente = PacienteBd.GetPacienteById(id);

        if (pacienteExitsente == null) throw new NotFoundException("El paciente no existe");

        return new PacienteResponse
        {
            PacienteId = pacienteExitsente.PacienteId,
            Nombre = pacienteExitsente.Nombre,
            Edad = pacienteExitsente.Edad,
            Contacto = pacienteExitsente.Contacto
        };
    }

    public List<PacienteResponse> getPacientes()
    {
        return PacienteBd.GetPacientes().Select(paciente => new PacienteResponse
        {
            PacienteId = paciente.PacienteId,
            Nombre = paciente.Nombre,
            Edad = paciente.Edad,
            Contacto = paciente.Contacto
        }).ToList();
    }

    public PacienteResponse updatePaciente(long id, PacienteRequest pacienteRequest)
    {
        var pacienteExistente = PacienteBd.GetPacienteById(id);

        if (pacienteExistente == null) throw new NotFoundException("El paciente no existe");

        pacienteExistente.Nombre = pacienteRequest.Nombre;
        pacienteExistente.Edad = pacienteRequest.Edad;
        pacienteExistente.Contacto = pacienteRequest.Contacto;

        Paciente pacienteActualizado= PacienteBd.UpdatePaciente(pacienteExistente.PacienteId ,pacienteExistente);

        return new PacienteResponse
        {
            PacienteId = pacienteActualizado.PacienteId,
            Nombre = pacienteActualizado.Nombre,
            Edad = pacienteActualizado.Edad,
            Contacto = pacienteActualizado.Contacto
        };
    }
}