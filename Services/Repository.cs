using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoList.Api.DataContext;

// using ToDoList.Api.DataContext;
using ToDoList.Api.DTOs;
using ToDoList.Api.Mapper;
using ToDoList.Api.Models;

namespace ToDoList.Api.Services;

public class Repository : IRepository
{
    private readonly ApplicationDbContext DbContext;
    private readonly UserManager<ApplicationUser> userManager;
    public Repository(ApplicationDbContext _dbContext, UserManager<ApplicationUser> _userManager)
    {
        DbContext = _dbContext;
        userManager = _userManager;
    }

    public async Task<ToDoModel?> CreateTodo(CreateToDoDTO todo, string userId)
    {
        var item = new ToDoModel()
        {
            Name = todo.Name,
            Description = todo.Description,
            PriorityId = todo.PriorityId,
            Priority = DbContext.Priority.Find(todo.PriorityId),
            StatusId = todo.StatusId,
            Status = DbContext.Status.Find(todo.StatusId),
            DateAdded = DateTime.Now,
            DueDate = todo.DueDate
        };

        var user = await userManager.FindByEmailAsync(userId);

        item.UserId = user!.Id;
        item.User = user;

        DbContext.Todos.Add(item);
        await SaveChangesAsync();

        return item;


    }

    public async Task<bool> DeleteTodo(int id, string userId)
    {



        var user = await userManager.FindByEmailAsync(userId);

        var item = DbContext.Todos.Where(x => x.Id == id && x.UserId == user!.Id)
        .Select(x => x).ToList().First();
        //var item = await DbContext.Todos.FindAsync(id);
        if (item is null) return false;

        DbContext.Todos.Remove(item);

        await SaveChangesAsync();

        return true;




    }

    public async Task<IEnumerable<ToDoModel>?> GetAll(string userId)
    {



        var user = await userManager.FindByEmailAsync(userId);
        return await DbContext.Todos
        .Include(x => x.Priority)
        .Include(x => x.Status)
        .Where(x => x.UserId == user!.Id)
        .Select(x => x).AsNoTracking().ToListAsync();



    }

    public async Task<ToDoModel?> GetSingle(int id, string userId)
    {
        var user = await userManager.FindByEmailAsync(userId);

        var item = await DbContext.Todos
        .Include(x => x.Priority)
        .Include(x => x.Status)
        .Include(x => x.User)
        .FirstOrDefaultAsync(a => a.Id == id);

        if (item == null || item.UserId != user!.Id)
        {
            return null; // Or Unauthorized if it's a valid item but belongs to another user
        }

        return item;

    }

    public async Task SaveChangesAsync()
    {

        await DbContext.SaveChangesAsync();

    }

    public async Task<bool> UpDateTodo(int id, UpdateTodoDTO todo, string userId)
    {


        var item = await DbContext.Todos.FindAsync(id);
        if (item is null) return false;

        var model = new ToDoModel()
        {
            Id = id,
            Name = todo.Name,
            Description = todo.Description,
            PriorityId = todo.PriorityId,
            Priority = DbContext.Priority.Find(todo.PriorityId),
            StatusId = todo.StatusId,
            Status = DbContext.Status.Find(todo.StatusId),
            DueDate = todo.DueDate
        };

        var user = await userManager.FindByEmailAsync(userId);
        model.UserId = user!.Id;
        model.User = user;

        DbContext
        .Entry(item)
        .CurrentValues
        .SetValues(model);

        await SaveChangesAsync();

        return true;

    }


}

