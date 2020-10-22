using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{

  [Table("Saldo")]
  public class Saldo
  {
    [Key]
    public int? Codigo_Equipamento { get; set; }
    public int? Codigo_SubEquipamento { get; set; }
    public int? Saldo_Final { get; set; }

    [Required(ErrorMessage = "Cód. Cliente é Obrigatório")]
    public int? id_cliente { get; set; }

  }
}