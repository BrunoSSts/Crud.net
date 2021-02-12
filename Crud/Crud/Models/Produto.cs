using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Crud.Models
{
    public class Produto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Código")]
        public int Codigo { get; set; }
        
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        

        [Display(Name = "Situação")]
        public int SituacaoId { get; set; }
        
        public virtual DefSituacaoProduto Situacao { get; set; }


        [Display(Name = "Unidade")]
        public int UnidadeId { get; set; }
        public virtual DefUnidade Unidade { get; set; }
           
        
        [Display(Name = "Peso")]
        public float PesoLiquido { get; set; }

        public virtual IEnumerable<Embalagem> Embalagens { get; set; }
    }  
}