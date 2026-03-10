public class MedicoService : IMedicoService
{
    private readonly IMedicoBd MedicoBd;

    public MedicoService(IMedicoBd medicoBd)
    {
        MedicoBd = medicoBd;
    }
    public MedicoResponse createMedico(MedicoRequest medicoRequest)
    {
        var contactoExistente = MedicoBd.GetMedicos()
            .Exists(medico => medico.Contacto == medicoRequest.Contacto);

        if (contactoExistente) throw new ConflictException("El contacto ya está registrado. Intente con otro");

        Medico nuevoMedico = new Medico
        {
            Nombre = medicoRequest.Nombre,
            Edad = medicoRequest.Edad,
            Contacto = medicoRequest.Contacto,
            Especialidad = medicoRequest.Especialidad
        };

        Medico medicoCreado = MedicoBd.CreateMedico(nuevoMedico);

        return new MedicoResponse
        {
            MedicoId = medicoCreado.MedicoId,
            Nombre = medicoCreado.Nombre,
            Edad = medicoCreado.Edad,
            Contacto = medicoCreado.Contacto,
            Especialidad = medicoCreado.Especialidad
        };

    }

    public void deleteMedico(long id)
    {
        var medicoExistente = MedicoBd.GetMedicoById(id);

        if (medicoExistente == null) throw new NotFoundException("El médico no existe");

        MedicoBd.DeleteMedico(medicoExistente.MedicoId);
    }

    public MedicoResponse getMedicoById(long id)
    {
        var medicoExitsente = MedicoBd.GetMedicoById(id);

        if (medicoExitsente == null) throw new NotFoundException("El médico no existe");

        return new MedicoResponse
        {
            MedicoId = medicoExitsente.MedicoId,
            Nombre = medicoExitsente.Nombre,
            Edad = medicoExitsente.Edad,
            Contacto = medicoExitsente.Contacto,
            Especialidad = medicoExitsente.Especialidad
        };
    }

    public List<MedicoResponse> GetMedicos()
    {
        return MedicoBd.GetMedicos().Select(medico => new MedicoResponse
        {
            MedicoId = medico.MedicoId,
            Nombre = medico.Nombre,
            Edad = medico.Edad,
            Contacto = medico.Contacto,
            Especialidad = medico.Especialidad
        }).ToList();
    }

    public MedicoResponse updateMedico(long id, MedicoRequest medicoRequest)
    {
        var medicoExistente = MedicoBd.GetMedicoById(id);

        if (medicoExistente == null) throw new NotFoundException("El médico no existe");

        medicoExistente.Nombre = medicoRequest.Nombre;
        medicoExistente.Edad = medicoRequest.Edad;
        medicoExistente.Contacto = medicoRequest.Contacto;
        medicoExistente.Especialidad = medicoRequest.Especialidad;

        Medico medicoActualizado= MedicoBd.UpdateMedico(medicoExistente.MedicoId, medicoExistente);

        return new MedicoResponse
        {
            MedicoId = medicoActualizado.MedicoId,
            Nombre = medicoActualizado.Nombre,
            Edad = medicoActualizado.Edad,
            Contacto = medicoActualizado.Contacto,
            Especialidad = medicoActualizado.Especialidad
        };
    }
}