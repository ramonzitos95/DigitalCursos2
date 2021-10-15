using DigitalCursos.Api.Repositories;
using DigitalCursos.Models.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalCursos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursosController : Controller
    {
        private readonly ICursoRepository _cursoRepository;

        public CursosController(ICursoRepository cursoRepository)
        {
            _cursoRepository = cursoRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetCursos()
        {
            try
            {
                var result = await _cursoRepository.GetCursos();
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao retornar os dados do banco de dados");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Curso>> GetCurso(int id)
        {
            try
            {
                var result = await _cursoRepository.GetCurso(id);
                if(result is null)
                {
                    return NotFound($"O curso com id = {id} não foi localizado");
                }

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao retornar os dados do banco de dados");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Curso>> CreateCurso(Curso Curso)
        {
            try
            {
                if (Curso is null)
                {
                    return BadRequest();
                }

                var createdCurso = await _cursoRepository.AddCurso(Curso);
                return CreatedAtAction(nameof(GetCurso), new { id = createdCurso.CursoId }, createdCurso);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao retornar os dados do banco de dados");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Curso>> UpdateCurso(int id, Curso Curso)
        {
            try
            {
                if (id != Curso.CursoId)
                {
                    return BadRequest($"O Curso com id={id} não confere com o Curso a ser atualizado");
                }

                var CursoToUpdate = await _cursoRepository.GetCurso(id);
                if (CursoToUpdate == null)
                {
                    return NotFound($"Curso com id = ${id} não encontrado");
                }

                return await _cursoRepository.UpdateCurso(Curso);
            }   
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao retornar os dados do banco de dados");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Curso>> DeleteCurso(int id)
        {
            try
            {
                

                var CursoToDelete = await _cursoRepository.GetCurso(id);
                if (CursoToDelete == null)
                {
                    return NotFound($"Curso com id = ${id} não encontrado");
                }

                return await _cursoRepository.DeleteCurso(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao retornar os dados do banco de dados");
            }
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
