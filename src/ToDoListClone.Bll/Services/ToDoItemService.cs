using ToDoListClone.Bll.DTOs;
using ToDoListClone.Dal.Entities;
using ToDoListClone.Repository.Services;

namespace ToDoListClone.Bll.Services;

public class ToDoItemService : IToDoItemService
{
    private readonly IToDoItemRepository _toDoItemRepository;

    public ToDoItemService(IToDoItemRepository toDoItemRepository)
    {
        _toDoItemRepository = toDoItemRepository;
    }

    public Task<long> AddToDoItemAsync(ToDoItemCreateDto toDoItemCreateDto)
    {
        throw new NotImplementedException();
    }

    public Task DeleteToDoItemByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<ToDoItemGetDto>> GetAllToDoItemsAsync(int skip = 0, int take = 10)
    {
        var toDoItems = await _toDoItemRepository.SelectAllToDoItemsAsync(skip, take);
        return toDoItems.Select(t => MapToGetDto(t)).ToList();
    }

    public Task<List<ToDoItemGetDto>> GetByDueDateAsync(DateTime dateTime)
    {
        throw new NotImplementedException();
    }

    public Task<List<ToDoItemGetDto>> GetCompletedAsync(int skip = 0, int take = 10)
    {
        throw new NotImplementedException();
    }

    public Task<List<ToDoItemGetDto>> GetIncompletedAsync(int skip = 0, int take = 10)
    {
        throw new NotImplementedException();
    }

    public Task<ToDoItemGetDto> GetToDoItemByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateToDoItemAsync(ToDoItemUpdateDto updateToDoItem)
    {
        throw new NotImplementedException();
    }

    private ToDoItemGetDto MapToGetDto(ToDoItem toDoItem)
    {
        return new ToDoItemGetDto
        {
            Id = toDoItem.Id,
            Title = toDoItem.Title,
            Description = toDoItem.Description,
            DueDate = toDoItem.DueDate,
            CreatedAt = toDoItem.CreatedAt,
            IsComplited = toDoItem.IsComplited
        };
    }
}
