using Microsoft.EntityFrameworkCore;

namespace ADSAlunos2024.Models
{
    public class Contexto: DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        public DbSet<Curso> Cursos { get; set; }
sdfasdsafdasd

    }
}
