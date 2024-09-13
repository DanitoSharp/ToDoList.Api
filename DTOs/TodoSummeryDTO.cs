namespace ToDoList.Api.DTOs;

public record class TodoSummeryDTO (
    int Id,
    
    string Name,

    string Description,

    string Priority,

    string Status,

    DateTime DateAdded,

    DateTime DueDate

);