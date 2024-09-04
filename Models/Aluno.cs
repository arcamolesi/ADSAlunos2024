using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ADSAlunos2024.Models
{
    [Table("Alunos")]
    public class Aluno
    {   
        public enum Periodo { Manha, Tarde, Noite};

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name ="ID: ")]
        public int id { get; set; }
        
        [Required(ErrorMessage = "Campo nome é obrigatório")]
        [StringLength(35)]
        [Display(Name = "Nome: ")]
        public string nome { get; set; }

        [Display(Name ="Data de Aniversário: ")]
        public DateTime aniversario { get; set; }

        [Display(Name ="Curso: ")]
        public Curso curso { get; set; }
        [Display(Name = "Curso: ")]
        public  int cursoID { get; set; }

        [Display(Name = "Período: ")]
        public Periodo periodo { get; set; }

    }
}
