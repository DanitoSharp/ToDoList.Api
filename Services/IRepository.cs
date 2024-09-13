using System;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Api.DTOs;
using ToDoList.Api.Models;

namespace ToDoList.Api.Services;

public interface IRepository
{
    Task<IEnumerable<ToDoModel>?> GetAll(string userId);
    Task<ToDoModel?> GetSingle(int id, string userId);
    Task<ToDoModel?> CreateTodo(CreateToDoDTO todo, string userId);
    Task<bool> UpDateTodo(int id, UpdateTodoDTO todo, string userId);
    Task<bool> DeleteTodo(int id, string userId);
    Task SaveChangesAsync();


}
