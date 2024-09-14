using ADSAlunos2024.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ADSAlunos2024.Controllers
{
    public class TesteController : Controller
    {
        private readonly Contexto contexto; 

        public TesteController(Contexto _contexto)
        {
            contexto = _contexto;
        }


        public IActionResult Index()
        {
           // List<Aluno> alunos = contexto.Alunos 
            return View(contexto.Alunos.Include(c => c.curso).ToList());
        }


        [HttpGet]
        public IActionResult Create()
        {
            var tPeriodo = Enum.GetValues(typeof(Periodo))
                   .Cast<Periodo>()
                   .Select(e => new SelectListItem
                   {
                       Value = e.ToString(),
                       Text = e.ToString()
                   });
            ViewBag.tPeriodo = tPeriodo;

            ViewData["listaCursos"] = new SelectList(contexto.Cursos, "id", "descricao");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("id,nome,aniversario,cursoID,periodo")] Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                contexto.Add(aluno);
                contexto.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            
            ViewData["listaCursos"] = new SelectList(contexto.Cursos, "id", "descricao", aluno.cursoID);
            
            return View(aluno);
        }


        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //procurando o aluno por id
            var aluno = contexto.Alunos.Find(id);
            if (aluno == null)
            {
                return NotFound();
            }

            ViewData["listaCursos"] = new SelectList(contexto.Cursos, "id", "descricao", aluno.cursoID);
            return View(aluno);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Edit(int id, [Bind("id,nome,aniversario,cursoID,periodo")] Aluno aluno)
        {
            if (id != aluno.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    contexto.Update(aluno);
                    contexto.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlunoExists(aluno.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["cursoID"] = new SelectList(contexto.Cursos, "id", "descricao", aluno.cursoID);
            return View(aluno);
        }

        private bool AlunoExists(int id)
        {
            return contexto.Alunos.Any(e => e.id == id);
        }


        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluno = contexto.Alunos.Include(a => a.curso).FirstOrDefault(m => m.id == id);
            if (aluno == null)
            {
                return NotFound();
            }

            return View(aluno);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var aluno =contexto.Alunos.Find(id);
            if (aluno != null)
            {
                contexto.Alunos.Remove(aluno);
            }

           contexto.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluno = contexto.Alunos
                .Include(a => a.curso)
                .FirstOrDefault(m => m.id == id);
            if (aluno == null)
            {
                return NotFound();
            }

            return View(aluno);
        }


    }
}
