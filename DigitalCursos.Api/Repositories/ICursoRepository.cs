using DigitalCursos.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalCursos.Api.Repositories
{
    public interface ICursoRepository
    {
        Task<IEnumerable<Curso>> GetCursos();
        Task<Curso> GetCurso(int id);
        Task<Curso> GetAlunosCurso(int id);
        Task<Curso> AddCurso(Curso Curso);
        Task<Curso> UpdateCurso(Curso Curso);
        Task<Curso> DeleteCurso(int id);

    }
}
