using Microsoft.EntityFrameworkCore;
using ToDoListClone.Dal;
using ToDoListClone.Dal.Entities;

namespace ToDoListClone.Repository.Services;

public class ToDoItemRepository : IToDoItemRepository
{
    private readonly MainContext mainContext;

    public ToDoItemRepository(MainContext mainContext)
    {
        this.mainContext = mainContext;
    }

    public Task DeleteToDoItemByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<long> InsertToDoItemAsync(ToDoItem toDoItem)
    {
        throw new NotImplementedException();
    }

    public Task<List<ToDoItem>> SelectAllToDoItemsAsync(int skip = 0, int take = 10)
    {
        var toDoItems = mainContext.ToDoItems
            .Skip(skip)
            .Take(take)
            .ToListAsync();
        return toDoItems;
    }

    public Task<List<ToDoItem>> SelectByDueDateAsync(DateTime dateTime)
    {
        throw new NotImplementedException();
    }

    public Task<List<ToDoItem>> SelectCompletedAsync(int skip = 0, int take = 10)
    {
        throw new NotImplementedException();
    }

    public Task<List<ToDoItem>> SelectIncompleteAsync(int skip = 0, int take = 10)
    {
        throw new NotImplementedException();
    }

    public Task<ToDoItem> SelectToDoItemByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateToDoItemAsync(ToDoItem updateToDoItem)
    {
        throw new NotImplementedException();
    }
}
