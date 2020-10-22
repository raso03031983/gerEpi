using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{

  [Table("Integrante_Biometria")]
  public class Integrante_Biometria
  {
    [Key]
    public string Matricula { get; set; }
    public string FingerPrint { get; set; }

    [Required(ErrorMessage = "Cód. Cliente é Obrigatório")]
    public int? id_cliente { get; set; }

  }
}