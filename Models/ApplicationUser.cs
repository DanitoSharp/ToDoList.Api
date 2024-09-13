using System;
using Microsoft.AspNetCore.Identity;

namespace ToDoList.Api.Models;

public class ApplicationUser : IdentityUser
{

    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string FullName => FirstName + " " + LastName;
    public DateOnly DateOfBirth { get; set; }
}
    
