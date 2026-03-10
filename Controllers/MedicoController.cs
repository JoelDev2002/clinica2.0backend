using Microsoft.AspNetCore.Mvc;

namespace ClinicaMedica.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedicoController : ControllerBase
    {
      IMedicoService MedicoService;

      public MedicoController(IMedicoService medicoService)
      {
        MedicoService = medicoService;
      }

      [HttpGet]
      public IActionResult GetMedicos()
      {
        var medicos = MedicoService.GetMedicos();
        return Ok(medicos);
      }

      [HttpGet("{id}")]
      public ActionResult<MedicoResponse> GetMedicoById(long id)
      {
              MedicoResponse medico = MedicoService.getMedicoById(id);
              return Ok(medico);
      }

      [HttpPost]
      public ActionResult<MedicoResponse> CreateMedico([FromBody] MedicoRequest medicoRequest)
      {
          MedicoResponse medicoCreado = MedicoService.createMedico(medicoRequest);
          return Created("", medicoCreado);
      }

      [HttpDelete("{id}")]
      public ActionResult DeleteMedico(long id)
      {
          MedicoService.deleteMedico(id);
          return NoContent();
      }
    }
}