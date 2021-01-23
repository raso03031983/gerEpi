using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Back.Models
{

  [Table("Grade_Tamanho")]
  public class Grade_Tamanho
  {
    [Key]
    [Column("ID_Grade")]
    public int id { get; set; }

    public int ID_Divisao { get; set; }

    public string Tamanho { get; set; }

    [Required(ErrorMessage = "Cód. Cliente é Obrigatório")]
    public int? id_cliente { get; set; }

  }
}