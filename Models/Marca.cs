using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{

  [Table("Marca")]
  public class Marca
  {
    [Key]
    [Column("ID_Marca")]
    public int id { get; set; }

    // [Required(ErrorMessage = "Descrição Categoria é Obrigatório")]
    [MaxLength(50, ErrorMessage = "Máximo de 50 caracteres")]
    public string Descricao_Marca { get; set; }

    [Required(ErrorMessage = "Cód. Cliente é Obrigatório")]
    public int? id_cliente { get; set; }

  }
}