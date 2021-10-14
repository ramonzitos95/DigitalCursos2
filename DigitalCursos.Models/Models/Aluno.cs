using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalCursos.Models.Models
{
    public class Aluno
    {
        public int AlunoId { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public DateTime Nascimento { get; set; }
        public byte[] Foto { get; set; }
        public Genero Genero { get; set; }
        public Curso Curso { get; set; }
        public int CursoId { get; set; }
    }
}
