using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{

  [Table("Tipo_Operacao")]
  public class Tipo_Operacoes
  {
    [Key]
    [Column("ID_Operacao")]
    public int id { get; set; }

    public char? Tipo_Operacao { get; set; }
    public char? Operacao_ES { get; set; }

    [MaxLength(50, ErrorMessage = "Máximo de 50 caracteres")]
    public string DescricaoTipo_Operacao { get; set; }

    [Required(ErrorMessage = "Cód. Cliente é Obrigatório")]
    public int? id_cliente { get; set; }

  }
}