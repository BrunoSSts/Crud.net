namespace Crud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seed : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into DefUnidade ( Nome, Sigla) values ( 'Caixa', 'CX')");
            Sql("Insert into DefUnidade ( Nome, Sigla) values ( 'Quilograma', 'KG')");
            Sql("Insert into DefUnidade ( Nome, Sigla) values ( 'Peça', 'L')");
            Sql("Insert into DefUnidade ( Nome, Sigla) values ( 'Pacote', 'PC')");
            Sql("Insert into DefUnidade ( Nome, Sigla) values ( 'Caixa', 'PCT')");
            Sql("Insert into DefUnidade ( Nome, Sigla) values ( 'Unidade', 'UN')");

            Sql("Insert into DefSituacaoProduto (Situacao) values ('Ativo')");
            Sql("Insert into DefSituacaoProduto (Situacao) values ('Inativo')");
            Sql("Insert into DefSituacaoProduto (Situacao) values ('Bloqueado')");
        
            Sql("Insert into DefSituacaoProdutoEmbalagem (Situacao) values ( 'Ativo')");
            Sql("Insert into DefSituacaoProdutoEmbalagem (Situacao) values ( 'Inativo')");
        }
        
        public override void Down()
        {
        }
    }
}
