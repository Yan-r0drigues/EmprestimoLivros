using EmprestimoLivros.Data;
using EmprestimoLivros.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmprestimoLivros.Controllers
{
    public class LivroController : Controller
    {
        readonly private ApplicationDbContext db;

        public LivroController(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<LivroModel> livros = db.Livros;
            return View(livros);
        }

        // Funções GET e POST de Cadastrar

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(LivroModel livro)
        {
            if (ModelState.IsValid)
            {
                db.Livros.Add(livro);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View();
        }

        // Funções GET e POST de Editar

        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            LivroModel livro = db.Livros.FirstOrDefault(x => x.Id == id);

            if (livro == null)
            {
                return NotFound();
            }

            return View(livro);
        }

        [HttpPost]
        public IActionResult Editar(LivroModel livro)
        {
            if (ModelState.IsValid)
            {
                var livrodb = db.Livros.Find(livro.Id);

                livrodb.Titulo = livro.Titulo;
                livrodb.Autor = livro.Autor;
                livrodb.Editora = livro.Editora;
                livro.DataPublicacao = livro.DataPublicacao;

                db.Livros.Update(livrodb);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(livro);
        }

        // Funções GET e POST de Excluir

        [HttpGet]
        public IActionResult Excluir(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            LivroModel livros = db.Livros.FirstOrDefault(x => x.Id == id);

            if (livros == null)
            {
                return NotFound();
            }

            return View(livros);
        }

        [HttpPost]
        public IActionResult Excluir(LivroModel livro)
        {
            if (livro == null)
            {
                return NotFound();
            }

            db.Livros.Remove(livro);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
