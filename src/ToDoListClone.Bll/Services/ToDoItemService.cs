using Microsoft.EntityFrameworkCore;
using ToDoListClone.Bll.DTOs;
using ToDoListClone.Dal;
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

    public async Task<long> AddToDoItemAsync(ToDoItemCreateDto toDoItemCreateDto)
    {
        return await _toDoItemRepository.InsertToDoItemAsync(CreateDtoToEntity(toDoItemCreateDto));
    }

    public async Task DeleteToDoItemByIdAsync(long id)
    {
        await _toDoItemRepository.DeleteToDoItemByIdAsync(id);
    }

    public async Task<List<ToDoItemGetDto>> GetAllToDoItemsAsync(int skip = 0, int take = 10)
    {
        var toDoItems = await _toDoItemRepository.SelectAllToDoItemsAsync(skip, take);
        return toDoItems.Select(t => MapToGetDto(t)).ToList();
    }
    public async Task<List<ToDoItemGetDto>> GetByDueDateAsync(DateTime dateTime)
    {
        var start = dateTime.Date;
        var end = start.AddDays(1);

        var items = await _toDoItemRepository.SelectAllToDoItemsAsync();

        var filtered =  items
            .Where(x => x.DueDate >= start && x.DueDate < end)
            .Select(x => new ToDoItemGetDto
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                DueDate = x.DueDate,
                CreatedAt = x.CreatedAt,
                IsComplited = x.IsComplited,
            })
            .ToList();

        return filtered;
    }




    public Task<List<ToDoItemGetDto>> GetCompletedAsync(int skip = 0, int take = 10)
    {
        throw new NotImplementedException();
    }

    public Task<List<ToDoItemGetDto>> GetIncompletedAsync(int skip = 0, int take = 10)
    {
        throw new NotImplementedException();
    }

    public async Task<ToDoItemGetDto> GetToDoItemByIdAsync(long id)
    {
        var toDoItem = await _toDoItemRepository.SelectToDoItemByIdAsync(id);
        var toDoItemIdDto = MapToGetDto(toDoItem);
        return toDoItemIdDto;
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
    private ToDoItem CreateDtoToEntity(ToDoItemCreateDto toDoItemCreateDto)
    {
        return new ToDoItem
        {
            Id = toDoItemCreateDto.Id,
            Title = toDoItemCreateDto.Title,
            Description = toDoItemCreateDto.Description,
            DueDate = toDoItemCreateDto.DueDate,
            CreatedAt = toDoItemCreateDto.CreatedAt,
            IsComplited = toDoItemCreateDto.IsComplited
        };
    }

}
