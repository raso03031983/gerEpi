using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{

  [Table("Cargo")]
  public class Cargo
  {
    [Key]
    [Column("ID_Cargo")]
    public int id { get; set; }

    [Required(ErrorMessage = "Cód. Cargo é Obrigatório")]
    [MaxLength(10, ErrorMessage = "Máximo de 10 caracteres")]
    public string Codigo_Cargo { get; set; }

    [Required(ErrorMessage = "Descrição Cargo é Obrigatório")]
    [MaxLength(100, ErrorMessage = "Máximo de 100 caracteres")]
    public string Descricao_Cargo { get; set; }

    public string CBO { get; set; }

    [Required(ErrorMessage = "Cód. Cliente é Obrigatório")]
    public int id_cliente { get; set; }

  }
}