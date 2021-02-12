using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Crud.Models
{
    public class Embalagem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Display(Name = "Fator De Conversão")]

        public string FatoerDeConversao { get; set; }
                
        [Display(Name = "Situação")]
        public int SituacaoId { get; set; }

        public virtual DefSituacaoProdutoEmbalagem Situacao { get; set; }
        
        [Display(Name = "Unidade")]
        public int UnidadeId { get; set; }

        public virtual DefUnidade Unidade { get; set; }
    }
}