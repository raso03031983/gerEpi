using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{

  [Table("EPI_Entregue")]
  public class EPI_Entregue
  {
    [Key]
    [Column("ID_Entrega")]
    public int id { get; set; }

    public int? ID_Cargo { get; set; }

    public string ID_Integrante { get; set; }

    public string Matricula { get; set; }

    public DateTime? DtHor_Entrega { get; set; }

    public int? ID_UsuarioEntrega { get; set; }

    public int? ID_Local { get; set; }

    public string Codigo_Equipamento { get; set; }

    public string Codigo_SubEquipamento { get; set; }

    public int? Qtd_Entregue { get; set; }

    [Column(TypeName = "decimal(12,4)")]
    public decimal? Vlr_Item { get; set; }

    public int? Qtd_Troca { get; set; }

    public string Observacao { get; set; }

    public DateTime? DtHor_Troca { get; set; }

    public int? ID_UsuarioTroca { get; set; }

    public byte[] Img_Entrega { get; set; }

    public string Latitude { get; set; }

    public string Longitude { get; set; }

    public char? Entrega_Antecipada { get; set; }

    public int? ID_Motivo_Troca { get; set; }

    public char? Entrega_Biometria { get; set; }

    [Required(ErrorMessage = "Cód. Cliente é Obrigatório")]
    public int? id_cliente { get; set; }

  }
}