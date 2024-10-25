using ADSAlunos2024.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace ADSAlunos2024.Controllers
{
    public class ConsultasController : Controller
    {
        private readonly Contexto contexto;

        public ConsultasController(Contexto context)
        {
            contexto = context;
        }


        public IActionResult AtendimentosPorTipo ()
        {
            var lista = contexto.Atendimentos
                .Include(a=>a.aluno).Include(s =>s.sala)
                .OrderBy(t =>t.tipo).ThenBy(s =>s.sala.descricao)
                .ThenByDescending(a =>a.aluno.nome)
                .ToList(); 

            return View(lista);
        }

        public IActionResult FiltrarAluno () { 
            return View();  
        }

        public IActionResult ResFiltrarAluno(int ?id, string nome,DateTime ?dataIni, DateTime ?dataFim)
        {
            List<Aluno> listaAlunos = new List<Aluno>();

            if (dataIni != null && dataFim != null) //filtra por período de data
                listaAlunos = contexto.Alunos.Include(a => a.curso).Where(dt => dt.aniversario >= dataIni && dt.aniversario <= dataFim).OrderBy(n => n.aniversario).ToList();

            else if (id != null) //filtrar por id
                listaAlunos = contexto.Alunos.Include(a => a.curso).Where(a => a.id == id).ToList();
            else
                   if (!nome.IsNullOrEmpty()) //filtrar por nome 
                                              //listaAlunos = contexto.Alunos.Include(a => a.curso).Where(n=>n.nome==nome).ToList();
                listaAlunos = contexto.Alunos.Include(a => a.curso).Where(n => n.nome.Contains(nome)).OrderBy(o => o.nome).ToList();

            else
                listaAlunos = contexto.Alunos.Include(a => a.curso).ToList();
                       
            return View(listaAlunos);
        }
    }
}
