using System;

namespace ToDoList.Api.Models;

public class Status
{
    public int Id { get; set; }
    public required string Name { get; set; }

}

// Basic Status:
// Not Started: Task has not been begun.
// In Progress: Task is currently being worked on.
// Completed: Task has been finished.
// Additional Status:
// Paused: Task has been temporarily stopped.
// Waiting for Feedback: Task is pending input or approval from others.
// Blocked: Task is unable to proceed due to an obstacle.