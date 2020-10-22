using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{

  [Table("Centro_Custo")]
  public class Centro_Custo
  {
    [Key]
    [Column("ID_CentroCusto")]
    public int id { get; set; }

    [Required(ErrorMessage = "Cód. centro de custo é Obrigatório")]
    [MaxLength(20, ErrorMessage = "Máximo de 20 caracteres")]
    public string Codigo_CentroCusto { get; set; }

    [Required(ErrorMessage = "Desc. centro de custo é Obrigatório")]
    [MaxLength(100, ErrorMessage = "Máximo de 20 caracteres")]
    public string Descricao_CentroCusto { get; set; }

    [Required(ErrorMessage = "Cód. Cliente é Obrigatório")]
    public int? id_cliente { get; set; }

  }
}