using DigitalCursos.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalCursos.Api.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Curso> Cursos { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            //curso
            mb.Entity<Curso>()
                .HasKey(f => f.CursoId);

            mb.Entity<Curso>()
                .Property(b => b.CursoNome).HasMaxLength(150);

            mb.Entity<Curso>()
                .Property(b => b.Descricao).HasMaxLength(250);

            mb.Entity<Curso>()
                .Property(b => b.Preco).HasColumnType("decimal(18,2)");

            //aluno
            mb.Entity<Aluno>()
                .Property(b => b.Nome).HasMaxLength(150);

            mb.Entity<Aluno>()
                .Property(b => b.Sobrenome).HasMaxLength(100);

            mb.Entity<Aluno>()
                .Property(b => b.Email).HasMaxLength(100);

            //dados novos
            mb.Entity<Curso>().HasData(
                    new Curso
                    {
                        CursoId = 1,
                        CursoNome = "Csharp Basico",
                        Descricao = "Curso de C# Basico",
                        CargaHoraria = 40,
                        Inicio = new DateTime(2020, 08, 21),
                        Preco = 250.00M,
                        Logo = null
                    }
                );

            mb.Entity<Curso>().HasData(
                    new Curso
                    {
                        CursoId = 1,
                        CursoNome = "AspNet Basico",
                        Descricao = "Curso Asp .Net Core Basico",
                        CargaHoraria = 40,
                        Inicio = new DateTime(2020, 08, 21),
                        Preco = 150.00M,
                        Logo = null
                    }
                );

            mb.Entity<Aluno>().HasData(
                    new Aluno
                    {
                        AlunoId = 2,
                        Nome = "Ramon",
                        Sobrenome = "Silva",
                        Email = "ramonss.bque@gmail.com",
                        Nascimento = new DateTime(1995, 06, 10),
                        Foto = null,
                        Genero = Genero.Masculino,
                        CursoId = 1
                    }
                );

            mb.Entity<Aluno>().HasData(
                    new Aluno
                    {
                        AlunoId = 2,
                        Nome = "Alicia",
                        Sobrenome = "Mesquita",
                        Email = "alicia.bque@gmail.com",
                        Nascimento = new DateTime(1995, 01, 23),
                        Foto = null,
                        Genero = Genero.Feminino,
                        CursoId = 2
                    }
                );
        }
    }
}
