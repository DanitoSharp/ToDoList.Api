using System;
using ToDoList.Api.DTOs;
using ToDoList.Api.Models;

namespace ToDoList.Api.Mapper;

public static class Mapper
{

    public static TodoSummeryDTO MapToSummeryDTO(this ToDoModel model)
    {

        var summeryObject = new TodoSummeryDTO(
            model!.Id,
            model.Name,
            model.Description,
            model.Priority!.Name,
            model.Status!.Name,
            model.DateAdded,
            model.DueDate
        );

        return summeryObject;
    }

}
