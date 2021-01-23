using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Back.Models
{

    [Table("SubEquipamento")]
    public class SubEquipamento
  {
        [Key]
        public int id { get; set; }
    public int Codigo_Equipamento { get; set; }
    public int Codigo_SubEquipamento { get; set; }

   
    public string SKU_Externo { get; set; }

    
    public string Num_CA { get; set; }
    public DateTime Validade_CA { get; set; }

    
    public string Arquivo_CA { get; set; }
    public int? Num_Lote { get; set; }
    public DateTime? Validade_Lote { get; set; }
    public int? Status { get; set; }
    public int? ID_Fornecedor { get; set; }
    public int? Dias_Durabilidade { get; set; }

    public Decimal? Preco_Medio { get; set; }

    public Decimal? UltimoValor_Pago { get; set; }
    public int? Estoque_Minimo { get; set; }
    public int? Estoque_Maximo { get; set; }
    public byte[] Img_SubEquipamento { get; set; }

    public string Observacao { get; set; }

    public string Codigo_Barras { get; set; }

    public int? id_cliente { get; set; }

  }
}