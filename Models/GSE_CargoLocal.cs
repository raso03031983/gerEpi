using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{

  [Table("GSE_CargoLocal")]
  public class GSE_CargoLocal
  {
    [Key]
    [Column("ID_GSE_CargoLocal")]
    public int id { get; set; }
    public int ID_GSE { get; set; }
    public int ID_Cargo { get; set; }
    public int ID_Local { get; set; }

    [Required(ErrorMessage = "Cód. Cliente é Obrigatório")]
    public int? id_cliente { get; set; }

  }
}