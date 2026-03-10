public class CitaService : ICitaService
{
    private ICitaBd CitaBd;
    private IPacienteBd PacienteBd;
    private IMedicoBd MedicoBd;

    public CitaService(ICitaBd citaBd, IPacienteBd pacienteBd, IMedicoBd medicoBd)
    {
        CitaBd = citaBd;
        PacienteBd = pacienteBd;
        MedicoBd = medicoBd;
    }


    public CitaResponse CreateCita(CitaRequest cita)
    {
        Paciente paciente = PacienteBd.GetPacienteById(cita.PacienteId);
        Medico medico = MedicoBd.GetMedicoById(cita.MedicoId);

        if (paciente == null ) throw new NotFoundException("no se encontro paciente con id: " + cita.PacienteId);

        if (medico == null) throw new NotFoundException("no se encontro medico con id" + cita.MedicoId);

        if (cita.Fecha < DateTime.Now) throw new BadRequestException("La fecha de la cita no puede ser en el pasado");

        Cita nuevaCita = new Cita
        {
            TipoCita = cita.TipoCita,
            Fecha = cita.Fecha,
            PacienteId = cita.PacienteId,
            MedicoId = cita.MedicoId,
            Estado = "Programada",
            Observaciones = "",
            Receta = ""
        };

        Cita citaCreada = CitaBd.CreateCita(nuevaCita);

        

        return new CitaResponse
        {
            CitaId = citaCreada.CitaId,
            TipoCita = citaCreada.TipoCita,
            Fecha = citaCreada.Fecha,
            PacienteNombre = paciente.Nombre,
            MedicoNombre = medico.Nombre,
            Estado = citaCreada.Estado,
            Obervaciones = citaCreada.Observaciones,
            Receta = citaCreada.Receta
        };

    }

    public void DeleteCita(long id)
    {
        Cita citaExists=CitaBd.GetCitaById(id);//null

        if (citaExists == null) throw new NotFoundException("La cita no fue encontrada");
        CitaBd.DeleteCita(citaExists.CitaId);
    }

    public CitaResponse GetCitaById(long id)
    {
        Cita citaExists = CitaBd.GetCitaById(id);

        if(citaExists == null) throw new NotFoundException("No se encontro la cita con id: " + id);

        return new CitaResponse
        {
            CitaId = citaExists.CitaId,
            TipoCita = citaExists.TipoCita,
            Fecha = citaExists.Fecha,
            PacienteNombre = PacienteBd.GetPacienteById(citaExists.PacienteId).Nombre,
            MedicoNombre = MedicoBd.GetMedicoById(citaExists.MedicoId).Nombre,
            Estado = citaExists.Estado,
            Obervaciones = citaExists.Observaciones,
            Receta = citaExists.Receta
        };
    }

    public List<CitaResponse> GetAllCitas()
    {
        return CitaBd.GetCitas()
            .Select(cita => new CitaResponse
        {
            CitaId = cita.CitaId,
            TipoCita = cita.TipoCita,
            Fecha = cita.Fecha,
            PacienteNombre = PacienteBd.GetPacienteById(cita.PacienteId).Nombre,
            MedicoNombre = MedicoBd.GetMedicoById(cita.MedicoId).Nombre,
            Estado = cita.Estado,
            Obervaciones = cita.Observaciones,
            Receta = cita.Receta
        }).ToList();
    }

    public CitaResponse ReprogramarCita(long id, ReprogramarCitaRequest cita)
    {
        var citaExists = CitaBd.GetCitaById(id);

        if(citaExists == null) throw new NotFoundException("No se encontro la cita con id: " + id);

        citaExists.Fecha = cita.NuevaFecha;

        Cita citaActualizada = CitaBd.UpdateCita(citaExists.CitaId,citaExists);

        return new CitaResponse
        {
            CitaId = citaActualizada.CitaId,
            TipoCita = citaActualizada.TipoCita,
            Fecha = citaActualizada.Fecha,
            PacienteNombre = PacienteBd.GetPacienteById(citaActualizada.PacienteId).Nombre,
            MedicoNombre = MedicoBd.GetMedicoById(citaActualizada.MedicoId).Nombre,
            Estado = citaActualizada.Estado,
            Obervaciones = citaActualizada.Observaciones,
            Receta = citaActualizada.Receta
        };

    }

    public CitaResponse CompleteCita(long id, CitaCompletadaRequest cita)
    {
        var citaExists = CitaBd.GetCitaById(id);

        if (citaExists == null) throw new NotFoundException("No se encontro la cita con id: " + id);

        citaExists.Observaciones = cita.Observaciones;
        citaExists.Receta = cita.Receta;
        citaExists.Estado = "Completada";

        Cita citaActualizada = CitaBd.UpdateCita(citaExists.CitaId, citaExists);

        return new CitaResponse
        {
            CitaId = citaActualizada.CitaId,
            TipoCita = citaActualizada.TipoCita,
            Fecha = citaActualizada.Fecha,
            PacienteNombre = PacienteBd.GetPacienteById(citaActualizada.PacienteId).Nombre,
            MedicoNombre = MedicoBd.GetMedicoById(citaActualizada.MedicoId).Nombre,
            Estado = citaActualizada.Estado,
            Obervaciones = citaActualizada.Observaciones,
            Receta = citaActualizada.Receta
        };
    }
}