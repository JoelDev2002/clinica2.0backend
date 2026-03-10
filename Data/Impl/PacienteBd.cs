public class PacienteBd : IPacienteBd
{
  private List<Paciente> pacientes =new List<Paciente>();

  public Paciente CreatePaciente(Paciente paciente)
  {
    if(paciente.PacienteId == 0)
    {
        paciente.PacienteId = pacientes.Count()+1;
    }

    pacientes.Add(paciente);
    return paciente;
  }

  public void DeletePaciente(long id)
  {
    var index = pacientes.FindIndex(p => p.PacienteId == id);
    if(index == -1)
    {
        throw new NotFoundException("Paciente no encontrado");
    }

    pacientes.RemoveAt(index);
  }

  public Paciente GetPacienteById(long id)
  {
    var index = pacientes.FindIndex(p => p.PacienteId == id);
    if (index == -1)
    {
        throw new NotFoundException("Paciente no encontrado");
    }
return pacientes[index];
  }

  public List<Paciente> GetPacientes()
  {
    return pacientes;
  }

  public Paciente UpdatePaciente(long id, Paciente paciente)
  {
    var index = pacientes.FindIndex(p => p.PacienteId == id);
    if (index == -1)
    {
        throw new NotFoundException("Paciente no encontrado");
    }
    pacientes[index] = paciente;
    return pacientes[index];
  }
}