using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoList.Api.Models;

public class ToDoModel
{

    //Name, Description, Seriousnessm, DateAdded, DueDate

    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public int PriorityId { get; set; }
    public Priority? Priority { get; set; }
    public int StatusId { get; set; }
    public Status? Status { get; set; }

    public DateTime DateAdded { get; set; }
    public DateTime DueDate { get; set; }

    // Foreign Key to ApplicationUser
    public string? UserId { get; set; }

    // Navigation property to ApplicationUser
    public ApplicationUser? User { get; set; }

}
