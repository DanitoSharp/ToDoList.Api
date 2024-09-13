using System;

namespace ToDoList.Api.Models;

public class Priority
{
    public int Id { get; set; }
    public required string Name { get; set; }

    
}
// public enum Status{
//     Complete,
//     Incomplete,
//     Cancelled
// }

// Low: Tasks that can be completed at a leisurely pace.
// Medium: Tasks that require moderate attention and effort.
// High: Urgent tasks that need immediate attention.
// Additional Levels:
// Critical: Tasks that are essential for the project's success and cannot be delayed.
// Urgent: Tasks that require immediate action but may not be as important as critical tasks.
// Deferred: Tasks that can be postponed or rescheduled.
// Custom Levels:
// Customizable labels: Allow users to define their own priority levels based on their specific needs and preferences.