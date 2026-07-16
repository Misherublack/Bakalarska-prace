using Microsoft.AspNetCore.SignalR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddSignalR();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.Urls.Add("http://127.0.0.1:5000/chat");

app.MapRazorPages();

app.MapHub<ChatHub>("/chat");

app.Run();

public class ChatHub : Hub
{
    public async Task SendPrivateMessage(string receiver, string message)
    {
        await Clients.User(receiver).SendAsync("ReceiveMessage", Context.UserIdentifier, message);
    }
}
