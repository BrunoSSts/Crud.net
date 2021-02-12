
using System.Collections.Generic;

namespace Crud.Models
{
    public class ProdutoViewModel 
    {
        public Produto Produto { get; set; }
        
        public IEnumerable<DefSituacaoProduto> SituacoesProduto { get; set; }

        public IEnumerable<DefUnidade> Unidades { get; set; }

        public TiposTela Tela { get; set; }
    }

    public enum TiposTela
    {
        Create = 0,
        Edit = 1
    }
}