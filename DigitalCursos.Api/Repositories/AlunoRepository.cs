using DigitalCursos.Api.Context;
using DigitalCursos.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalCursos.Api.Repositories
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly AppDbContext _contexto;
        public AlunoRepository(AppDbContext context)
        {
            _contexto = context;
        }

        public async Task<Aluno> AddAluno(Aluno aluno)
        {
            var result = await _contexto.Alunos.AddAsync(aluno);
            await _contexto.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Aluno> DeleteAluno(int id)
        {
            var aluno = _contexto.Alunos.FirstOrDefault(c => c.AlunoId == id);
            if(aluno != null)
            {
                _contexto.Alunos.Remove(aluno);
                await _contexto.SaveChangesAsync();
            }
            return null;
        }

        public async Task<Aluno> GetAluno(int id)
        {
            return await _contexto.Alunos
                .FirstOrDefaultAsync(f => f.AlunoId == id);
        }

        public async Task<IEnumerable<Aluno>> GetAlunos()
        {
            return await _contexto.Alunos
                .AsNoTracking().ToListAsync();
        }

        public async Task<Aluno> UpdateAluno(Aluno aluno)
        {
            var result = await _contexto.Alunos
                .FirstOrDefaultAsync(f => f.AlunoId == aluno.AlunoId);
            if(result != null)
            {
                result.Nome = aluno.Nome;
                result.Sobrenome = aluno.Sobrenome;
                result.Email = aluno.Email;
                result.Nascimento = aluno.Nascimento;
                result.Genero = aluno.Genero;
                result.Foto = aluno.Foto;
                result.CursoId = aluno.CursoId;
                await _contexto.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
