using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Back.Models
{

    [Table("Nota_Entrada")]
    public class Nota_Entrada
    {
        [Key]
        [Column("ID_Nota_Entrada")]
        public int id { get; set; }

        // [Required(ErrorMessage = "Descri��o Categoria � Obrigat�rio")]
        [MaxLength(20, ErrorMessage = "M�ximo de 20 caracteres")]
        public string Numero_NF { get; set; }

        public DateTime? Data_NF { get; set; }

        public int? ID_Fornecedor { get; set; }

        [Required(ErrorMessage = "C�d. Cliente � Obrigat�rio")]
        public int? id_cliente { get; set; }

    }
}