using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Back.Models
{

  [Table("Divisao")]
  public class Divisao
  {
    [Key]
    [Column("ID_Divisao")]
    public int id { get; set; }

    //[Required(ErrorMessage = "Descrição Categoria é Obrigatório")]
    [MaxLength(100, ErrorMessage = "Máximo de 100 caracteres")]
    public string Descricao_Divisao { get; set; }

    public byte[] Img_Divisao { get; set; }


    [Required(ErrorMessage = "Cód. Cliente é Obrigatório")]
    public int id_cliente { get; set; }

  }
}