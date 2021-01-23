using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Back.Models
{

  [Table("Cargo")]
  public class Cargo
  {
    [Key]
    [Column("ID_Cargo")]
    public int id { get; set; }

    public string Codigo_Cargo { get; set; }

    public string Descricao_Cargo { get; set; }

    public string CBO { get; set; }

    [Required(ErrorMessage = "Cód. Cliente é Obrigatório")]
    public int id_cliente { get; set; }

  }
}