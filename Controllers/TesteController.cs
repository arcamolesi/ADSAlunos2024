using ADSAlunos2024.Models;
using Microsoft.AspNetCore.Mvc;
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

            return View();
        }

        //[HttpPost]
      /*  public  IActionResult Create()
        {
            return View(); 
        }
      */


    }
}
