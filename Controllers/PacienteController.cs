using Microsoft.AspNetCore.Mvc;

namespace ClinicaMedica.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PacienteController : ControllerBase
    {
      IPacienteService PacienteService;
      public PacienteController(IPacienteService pacienteService)
      {
        PacienteService = pacienteService;
      }

      [HttpGet]
      public ActionResult<List<PacienteResponse>>GetAllPacientes()
      {
          List<PacienteResponse> pacientes = PacienteService.getPacientes();

          return Ok(pacientes);
      }

      [HttpGet("{id}")]
      public ActionResult<PacienteResponse> GetPacienteById(long id)
      {
          PacienteResponse paciente = PacienteService.getPacienteById(id);
          return Ok(paciente);
      }

      [HttpPost]
      public ActionResult<PacienteResponse> CreatePaciente([FromBody] PacienteRequest paciente)
      {
          PacienteResponse pacienteCreado = PacienteService.createPaciente(paciente);
          return Created("", pacienteCreado);
      }

      [HttpDelete("{id}")]
      public ActionResult DeletePaciente(long id)
      {
          PacienteService.deletePaciente(id);
          return NoContent();
      }
    }
}