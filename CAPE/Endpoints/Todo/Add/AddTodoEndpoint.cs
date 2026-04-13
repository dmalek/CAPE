using CAPE.Context;
using CAPE.Context.Models;

namespace CAPE.Endpoints.Todo.Add;

public static class AddTodoEndpoint
{
    public static void MapAddTodo(this IEndpointRouteBuilder app)
    {
        app.MapPost("/todo", async (AddTodoRequest request, AppDbContext context) =>
        {
            context.Add(new TodoItem
            {
                Title = request.Title,
                Description = request.Description,
                UserEmail = request.UserEmail,
                DueDate = request.DueDate.Value,
                Status = request.Status
            });

            await context.SaveChangesAsync();

            return Results.Ok(new AddTodoResponse());
        });
    }
}