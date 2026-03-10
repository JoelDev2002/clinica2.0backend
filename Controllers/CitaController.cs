using Microsoft.AspNetCore.Mvc;

namespace ClinicaMedica.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CitaController : ControllerBase
  {
    ICitaService CitaService;
    public CitaController(ICitaService citaService)
    {
      CitaService = citaService;
    }

    [HttpPost]
    public ActionResult<CitaResponse> CreateCita([FromBody] CitaRequest cita)
    {
        CitaResponse citaCreada = CitaService.CreateCita(cita);
        return Created("la cita fue creada", citaCreada);
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteCita(long id)
    {
        CitaService.DeleteCita(id);
        return NoContent();
    }

    [HttpGet("{id}")]
    public ActionResult<CitaResponse> GetCitaById(long id)
    {
        CitaResponse cita = CitaService.GetCitaById(id);
        return Ok(cita);
    }

    [HttpGet]
    public ActionResult<List<CitaResponse>> GetAllCitas()
    {
        List<CitaResponse> citas = CitaService.GetAllCitas();
        return Ok(citas);
    }

    [HttpPut("{id}")]
    public ActionResult<CitaResponse> ReprogramarCita(long id, [FromBody] ReprogramarCitaRequest cita)
    {
        CitaResponse citaActualizada = CitaService.ReprogramarCita(id, cita);
        return Ok(citaActualizada);
    }

    [HttpPut("completar/{id}")]
    public ActionResult<CitaResponse> CompletarCita(long id, [FromBody] CitaCompletadaRequest cita)
    {
        CitaResponse citaCompletada = CitaService.CompleteCita(id, cita);
        return Ok(citaCompletada);
    }
  }
}