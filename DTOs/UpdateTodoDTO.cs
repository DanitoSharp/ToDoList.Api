using System.ComponentModel.DataAnnotations;

namespace ToDoList.Api.DTOs;

public record class UpdateTodoDTO
(
    [Required] string Name,

    [Required, StringLength(100)] string Description,

    int PriorityId,

    int StatusId,

    [Required] DateTime DueDate
);