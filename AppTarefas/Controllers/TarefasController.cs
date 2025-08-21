using AppTarefas.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppTarefas.Controllers
{
    public class TarefasController : Controller
    {
        // Lista em memória(grava as informações apenas quando a aplicação está rodando)
        private static List<Tarefa> _tarefas = new List<Tarefa>();
        private static int _proximoId = 1;

        // GET: Tarefas
        public IActionResult Index()
        {
            return View(_tarefas); // Envia a lista de tarefas como parametro para a pagina Index.
        }

        // GET: Tarefas/Create
        // Get -> Metodo para "pegar" a pagina e exibir
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tarefas/Create
        [HttpPost] // Especifica que este método responde a requisições POST
        [ValidateAntiForgeryToken] // Protege contra ataques
        public IActionResult Create(Tarefa tarefa)
        {
            if (ModelState.IsValid)
            {
                // Atribui um ID único para a tarefa
                tarefa.TarefaId = _proximoId++;
                // Adiciona a tarefa à lista de tarefas (_tarefas)
                _tarefas.Add(tarefa);
                // Redireciona para a página Index
                return RedirectToAction("Index");
            }
            return View(tarefa);
        }


    }
}
