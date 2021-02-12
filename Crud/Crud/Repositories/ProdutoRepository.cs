using Crud.Dal;
using Crud.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Crud.Repositories
{
    public class ProdutoRepository : IDisposable
    {
        private CrudContext db;

        public ProdutoRepository()
        {
            db = new CrudContext();
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public List<Produto> GetProdutos(string criterioBusca = null)
        {
            var queryProdutos = db.Produtos.AsQueryable(); 

            if(!String.IsNullOrEmpty(criterioBusca))
            {

                /*
                 * O campo pesquisa deve chamar uma função AJAX para trazer os resultados da
                 *  pesquisa (produtos filtrados). Deve-se considerar na pesquisa: Código, Descrição eSituação 
                 */
                queryProdutos = queryProdutos.Where(p =>
                    p.Descricao.Contains(criterioBusca) ||
                    p.Codigo.ToString().Equals(criterioBusca) ||
                    p.Situacao.Situacao.Contains(criterioBusca));
            }

            return queryProdutos.ToList();

        }

        public void RemoveProdutoById(int id)
        {
            db.Produtos.Remove(GetProdutoById(id));

            db.SaveChanges();
        }

        public Produto GetProdutoById(int id)
        {
            var prod = db.Produtos.Where(x => x.Codigo == id).FirstOrDefault();
            if(prod == null)
                throw new ArgumentException("Não é um id válido");

            return prod;
        }

        public void SaveProduto(Produto prod)
        {
            db.Produtos.Add(prod);
            db.SaveChanges();
        }

        public ProdutoViewModel GetBaseViewModel()
        {
            return new ProdutoViewModel
                {
                    SituacoesProduto = db.DefSituacaoProduto.ToList(),
                    Unidades = db.DefUnidade.ToList(),
                };
        }

    }
}