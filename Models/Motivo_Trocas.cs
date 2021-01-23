using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Back.Models
{

    [Table("Motivo_Troca")]
    public class Motivo_Trocas
    {
        [Key]
        [Column("ID_Motivo_Troca")]
        public int id { get; set; }

        // [Required(ErrorMessage = "Descri��o Categoria � Obrigat�rio")]
        [MaxLength(100, ErrorMessage = "M�ximo de 100 caracteres")]
        public string Motivo_Troca { get; set; }

        [Required(ErrorMessage = "C�d. Cliente � Obrigat�rio")]
        public int? id_cliente { get; set; }

    }
}