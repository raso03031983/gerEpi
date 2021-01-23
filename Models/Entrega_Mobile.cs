using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Back.Models
{

  [Table("Entrega_Mobile")]
  public class Entrega_Mobile
  {
    [Key]
    [Column("ID_Sincronizacao")]
    public int id { get; set; }

    // [Required(ErrorMessage = "Descrição Categoria é Obrigatório")]
    // [MaxLength(100, ErrorMessage = "Máximo de 100 caracteres")]
    public DateTime DtHor_Sincronizacao { get; set; }

    public int? ID_EntregaMobile { get; set; }

    public int? ID_Integrante { get; set; }

    public int? Codigo_Equipamento { get; set; }

    public int? Codigo_SubEquipamento { get; set; }

    public string Latitude { get; set; }

    public string Longitude { get; set; }

    public DateTime Data_Entrega { get; set; }

    public string IMEI { get; set; }

    public int Status_EntregaMobile { get; set; }

    [Required(ErrorMessage = "Cód. Cliente é Obrigatório")]
    public int? id_cliente { get; set; }

  }
}