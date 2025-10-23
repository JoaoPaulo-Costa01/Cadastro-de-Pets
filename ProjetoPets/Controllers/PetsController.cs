using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoPets.Data;
using ProjetoPets.Models;

namespace ProjetoPets.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase {
        
        private readonly AppDbContext _appDbContext;

        public PetsController(AppDbContext appDbContext) {
            _appDbContext = appDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> AddPets([FromBody] Pets pets) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            _appDbContext.Bichinhos.Add(pets);
            await _appDbContext.SaveChangesAsync();

            return Created("Pet adicionado com sucesso!", pets);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pets>>> GetPets() {
            var pets = await _appDbContext.Bichinhos.ToListAsync();

            return Ok(pets);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pets>> GetIdPets(int id) {
            var pets = await _appDbContext.Bichinhos.FindAsync(id);

            if(pets == null) {
                return NotFound("Pet não encontrado!");
            }

            return Ok(pets);
        }

        [HttpGet("ObterPorNome")]
        public async Task<ActionResult<Pets>> GetNomePets(string name) {

            if (string.IsNullOrEmpty(name)) {
                return BadRequest("O parâmetro 'name' é obrigatório.");
            }

            var pet = await _appDbContext.Bichinhos.FirstOrDefaultAsync(p => p.Nome.ToUpper() == name.ToUpper());

            if (pet == null) {
                return NotFound("Pet não encontrado!");
            }

            return Ok(pet);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPets(int id, [FromBody] Pets petsAtualizado) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            var petsExistente = await _appDbContext.Bichinhos.FindAsync(id);
            
            if (petsExistente == null) {
                return NotFound("Pet não encontrado!");
            }

            petsExistente.Nome = petsAtualizado.Nome;
            petsExistente.Especie = petsAtualizado.Especie;
            petsExistente.Sexo = petsAtualizado.Sexo;
            petsExistente.Idade = petsAtualizado.Idade;
            petsExistente.Peso = petsAtualizado.Peso;
            petsExistente.Raca = petsAtualizado.Raca;

            await _appDbContext.SaveChangesAsync();

            return Ok(petsExistente);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePets(int id) {

            var pets = await _appDbContext.Bichinhos.FindAsync(id);

            if (pets == null) {
                return NotFound("Pet não encontrado!");
            }

            _appDbContext.Bichinhos.Remove(pets);

            await _appDbContext.SaveChangesAsync();

            return Ok("Pet deletado com sucesso!");
        }
    }
}