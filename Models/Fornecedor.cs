using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{

  [Table("Fornecedor")]
  public class Fornecedor
  {
    [Key]
    [Column("ID_Fornecedor")]
    public int id { get; set; }

    // [Required(ErrorMessage = "Descrição Categoria é Obrigatório")]
    [MaxLength(50, ErrorMessage = "Máximo de 50 caracteres")]
    public string Nome_Fornecedor { get; set; }

    [MaxLength(50, ErrorMessage = "Máximo de 50 caracteres")]
    public string Nome_Fantasia { get; set; }

    public string CNPJ { get; set; }

    [Required(ErrorMessage = "Cód. Cliente é Obrigatório")]
    public int? id_cliente { get; set; }

  }
}