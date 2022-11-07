
using cNetMvc.Model;
using cNetMvc.Repository;
using Microsoft.AspNetCore.Mvc;

namespace cNetMvc.Controllers
{
 [ApiController]
 [Route("api/[controller]")]
 public class ClienteController : ControllerBase
 {
  private readonly IClienteRepository _repository;

  public ClienteController(IClienteRepository repository)
  {
   _repository = repository;
  }

  [HttpGet]
  public async Task<IActionResult> GetAll()
  {

   var clientes = await _repository.GetClientes();

   return clientes.Any() ? Ok(clientes) : NoContent();
  }

  [HttpGet("{id}")]
  public async Task<IActionResult> GetById(int id)
  {

   var cliente = await _repository.GetClienteBYId(id);
   return cliente != null ? Ok(cliente) : NotFound("cliente não encontrado");

  }

  [HttpPost]
  public async Task<IActionResult> Post(Cliente cliente)
  {
   _repository.AddCliente(cliente);

   return await _repository.SaveChangesAsync() ? Ok("Cliente Adicionado") : BadRequest("Tentativa falhou");
  }

  [HttpPut("{id}")]
  public async Task<IActionResult> Atualizar(int id, Cliente cliente)
  {
   var clienteExiste = await _repository.GetClienteBYId(id);
   if (clienteExiste == null) return NotFound("Cliente não encontrado");

   clienteExiste.Nome = cliente.Nome ?? clienteExiste.Nome;
   clienteExiste.dataNascimento = cliente.dataNascimento != new DateTime()
   ? cliente.dataNascimento : clienteExiste.dataNascimento;

   _repository.AtualizarCliente(clienteExiste);

   return await _repository.SaveChangesAsync()
   ? Ok("cliente atualizado") : BadRequest("Tentativa falhou");

  }
  [HttpDelete("{id}")]
  public async Task<IActionResult> Delete(int id)
  {

   var clienteExiste = await _repository.GetClienteBYId(id);
   if (clienteExiste == null)
    return NotFound("Cliente não encontrado");

   _repository.DeletarCliente(clienteExiste);

   return await _repository.SaveChangesAsync()
   ? Ok("Cliente deletado") : BadRequest("Tentativa falhou");
  }
 }
}