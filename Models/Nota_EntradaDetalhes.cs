using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Back.Models
{
    [Table("Nota_EntradaDetalhes")]
    public class Nota_EntradaDetalhes
  {
        [Key]
        public int id { get; set; }
    public int? Codigo_Equipamento { get; set; }
    public int? Codigo_SubEquipamento { get; set; }
    public int? Qtd_Entrada { get; set; }
    public decimal? Valor_Entrada { get; set; }

  }
}