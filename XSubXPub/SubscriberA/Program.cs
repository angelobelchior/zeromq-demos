using NetMQ;
using NetMQ.Sockets;

string topic = "TopicA";
using (var subSocket = new SubscriberSocket(">tcp://127.0.0.1:1234"))
{
    subSocket.Options.ReceiveHighWatermark = 1000;
    subSocket.Subscribe(topic);
    Console.WriteLine("Subscriber socket connecting...");
    while (true)
    {
        string messageTopicReceived = subSocket.ReceiveFrameString();
        string messageReceived = subSocket.ReceiveFrameString();
        Console.WriteLine(messageReceived);
    }
}