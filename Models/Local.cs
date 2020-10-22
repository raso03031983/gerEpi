using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{

  [Table("Local")]
  public class Local
  {
    [Key]
    [Column("ID_Local")]
    public int id { get; set; }

    [MaxLength(50, ErrorMessage = "Máximo de 50 caracteres")]
    public string Descricao_Local { get; set; }

    [Required(ErrorMessage = "Cód. Cliente é Obrigatório")]
    public int? id_cliente { get; set; }

  }
}