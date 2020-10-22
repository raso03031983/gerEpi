using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{

  [Table("Empresa")]
  public class Empresa
  {
    [Key]
    [Column("ID_Empresa")]
    public int id { get; set; }

    // [Required(ErrorMessage = "Descrição Categoria é Obrigatório")]
    [MaxLength(100, ErrorMessage = "Máximo de 50 caracteres")]
    public string Nome_Fantasia { get; set; }

    [MaxLength(100, ErrorMessage = "Máximo de 14 caracteres")]
    public string CNPJ { get; set; }

    [MaxLength(100, ErrorMessage = "Máximo de 50 caracteres")]
    public string Razao_Social { get; set; }

    [MaxLength(100, ErrorMessage = "Máximo de 50 caracteres")]
    public string Endereco { get; set; }

    [MaxLength(100, ErrorMessage = "Máximo de 10 caracteres")]
    public string Numero { get; set; }

    [MaxLength(100, ErrorMessage = "Máximo de 50 caracteres")]
    public string Complemento { get; set; }

    [MaxLength(100, ErrorMessage = "Máximo de 50 caracteres")]
    public string Bairro { get; set; }

    [MaxLength(100, ErrorMessage = "Máximo de 50 caracteres")]
    public string Cidade { get; set; }

    [MaxLength(100, ErrorMessage = "Máximo de 10 caracteres")]
    public string CEP { get; set; }

    public byte[] Img_Empresa { get; set; }

    public byte[] Img_Padrao { get; set; }

    public string Mobile { get; set; }

    public int? Status { get; set; }

    [Required(ErrorMessage = "Cód. Cliente é Obrigatório")]
    public int? id_cliente { get; set; }

  }
}