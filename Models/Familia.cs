using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Back.Models
{

  [Table("Familia")]
  public class Familia
  {
    [Key]
    [Column("ID_Familia")]
    public int id { get; set; }

    // [Required(ErrorMessage = "Descrição Categoria é Obrigatório")]
    [MaxLength(50, ErrorMessage = "Máximo de 50 caracteres")]
    public string Descricao_Familia { get; set; }

    public byte[] Img_Familia { get; set; }

    [Required(ErrorMessage = "Cód. Cliente é Obrigatório")]
    public int? id_cliente { get; set; }

  }
}