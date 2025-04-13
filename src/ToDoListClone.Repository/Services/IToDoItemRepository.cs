using ToDoListClone.Dal.Entities;

namespace ToDoListClone.Repository.Services;

public interface IToDoItemRepository
{
    Task<long> InsertToDoItemAsync(ToDoItem toDoItem);
    Task DeleteToDoItemByIdAsync(long id);
    Task UpdateToDoItemAsync(ToDoItem updateToDoItem);
    Task<List<ToDoItem>> SelectAllToDoItemsAsync(int skip = 0, int take = 10);
    Task<ToDoItem> SelectToDoItemByIdAsync(long id);
    Task<List<ToDoItem>> SelectByDueDateAsync(DateTime dateTime);
    Task<List<ToDoItem>> SelectCompletedAsync(int skip = 0, int take = 10);
    Task<List<ToDoItem>> SelectIncompleteAsync(int skip = 0, int take = 10);
}