using Microsoft.AspNetCore.Mvc;
using ModuloAPI.Context;
using ModuloAPI.Entities;

namespace ModuloAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class ContatoController(AgendaDbContext db) : Controller
    {
        private readonly AgendaDbContext _db = db ?? throw new ArgumentNullException(nameof(db));

        [HttpGet("contatos")]
        public IActionResult Get()
        {
            var contatos = _db.Contatos.ToList();
            if (contatos.Count == 0)
                return NotFound("Nenhum contato encontrado");

            return Ok(new { contatos, message = "Contatos encontrados" });
        }

        [HttpPost("addContato")]
        public IActionResult Add(Contato contato)
        {
            _db.Contatos.Add(contato);
            _db.SaveChanges();

            return Ok(new { contato, message = "Contato adicionado com sucesso" });
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var contato = _db.Contatos.Find(id);

            if (contato == null)
                return NotFound("Contato não encontrado");

            return Ok(contato);
        }

        [HttpGet("getByName")]
        public IActionResult GetByName(string nome)
        {
            var contato = _db.Contatos.Where(c => c.Nome.Contains(nome));

            if (contato == null)
                return NotFound("Contato não encontrado");

            return Ok(contato);
        }
    }
}