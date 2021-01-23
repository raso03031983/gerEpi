using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Back.Models
{

  [Table("GSE_Classificacao")]
  public class GSE_Classificacao
  {
    [Key]
    [Column("ID_GSE_Classificacao")]
    public int id { get; set; }
    public int? ID_GSE { get; set; }
    public int? ID_Local { get; set; }
    public int? ID_Classificacao { get; set; }
    public char? Tipo_EPI { get; set; }

    [Required(ErrorMessage = "Cód. Cliente é Obrigatório")]
    public int? id_cliente { get; set; }
  }
}