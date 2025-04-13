using ToDoListClone.Bll.DTOs;

namespace ToDoListClone.Bll.Services;

public interface IToDoItemService
{
    Task<long> AddToDoItemAsync(ToDoItemCreateDto toDoItemCreateDto);
    Task DeleteToDoItemByIdAsync(long id);
    Task UpdateToDoItemAsync(ToDoItemUpdateDto updateToDoItem);
    Task<List<ToDoItemGetDto>> GetAllToDoItemsAsync(int skip = 0, int take = 10);
    Task<ToDoItemGetDto> GetToDoItemByIdAsync(long id);
    Task<List<ToDoItemGetDto>> GetByDueDateAsync(DateTime dateTime);
    Task<List<ToDoItemGetDto>> GetCompletedAsync(int skip = 0, int take = 10);
    Task<List<ToDoItemGetDto>> GetIncompletedAsync(int skip = 0, int take = 10);
}