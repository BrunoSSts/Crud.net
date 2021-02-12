
using System.ComponentModel.DataAnnotations.Schema;

namespace Crud.Models
{
    public class ProdutoEmbalagens
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public int ProdutoId { get; set; }

        public virtual Produto Produto { get; set; } 

        public int EmbalagemId { get; set; }

        public virtual Embalagem Embalagem { get; set; }   

        
    }  
}