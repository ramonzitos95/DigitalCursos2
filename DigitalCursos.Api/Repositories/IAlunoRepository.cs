using DigitalCursos.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalCursos.Api.Repositories
{
    public interface IAlunoRepository
    {
        Task<IEnumerable<Aluno>> GetAlunos();
        Task<Aluno> GetAluno(int id);
        Task<Aluno> AddAluno(Aluno aluno);
        Task<Aluno> UpdateAluno(Aluno aluno);
        Task<Aluno> DeleteAluno(int id);

    }
}
