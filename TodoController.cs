using Microsoft.AspNetCore.Mvc;
using List_of_Task.Models;
using List_of_Tasks.Contexts;
namespace List_of_Task.Controllers;

public class TodoController: Controller
{
    private readonly List_of_TasksContext _context;

    public TodoController(List_of_TasksContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        ViewData ["Title"] = "Lista de tarefas";

        var todos = _context.Todos.ToList();
        return View(todos);
    }

    public IActionResult Create()
    {
        ViewData["Title"] = "Nova Tarefa";
        return View("Form");
    }
    
    [HttpPost]
    public IActionResult Create(Todo todo)
    {
        if(ModelState.IsValid)
        {
            todo.CreatedAt = DateTime.Now;
            _context.Todos.Add(todo);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        ViewData["Title"] = "Nova Tarefa";
        return View("Form", todo);
    }

    public IActionResult Edit(int id)
    {
       var todo = _context.Todos.Find(id);
       ViewData["Title"] = "Editar tarefa";
       return View("Form", todo);
    }

    [HttpPost]
    public IActionResult Edit(Todo todo)
    {
        if(ModelState.IsValid)
        {
            todo.CreatedAt = DateTime.Now;
            _context.Todos.Update(todo);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        ViewData["Title"] = "Editar tarefa";
        return View("Form", todo);    
    }

    public IActionResult Delete(int id)
    {
        var todo = _context.Todos.Find(id);
        ViewData["Title"] = "Excluir tarefa";
        return View(todo);
    }

    [HttpPost]
    public IActionResult Delete(Todo todo)
    {
        _context.Todos.Remove(todo);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }
}