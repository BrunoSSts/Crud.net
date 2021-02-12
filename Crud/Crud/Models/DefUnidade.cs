
using System.ComponentModel.DataAnnotations.Schema;

namespace Crud.Models
{
    public class DefUnidade
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Sigla { get; set; }
        public string Nome { get; set; }
        
    }  
}