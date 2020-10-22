using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{

  [Table("Motivo_Troca")]
  public class Motivo_Trocas
  {
    [Key]
    [Column("ID_Motivo_Troca")]
    public int id { get; set; }

    // [Required(ErrorMessage = "Descrição Categoria é Obrigatório")]
    [MaxLength(100, ErrorMessage = "Máximo de 100 caracteres")]
    public string Motivo_Troca { get; set; }

    [Required(ErrorMessage = "Cód. Cliente é Obrigatório")]
    public int? id_cliente { get; set; }

  }
}