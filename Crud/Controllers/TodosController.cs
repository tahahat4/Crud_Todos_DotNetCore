using Crud.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Crud.Controllers
{
    public class TodosController : Controller
    {

        public static List<TodoVM> Todos = new List<TodoVM>();
        private static int nextId = 1;


        public IActionResult Index()
        {
            return View(Todos);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(TodoVM todo)
        {
            if (ModelState.IsValid)
            {
                todo.Id = nextId++;
                Todos.Add(todo);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Details(int id)
        {
            var todo = Todos.FirstOrDefault(item => item.Id == id);
            if (todo == null) return NotFound();

            return View(todo);
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var todo = Todos.FirstOrDefault(t => t.Id == id);
            if (todo == null) return NotFound();
            return View(todo);
        }

        // POST: Delete a specific todo
        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var todo = Todos.FirstOrDefault(t => t.Id == id);
            if (todo == null) return NotFound();

            Todos.Remove(todo);
            return RedirectToAction("Index");
        }


        // GET: Display form to edit an existing todo
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var todo = Todos.FirstOrDefault(t => t.Id == id);
            if (todo == null) return NotFound();
            return View(todo);
        }

        [HttpPost]
        public IActionResult Edit(TodoVM updatedTodo)
        {
            if (ModelState.IsValid)
            {
                var todo = Todos.FirstOrDefault(t => t.Id == updatedTodo.Id);
                if (todo == null) return NotFound();

                todo.Title = updatedTodo.Title;
                todo.Description = updatedTodo.Description;
                todo.IsFinished = updatedTodo.IsFinished;
                todo.SelectedTags = updatedTodo.SelectedTags;
                todo.User = updatedTodo.User;
                todo.CreateAd = updatedTodo.CreateAd;

                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
