using Microsoft.AspNetCore.SignalR.Client;

Console.WriteLine("Starting SignalR client...");

// Adjust this to match your backend's URL and port
var connection = new HubConnectionBuilder()
    .WithUrl("https://localhost:7087/notifaction-hub") // or the correct port in your backend
    .WithAutomaticReconnect()
    .Build();

// Handle incoming messages (optional for now)
connection.On<string>("ReceivedMessage", message =>
{
    Console.WriteLine($"[Message from server]: {message}");
});

try
{
    await connection.StartAsync();
    Console.WriteLine("Connected to SignalR hub!");

    // Optional: Join a book club group for testing
    Console.Write("Enter Book Club ID to join group: ");
    var bookClubId = Console.ReadLine();
    await connection.InvokeAsync("JoinBookClubGroup", bookClubId);

    Console.WriteLine("Joined book club group.");
}
catch (Exception ex)
{
    Console.WriteLine($"Error connecting: {ex.Message}");
}

Console.WriteLine("Press any key to exit...");
Console.ReadKey();
