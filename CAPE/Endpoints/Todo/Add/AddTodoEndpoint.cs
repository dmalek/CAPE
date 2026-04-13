namespace CAPE.Endpoints.Todo.Add;

public static class AddTodoEndpoint
{
    public static void MapAddTodo(this IEndpointRouteBuilder app)
    {
        app.MapPost("/todo", async (AddTodoRequest request) =>
        {
            // logika
            return Results.Ok(new AddTodoResponse());
        });
    }
}