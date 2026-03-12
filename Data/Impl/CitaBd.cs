public class CitaBd : ICitaBd
{
  private List<Cita> citas =new List<Cita>();
  public Cita CreateCita(Cita cita)
  {
    if(cita.CitaId == 0) cita.CitaId=citas.Count+1;
    citas.Add(cita);
    return cita;
  }

  public void DeleteCita(long id)
  {
    int indiceCita=citas.FindIndex(cita=>cita.CitaId == id);//si no encuentra nada devolvera un -1

    if (indiceCita == -1)
    {
        throw new NotFoundException("Cita no encontrado");
    }
    citas.RemoveAt(indiceCita);
  }

  public Cita GetCitaById(long id)
  {
    int indiceCita=citas.FindIndex(cita=>cita.CitaId == id);

    if (indiceCita == -1)
    {
        throw new NotFoundException("Cita no encontrado");
    }

    return citas[indiceCita];
  }

  public List<Cita> GetCitas()
  {
    return citas;
  }

  public Cita UpdateCita(long id, Cita cita)
  {
    int indiceCita=citas.FindIndex(cita=>cita.CitaId == id);

    if (indiceCita == -1)
    {
        throw new NotFoundException("Cita no encontrado");
    }
    citas[indiceCita]=cita;

    return cita;
  }
}