using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{

  [Table("Integrante_Mobile")]
  public class Integrante_Mobile
  {
    [Key]
    [Column("ID_Integrante")]
    public int id { get; set; }
    public string Matricula { get; set; }
    public string Nome_Integrante { get; set; }
    public string Cargo { get; set; }
    public string Trilha_Identificacao { get; set; }

    [Required(ErrorMessage = "Cód. Cliente é Obrigatório")]
    public int? id_cliente { get; set; }

  }
}