
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

  [HttpPut("{id}")]
  public async Task<IActionResult> Atualizar(int id, Destino destino)
  {
   var destinoExiste = await _repository.GetDestinoBYId(id);
   if (destinoExiste == null) return NotFound("Destino não encontrado");

   destinoExiste.destinoViagem = destino.destinoViagem ?? destinoExiste.destinoViagem;
   destinoExiste.dataPartida = destino.dataPartida != new DateTime()
   ? destino.dataPartida : destinoExiste.dataPartida;
   destinoExiste.dataRetorno = destino.dataRetorno != new DateTime()
   ? destino.dataRetorno : destinoExiste.dataRetorno;

   _repository.AtualizarDestino(destinoExiste);

   return await _repository.SaveChangesAsync()
   ? Ok("destino atualizado") : BadRequest("Tentativa falhou");

  }
  [HttpDelete("{id}")]
  public async Task<IActionResult> Delete(int id)
  {

   var destinoExiste = await _repository.GetDestinoBYId(id);
   if (destinoExiste == null)
    return NotFound("Destino não encontrado");

   _repository.DeletarDestino(destinoExiste);

   return await _repository.SaveChangesAsync()
   ? Ok("Destino deletado") : BadRequest("Tentativa falhou");
  }
 }
}