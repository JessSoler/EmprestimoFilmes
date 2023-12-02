using EmprestimoLivros.Data;
using EmprestimoLivros.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmprestimoLivros.Controllers
{
    public class EmprestimoController : Controller
    {

        private readonly ApplicationDbContext _db;
        public EmprestimoController(ApplicationDbContext dbContext)
        {
            _db = dbContext;
        }

        public IActionResult Index()
        {
            IEnumerable<EmprestimosModel> emprestimos = _db.Emprestimos;
            return View(emprestimos);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(EmprestimosModel emprestimos)
        {
            if (ModelState.IsValid)
            {
                _db.Emprestimos.Add(emprestimos); //Enviar emprestimo para o db
                _db.SaveChanges(); //Salvar alterações

                TempData["MessagemSucesso"] = "Cadastro realizado com sucesso!";

                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            EmprestimosModel emprestimo = _db.Emprestimos.FirstOrDefault(x => x.Id == id);
            if (emprestimo == null)
            {
                return NotFound();
            }
            return View(emprestimo);
        }

        [HttpPost]
        public IActionResult Editar(EmprestimosModel emprestimo)
        {
            if (ModelState.IsValid)
            {
                _db.Emprestimos.Update(emprestimo);
                _db.SaveChanges();
                TempData["MessagemSucesso"] = "Edição realizado com sucesso!";
                return RedirectToAction("Index");
            }

            return View(emprestimo);
        }

        [HttpGet]
        public IActionResult Excluir(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            EmprestimosModel emprestimo = _db.Emprestimos.FirstOrDefault(x => x.Id == id);
            if (emprestimo == null)
            {
                return NotFound();
            }
            return View(emprestimo);
        }

        [HttpPost]
        public IActionResult Excluir(EmprestimosModel emprestimo)
        {
            if (emprestimo == null)
            {
                return NotFound();
            }

            _db.Emprestimos.Remove(emprestimo);
            _db.SaveChanges();
            TempData["MessagemSucesso"] = "Exclusão realizado com sucesso!";
            return RedirectToAction("Index");
        }
    }
}
