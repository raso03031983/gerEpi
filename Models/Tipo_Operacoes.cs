
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Back.Models
{

    [Table("Tipo_Operacoes")]
    public class Tipo_Operacoes
  {
        [Key]
        public int id { get; set; }

    public char Tipo_Operacao { get; set; }
    public char Operacao_ES { get; set; }

   
    public string DescricaoTipo_Operacao { get; set; }

   
    public int id_cliente { get; set; }

  }
}