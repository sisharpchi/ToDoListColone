using Microsoft.AspNetCore.Mvc;
using ToDoListClone.Bll.DTOs;
using ToDoListClone.Bll.Services;
using ToDoListClone.Dal.Entities;

namespace ToDoListClone.Api.Controllers;

[Route("api/todo")]
[ApiController]
public class ToDoItemController : ControllerBase
{
    private readonly IToDoItemService _toDoItemService;

    public ToDoItemController(IToDoItemService toDoItemService)
    {
        _toDoItemService = toDoItemService;
    }
    [HttpPost("add")]
    public async Task<long> Add(ToDoItemCreateDto toDoItem)
    {
        var id = await _toDoItemService.AddToDoItemAsync(toDoItem);
        return id;
    } 

    [HttpGet("all")]
    public async Task<List<ToDoItemGetDto>> GetAllToDoItems(int skip = 0, int take = 10)
    {
        var result = await _toDoItemService.GetAllToDoItemsAsync(skip, take);
        return result;
    }
}
