using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Back.Models
{

  [Table("Centro_Custo")]
  public class Centro_Custo
  {
    [Key]
    [Column("ID_CentroCusto")]
    public int id { get; set; }

    public string Codigo_CentroCusto { get; set; }

    public string Descricao_CentroCusto { get; set; }

    [Required(ErrorMessage = "Cód. Cliente é Obrigatório")]
    public int? id_cliente { get; set; }

  }
}