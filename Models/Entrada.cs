using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Back.Models
{

  [Table("Entradas")]
  public class Entrada
  {
    [Key]
    public int? ID_Empresa { get; set; }
    public int ID_SubEquipamento { get; set; }
    public char ID_Operacao { get; set; }

    // [Required(ErrorMessage = "Descrição Categoria é Obrigatório")]
    [MaxLength(100, ErrorMessage = "Máximo de 20 caracteres")]
    public string Num_Documento { get; set; }
    public int? Qtd_Entrada { get; set; }
    public DateTime? DtHor_Entrada { get; set; }

    [MaxLength(100, ErrorMessage = "Máximo de 50 caracteres")]
    public string Usuario_Entrada { get; set; }

    [Required(ErrorMessage = "Cód. Cliente é Obrigatório")]
    public int? id_cliente { get; set; }

  }
}