using DigitalCursos.Api.Context;
using DigitalCursos.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalCursos.Api.Repositories
{
    public class CursoRepository : ICursoRepository
    {
        private readonly AppDbContext _contexto;
        public CursoRepository(AppDbContext context)
        {
            _contexto = context;
        }

        public async Task<Curso> AddCurso(Curso curso)
        {
            var result = await _contexto.Cursos.AddAsync(curso);
            await _contexto.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Curso> DeleteCurso(int id)
        {
            var curso = _contexto.Cursos.FirstOrDefault(c => c.CursoId == id);
            if (curso != null)
            {
                _contexto.Cursos.Remove(curso);
                await _contexto.SaveChangesAsync();
            }
            return null;
        }

        public async Task<Curso> GetAlunosCurso(int id)
        {
            return await _contexto.Cursos
                .FirstOrDefaultAsync(f => f.CursoId == id);
        }

        public async Task<Curso> GetCurso(int id)
        {
            return await _contexto.Cursos
                .FirstOrDefaultAsync(f => f.CursoId == id);
        }

        public async Task<IEnumerable<Curso>> GetCursos()
        {
            return await _contexto.Cursos
                .AsNoTracking().ToListAsync();
        }

        public async Task<Curso> UpdateCurso(Curso curso)
        {
            var result = await _contexto.Cursos
                .FirstOrDefaultAsync(f => f.CursoId == curso.CursoId);
            if (result != null)
            {
                result.CursoNome = curso.CursoNome;
                result.CargaHoraria = curso.CargaHoraria;
                result.Descricao = curso.Descricao;
                result.Logo = curso.Logo;
                result.Preco = curso.Preco;
                await _contexto.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
