using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{

  [Table("Log_Integrante")]
  public class Log_Integrante
  {
    [Key]
    [Column("Id")]
    public int id { get; set; }
    public DateTime? DtHor_Atualizacao { get; set; }

    [MaxLength(100, ErrorMessage = "Máximo de 100 caracteres")]
    public string Login { get; set; }

    [MaxLength(100, ErrorMessage = "Máximo de 100 caracteres")]
    public string Hostname { get; set; }

    [MaxLength(20, ErrorMessage = "Máximo de 20 caracteres")]
    public string Operacao { get; set; }
    public int? ID_Empresa { get; set; }

    [MaxLength(20, ErrorMessage = "Máximo de 20 caracteres")]
    public string Matricula { get; set; }

    [MaxLength(100, ErrorMessage = "Máximo de 100 caracteres")]
    public string Nome_Integrante { get; set; }
    public int? ID_Cargo { get; set; }
    public int? ID_Local { get; set; }
    public int? ID_CentroCusto { get; set; }
    public DateTime? Data_Admissao { get; set; }
    public DateTime? Data_Demissao { get; set; }
    public char? Situacao { get; set; }
    public char? Tipo_MO { get; set; }
    public DateTime? DtHor_UltAtualizacao { get; set; }
    public byte[] Img_Integrante { get; set; }

    [MaxLength(100, ErrorMessage = "Máximo de 100 caracteres")]
    public string PWD { get; set; }

    [MaxLength(20, ErrorMessage = "Máximo de 20 caracteres")]
    public string Cracha { get; set; }
    public int? ID_UsuarioCadastro { get; set; }
    public DateTime? DtHor_Cadastro { get; set; }
    public int? ID_UsuarioUltAlteracao { get; set; }
    public DateTime? DtHorUlt_Alteracao { get; set; }

    [Required(ErrorMessage = "Cód. Cliente é Obrigatório")]
    public int? id_cliente { get; set; }

  }
}