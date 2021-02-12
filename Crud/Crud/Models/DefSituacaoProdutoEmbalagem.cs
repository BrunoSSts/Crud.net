
using System.ComponentModel.DataAnnotations.Schema;

namespace Crud.Models
{
    public class DefSituacaoProdutoEmbalagem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Situacao { get; set; }
    }  
}