using ContainerTransport;

namespace CleanContainerTransport;

public static class Program
{
    public static string GenerateShipXy(int x, int y)
    {
        var ship = new Ship(7, 3);
        ship.TryGetStackAt(x, y, out var stack);

        stack!.Containers.Add(new Container());
        stack!.Containers.Add(new Container());

        return ship.ToUrl();
    }
    
    public static async Task Main()
    {
        var ws = new ContainerWebSocket("127.0.0.1", "8181");
        
        var x = 0;
        var y = 0;

        while (true)
        {
            ConsoleKeyInfo cki = Console.ReadKey(true);
            if (cki.Key != ConsoleKey.Enter) continue;
            
            Console.WriteLine($"containers at: {x} {y}");
            
            string url = GenerateShipXy(x, y);
            Console.WriteLine($"\n{url}");
            foreach (var socket in ws.Sockets)
            {
                socket.Send(url);
            }

            if (x + 1 > 2)
            {
                if (y + 1 > 6)
                {
                    y = 0;
                }
                else
                {
                    y++;
                }
                x = 0;
            }
            else
            {
                x++;
            }
            
            

        }
    }
}