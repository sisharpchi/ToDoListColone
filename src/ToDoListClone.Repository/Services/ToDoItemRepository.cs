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

    public async Task DeleteToDoItemByIdAsync(long id)
    {
        var toDoItemId = await SelectToDoItemByIdAsync(id);
        mainContext.ToDoItems.Remove(toDoItemId);
        await mainContext.SaveChangesAsync();
    }

    public async Task<long> InsertToDoItemAsync(ToDoItem toDoItem)
    {
        await mainContext.AddAsync(toDoItem);
        await mainContext.SaveChangesAsync();
        return toDoItem.Id;
    }

    public Task<List<ToDoItem>> SelectAllToDoItemsAsync(int skip = 0, int take = 10)
    {
        var toDoItems = mainContext.ToDoItems
            .Skip(skip)
            .Take(take)
            .ToListAsync();
        return toDoItems;
    }

    public async Task<List<ToDoItem>> SelectByDueDateAsync(DateTime dateTime)
    {
        return await mainContext.ToDoItems
            .Where(b => b.DueDate.Date == dateTime.Date)
            .ToListAsync();
    }

    public Task<List<ToDoItem>> SelectCompletedAsync(int skip = 0, int take = 10)
    {
        throw new NotImplementedException();
    }

    public Task<List<ToDoItem>> SelectIncompleteAsync(int skip = 0, int take = 10)
    {
        throw new NotImplementedException();
    }

    public async Task<ToDoItem> SelectToDoItemByIdAsync(long id)
    {
        var toDoItemId = await mainContext.ToDoItems.FirstOrDefaultAsync(b => b.Id == id);
        if (toDoItemId is null)
        {
            throw new Exception("wrong id");
        }
        return toDoItemId;
    }

    public Task UpdateToDoItemAsync(ToDoItem updateToDoItem)
    {
        throw new NotImplementedException();
    }
}
