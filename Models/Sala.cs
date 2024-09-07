using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ADSAlunos2024.Models
{
    [Table("Salas")]
    public class Sala
    {
        [Display(Name ="ID: ")]
        public int id { get; set; }

        [Display(Name = "Desscrição: ")]
        [StringLength(35)]
        [Required(ErrorMessage = "Campo descrição é obrigatório..")]
        public string descricao { get; set; }

        [Display(Name = "Quantidade Equipamento: ")]
        [Required(ErrorMessage ="Campo equipamentos é obrigatório..")]
        public int equipamento { get; set; }

        [Display(Name = "Situação: ")]
        [Required(ErrorMessage ="Campo Situação é obrigatório...")]
        public char situacao { get; set; }
        
    }
}
