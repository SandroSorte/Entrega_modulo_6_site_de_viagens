
using cNetMvc.Repository;
using cNetMvc.Model;
using Microsoft.AspNetCore.Mvc;

namespace cNetMvc.Controllers
{
 [ApiController]
 [Route("api/[controller]")]
 public class DestinoController : ControllerBase
 {
  private readonly IDestinoRepository _repository;

  public DestinoController(IDestinoRepository repository)
  {
   _repository = repository;
  }
  
  [HttpGet]

  public string Hello()
  {
   return "Hello";
  }

  [HttpPost]
  public async Task<IActionResult> Post(Destino destino)
  {
   _repository.AddDestino(destino);

   return await _repository.SaveChangesAsync() ? Ok("Destino publicado") : BadRequest("Tentativa falhou");
  }
 }
}