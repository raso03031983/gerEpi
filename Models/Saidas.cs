using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{

  [Table("Saidas")]
  public class Saidas
  {
    [Key]
    public int? ID_Empresa { get; set; }
    public int? ID_SubEquipamento { get; set; }
    public char? ID_Operacao { get; set; }
    public int? Num_Documento { get; set; }
    public int? Qtd_Saida { get; set; }
    public DateTime? DtHor_Saida { get; set; }
    public string Usuario_Saida { get; set; }

    [Required(ErrorMessage = "Cód. Cliente é Obrigatório")]
    public int? id_cliente { get; set; }

  }
}