using System.Threading.Tasks;
using Grpc.Net.Client;
using ApexLogsExternal.Subscriber;


var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();

// The port number must match the port of the gRPC server.
using var channel = GrpcChannel.ForAddress("api.pubsub.salesforce.com:7443/event/Apex_Log_Event__e");
var client = new PubSub.PubSubClient(channel);
// TODO : figure out duplex streaming
var stream = client.Subscribe();
