using Crud.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Crud.Dal
{
    public class CrudContext : DbContext
    {
        public CrudContext() : base("Crud") 
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        
        public DbSet<Embalagem> Embalagens { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        public DbSet<ProdutoEmbalagens> ProdutoEmbalagens { get; set; }
    
        public DbSet<DefSituacaoProduto> DefSituacaoProduto { get; set; }
        public DbSet<DefUnidade> DefUnidade { get; set; }
        public DbSet<DefSituacaoProdutoEmbalagem> DefSituacaoProdutoEmbalagem { get; set; }
    }
}