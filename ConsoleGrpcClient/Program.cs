using Grpc.Net.Client;
using GrpcGreeterClient;
using System.Net;
using System.Net.Http;

// The port number must match the port of the gRPC server.
using var channel = GrpcChannel.ForAddress("https://localhost:7032");
var client = new Greeter.GreeterClient(channel);
var reply = await client.SayHelloAsync(
    new HelloRequest { Name = "GreeterClient" });
Console.WriteLine("Greeting: " + reply.Message);


string url = "https://localhost:7212/weatherforecast/";
HttpClient http = new HttpClient();

HttpResponseMessage resp = await http.GetAsync(url);
if (resp.IsSuccessStatusCode)
{
    string text = await resp.Content.ReadAsStringAsync();
    Console.Write(text);
    Console.Write("\n");
}

Console.WriteLine("Press any key to exit...");
Console.ReadKey();