using System.Collections.ObjectModel;
using Fleck;
using Newtonsoft.Json;

namespace ContainerTransport;

public class ContainerWebSocket
{
    public ReadOnlyCollection<IWebSocketConnection> Sockets => sockets.AsReadOnly();

    private List<IWebSocketConnection> sockets = new List<IWebSocketConnection>();

    public ContainerWebSocket(string ip, string port)
    {

        var server = new WebSocketServer($"ws://{ip}:{port}");

        server.Start(socket =>
        {
            socket.OnOpen = () =>
            {
                sockets.Add(socket);
                Console.WriteLine("Socket connection opened!");
            };

            socket.OnClose = () =>
            {
                sockets.Remove(socket);
                Console.WriteLine("Socket connection closed!");
            };

            socket.OnMessage = message =>
            {
                //Console.WriteLine(server.EnabledSslProtocols);
                //Console.WriteLine(String.Join(",", server.SupportedSubProtocols));
                if (message.ValidateJson())
                {
                    var obj = JsonConvert.DeserializeObject(message);
                    message = JsonConvert.SerializeObject(obj, Newtonsoft.Json.Formatting.Indented);
                }
                else Console.WriteLine($"Error while validating JSON message: {message}");

                Console.WriteLine("Message received: " + message);
                //socket.Send("Response from server");
            };
        });
    }
}