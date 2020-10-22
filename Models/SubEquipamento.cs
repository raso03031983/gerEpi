using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{

  [Table("SubEquipamento")]
  public class SubEquipamento
  {
    [Key]
    [Column("ID_SubEquipamento")]
    public int id { get; set; }
    public int Codigo_Equipamento { get; set; }
    public int Codigo_SubEquipamento { get; set; }

    [MaxLength(20, ErrorMessage = "Máximo de 20 caracteres")]
    public string SKU_Externo { get; set; }

    [MaxLength(6, ErrorMessage = "Máximo de 6 caracteres")]
    public string Num_CA { get; set; }
    public DateTime? Validade_CA { get; set; }

    [MaxLength(20, ErrorMessage = "Máximo de 20 caracteres")]
    public string Arquivo_CA { get; set; }
    public int? Num_Lote { get; set; }
    public DateTime? Validade_Lote { get; set; }
    public int? Status { get; set; }
    public int? ID_Fornecedor { get; set; }
    public int? Dias_Durabilidade { get; set; }

    [Column(TypeName = "decimal(12,2)")]
    public Decimal? Preco_Medio { get; set; }

    [Column(TypeName = "decimal(12,2)")]
    public Decimal? UltimoValor_Pago { get; set; }
    public int? Estoque_Minimo { get; set; }
    public int? Estoque_Maximo { get; set; }
    public byte[] Img_SubEquipamento { get; set; }

    [MaxLength(255, ErrorMessage = "Máximo de 255 caracteres")]
    public string Observacao { get; set; }

    [MaxLength(13, ErrorMessage = "Máximo de 13 caracteres")]
    public string Codigo_Barras { get; set; }

    [Required(ErrorMessage = "Cód. Cliente é Obrigatório")]
    public int? id_cliente { get; set; }

  }
}