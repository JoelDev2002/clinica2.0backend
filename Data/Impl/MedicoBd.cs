public class MedicoBd : IMedicoBd
{
  private List<Medico> medicos=new List<Medico>();
  public Medico CreateMedico(Medico medico)
  {
    if(medico.MedicoId == 0)
    {
        medico.MedicoId = medicos.Count + 1;
    }
    medicos.Add(medico);
    return medico;
  }

  public void DeleteMedico(long id)
  {
    var index = medicos.FindIndex(m => m.MedicoId == id);
    if (index == -1)
    {
        throw new NotFoundException("Medico no encontrado");
    }
    medicos.RemoveAt(index);
  }

  public Medico GetMedicoById(long id)
  {
    var index = medicos.FindIndex(m => m.MedicoId == id);
    if (index == -1)
    {
        throw new NotFoundException("Medico no encontrado");
    }
    return medicos[index];
  }

  public List<Medico> GetMedicos()
  {
    return medicos;
  }

  public Medico UpdateMedico(long id, Medico medico)
  {
    var index = medicos.FindIndex(m => m.MedicoId == id);
    if (index == -1)
    {
        throw new NotFoundException("Medico no encontrado");
    }
    medicos[index] = medico;
    return medicos[index];
  }
}