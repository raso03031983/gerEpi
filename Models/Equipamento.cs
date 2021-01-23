using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Back.Models
{

  [Table("Equipamento")]
  public class Equipamento
  {
    [Key]
    [Column("Codigo_Equipamento")]
    public int id { get; set; }

    // [Required(ErrorMessage = "Descrição Categoria é Obrigatório")]
    // [MaxLength(100, ErrorMessage = "Máximo de 100 caracteres")]
    public string Descricao_Equipamento { get; set; }

    public int? ID_Grade { get; set; }

    public string Tamanho { get; set; }

    public string Unidade_Equipamento { get; set; }

    public int? ID_Familia { get; set; }
    public string Descricao_Familia { get; set; }

    public int? ID_Divisao { get; set; }
    public string Descricao_Divisao { get; set; }

    public int? ID_Categoria { get; set; }
    public string Descricao_Categoria { get; set; }

    public char? Equipamento_EmbMultipla { get; set; }

    public int? Status { get; set; }

        public string StatusDesc { get; set; }

        public int? Mobile { get; set; }

    [Required(ErrorMessage = "Cód. Cliente é Obrigatório")]
    public int? id_cliente { get; set; }

  }
}