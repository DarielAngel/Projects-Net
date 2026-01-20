using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using TaskMaster.Data;
using TaskMaster.Domain.Entities;

namespace TaskMaster.API.Controllers;

[ApiController]
[Route("api/Tasks")]
public class TasksController : ControllerBase
{
    private readonly AppDbContext _context;

    public TasksController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TodoTask>>> GetTasks()
        => await _context.Tasks.ToListAsync();

    [HttpPost]
    public async Task<ActionResult<TodoTask>> Create(TodoTask task)
    {
        _context.Tasks.Add(task);
        await _context.SaveChangesAsync();

        return Ok(task);
    }
}