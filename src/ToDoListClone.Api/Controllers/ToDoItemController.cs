using Microsoft.AspNetCore.Mvc;
using ToDoListClone.Bll.DTOs;
using ToDoListClone.Bll.Services;

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

    [HttpGet("all")]
    public async Task<List<ToDoItemGetDto>> GetAllToDoItems(int skip = 0, int take = 10)
    {
        var result = await _toDoItemService.GetAllToDoItemsAsync(skip, take);
        return result;
    }
}
