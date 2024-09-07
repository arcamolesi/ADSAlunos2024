using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ADSAlunos2024.Models
{
    [Table("Atendimentos")]
    public class Atendimento
    {
        [Display(Name = "ID: ")]
        public int id { get; set; }

        [Display(Name = "Aluno: ")]
        [StringLength(35)]
        public Aluno aluno { get; set; }
        [Display(Name = "Aluno: ")]
        public int alunoID { get; set; }

        [Display(Name = "Sala: " )]
        public Sala sala { get; set; }
        [Display(Name = "Sala: ")]
        public int salaID { get; set; }

        [Display(Name = "Data: " )]
        public DateTime data { get; set; }
    }
}
