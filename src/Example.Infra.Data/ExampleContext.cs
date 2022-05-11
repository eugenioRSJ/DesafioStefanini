using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace Example.Infra.Data
{
    /// <summary>
    /// Referência de artigo para conseguir criar modelos de configuração
    /// https://docs.microsoft.com/pt-br/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/infrastructure-persistence-layer-implementation-entity-framework-core
    /// Rererência de artigo para conseguir criar migration a partir de dominios
    /// https://docs.micro  soft.com/en-us/ef/core/managing-schemas/migrations/managing?tabs=dotnet-core-cli
    /// </summary>
    public class ExampleContext : DbContext
    {
        public DbSet<Domain.Pessoa> Pessoas { get; set; }
        public DbSet<Domain.Cidade> Cidades { get; set; }
        public ExampleContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PessoaEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CidadeEntityTypeConfiguration());
            modelBuilder.Entity<Domain.Pessoa>();
            modelBuilder.Entity<Domain.Cidade>();

        }
    }
    public class PessoaEntityTypeConfiguration : IEntityTypeConfiguration<Domain.Pessoa>
    {
        public void Configure(EntityTypeBuilder<Domain.Pessoa> pessoaConfiguration)
        {
            pessoaConfiguration.ToTable("Pessoas", "dbo");

            pessoaConfiguration.HasKey(o => o.Id);
            pessoaConfiguration.Property(o => o.Id).UseIdentityColumn();
            pessoaConfiguration.Property(o => o.Nome).HasColumnType("varchar(300)").IsRequired();
            pessoaConfiguration.Property(o => o.CPF).HasColumnType("varchar(11)").IsRequired();
            pessoaConfiguration.Property(o => o.Idade).IsRequired();
            pessoaConfiguration.Property(o => o.CidadeId).IsRequired();
        }
    }
    public class CidadeEntityTypeConfiguration : IEntityTypeConfiguration<Domain.Cidade>
    {
        public void Configure(EntityTypeBuilder<Domain.Cidade> pessoaConfiguration)
        {
            pessoaConfiguration.ToTable("Cidade", "dbo");

            pessoaConfiguration.HasKey(o => o.Id);
            pessoaConfiguration.Property(o => o.Id).UseIdentityColumn();
            pessoaConfiguration.Property(o => o.Nome).HasColumnType("varchar(300)").IsRequired();
            pessoaConfiguration.Property(o => o.UF).HasColumnType("varchar(2)").IsRequired();
        }
    }
}
