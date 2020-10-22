using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{

  [Table("Nota_EntradaDetalhes")]
  public class Nota_EntradaDetalhes
  {
    [Key]
    [Column("ID_Nota_Entrada")]
    public int id { get; set; }
    public int? Codigo_Equipamento { get; set; }
    public int? Codigo_SubEquipamento { get; set; }
    public int? Qtd_Entrada { get; set; }

    [Column(TypeName = "decimal(12,4)")]
    public decimal? Valor_Entrada { get; set; }

  }
}