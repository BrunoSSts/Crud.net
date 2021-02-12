namespace Crud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataBase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DefSituacaoProduto",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Situacao = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.DefSituacaoProdutoEmbalagem",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Situacao = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.DefUnidade",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Sigla = c.String(),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Embalagem",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FatoerDeConversao = c.String(),
                        SituacaoId = c.Int(nullable: false),
                        UnidadeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.DefSituacaoProdutoEmbalagem", t => t.SituacaoId, cascadeDelete: true)
                .ForeignKey("dbo.DefUnidade", t => t.UnidadeId, cascadeDelete: true)
                .Index(t => t.SituacaoId)
                .Index(t => t.UnidadeId);
            
            CreateTable(
                "dbo.ProdutoEmbalagens",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProdutoId = c.Int(nullable: false),
                        EmbalagemId = c.Int(nullable: false),
                        Produto_Codigo = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Embalagem", t => t.EmbalagemId, cascadeDelete: true)
                .ForeignKey("dbo.Produto", t => t.Produto_Codigo)
                .Index(t => t.EmbalagemId)
                .Index(t => t.Produto_Codigo);
            
            CreateTable(
                "dbo.Produto",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                        SituacaoId = c.Int(nullable: false),
                        UnidadeId = c.Int(nullable: false),
                        PesoLiquido = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Codigo)
                .ForeignKey("dbo.DefSituacaoProduto", t => t.SituacaoId, cascadeDelete: true)
                .ForeignKey("dbo.DefUnidade", t => t.UnidadeId, cascadeDelete: true)
                .Index(t => t.SituacaoId)
                .Index(t => t.UnidadeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProdutoEmbalagens", "Produto_Codigo", "dbo.Produto");
            DropForeignKey("dbo.Produto", "UnidadeId", "dbo.DefUnidade");
            DropForeignKey("dbo.Produto", "SituacaoId", "dbo.DefSituacaoProduto");
            DropForeignKey("dbo.ProdutoEmbalagens", "EmbalagemId", "dbo.Embalagem");
            DropForeignKey("dbo.Embalagem", "UnidadeId", "dbo.DefUnidade");
            DropForeignKey("dbo.Embalagem", "SituacaoId", "dbo.DefSituacaoProdutoEmbalagem");
            DropIndex("dbo.Produto", new[] { "UnidadeId" });
            DropIndex("dbo.Produto", new[] { "SituacaoId" });
            DropIndex("dbo.ProdutoEmbalagens", new[] { "Produto_Codigo" });
            DropIndex("dbo.ProdutoEmbalagens", new[] { "EmbalagemId" });
            DropIndex("dbo.Embalagem", new[] { "UnidadeId" });
            DropIndex("dbo.Embalagem", new[] { "SituacaoId" });
            DropTable("dbo.Produto");
            DropTable("dbo.ProdutoEmbalagens");
            DropTable("dbo.Embalagem");
            DropTable("dbo.DefUnidade");
            DropTable("dbo.DefSituacaoProdutoEmbalagem");
            DropTable("dbo.DefSituacaoProduto");
        }
    }
}
