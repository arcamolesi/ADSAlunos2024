using ADSAlunos2024.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
    }
}
