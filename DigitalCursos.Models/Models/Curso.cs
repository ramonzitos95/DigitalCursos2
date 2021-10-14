using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalCursos.Models.Models
{
    public class Curso
    {
        public int CursoId { get; set; }
        public string CursoNome { get; set; }
        public string Descricao { get; set; }
        public  int CargaHoraria { get; set; }
        public DateTime Inicio { get; set; }
        public decimal Preco { get; set; }
        public byte[] Logo { get; set; }
        public Collection<Aluno> Alunos { get; set; }
    }
}
