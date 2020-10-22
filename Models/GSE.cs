using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{

  [Table("GSE")]
  public class GSE
  {
    [Key]
    [Column("ID_GSE")]
    public int id { get; set; }

    // [Required(ErrorMessage = "Descrição Categoria é Obrigatório")]
    // [MaxLength(100, ErrorMessage = "Máximo de 100 caracteres")]
    public string Codigo_GSE { get; set; }
    public string Descricao_GSE { get; set; }

    [Required(ErrorMessage = "Cód. Cliente é Obrigatório")]
    public int? id_cliente { get; set; }

  }
}