using EntityFrameworkLib.Models;
using EntityFrameworkLib.Models.Academia;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkLib.Context
{
    public class LibDbContext : DbContext
    {
        public LibDbContext() { }

        public LibDbContext(DbContextOptions<LibDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            //optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=FrameworkMVVM;User Id=postgres;Password=postgres;");
            optionsBuilder.UseNpgsql("Server=pg-29b8183b-igorbdaluz-1a14.i.aivencloud.com;Port=11217;Database=defaultdb;User Id=avnadmin;Password=AVNS_uLxiVaelGcWM5jX2VwT;sslmode=Require;Trust Server Certificate=true;");
        }

        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Formulario> Formularios { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<FichaTreino> FichasTreino { get; set; }
        public DbSet<TreinoAluno> TreinosAluno { get; set; }
        public DbSet<Treino> Treinos { get; set; }
        public DbSet<Exercicio> Exercicios { get; set; }
    }
}

