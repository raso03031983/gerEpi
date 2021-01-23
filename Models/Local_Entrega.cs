using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Back.Models
{

  [Table("Local_Entrega")]
  public class Local_Entrega
  {
    [Key]
    [Column("ID_Local")]
    public int id { get; set; }

    // [Required(ErrorMessage = "Descrição Categoria é Obrigatório")]
    [MaxLength(50, ErrorMessage = "Máximo de 50 caracteres")]
    public string Descricao_Local { get; set; }

    [Required(ErrorMessage = "Cód. Cliente é Obrigatório")]
    public int? id_cliente { get; set; }

  }
}