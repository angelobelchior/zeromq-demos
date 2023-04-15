using NetMQ.Sockets;
using NetMQ;

Console.WriteLine("RESPONDER iniciado.");

using (var responder = new ResponseSocket())
{
    responder.Bind("tcp://localhost:5555");

    while (true)
    {
        string message = responder.ReceiveFrameString();
        Console.WriteLine($"Mensagem recebida: {message}");

        Console.WriteLine($"RESPONDER -> Escreva uma mensagem a ser enviada...");
        var console = Console.ReadLine();
        responder.SendFrame(console ?? string.Empty);
    }
}