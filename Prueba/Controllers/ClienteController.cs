using Microsoft.AspNetCore.Mvc;

namespace Prueba.Controllers
{
    [ApiController]
    [Route("cliente")]
    public class ClienteController : ControllerBase
    {
        [HttpGet(Name ="GetCliente")]
        public IActionResult GetClientes()
        {
            // Aquí puedes implementar la lógica para obtener los clientes
            return Ok(new { Message = "Lista de clientes" });
        }

        [HttpPost(Name = "PostCliente")]
        public IActionResult PostClientes()
        {
            // Aquí puedes implementar la lógica para obtener los clientes
            return Ok(new { Message = "Lista de clientes" });
        }
    }
}
