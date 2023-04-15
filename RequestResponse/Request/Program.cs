using NetMQ.Sockets;
using NetMQ;

Console.WriteLine("REQUESTER iniciado. Pressione Enter para enviar uma mensagem.");
Console.ReadLine();

using (var requester = new RequestSocket())
{
    requester.Connect("tcp://localhost:5555");

    Console.WriteLine("Escreva uma mensagem a ser enviada...");
    var console = Console.ReadLine();
    requester.SendFrame(console ?? string.Empty);

    string message = requester.ReceiveFrameString();
    Console.WriteLine($"REQUESTER -> Resposta recebida: {message}");
}

Console.ReadLine();