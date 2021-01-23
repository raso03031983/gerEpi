using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Back.Models
{

  [Table("Classificacao")]
  public class Classificacao
  {
    [Key]
    [Column("ID_Classificacao")]
    public int id { get; set; }

    public int ID_Familia { get; set; }
    
    public string Descricao_Familia { get; set; }

    public int ID_Divisao { get; set; }
    public string Descricao_Divisao { get; set; }
    public int ID_Categoria { get; set; }
    public string Descricao_Categoria { get; set; }

    [Required(ErrorMessage = "Cód. Cliente é Obrigatório")]
    public int id_cliente { get; set; }

  }
}