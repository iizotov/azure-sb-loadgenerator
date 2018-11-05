# Multi-threaded load Generator for Azure Service Bus and Event Hubs 
This console app generates random payload and inserts it into an Azure Service Bus Queue or a Topic or an Azure Event Hub. Every payload message is a JSON consistsing of a UTC timestamp and a random string payload:
```json
{"dt":1513815044440,"payload":"<random string as per message size>"}
```
> Note: do not forget to add `;TransportType=Amqp` to your connection string to enforce [AMQP 1.0](https://docs.microsoft.com/en-us/azure/service-bus-messaging/service-bus-amqp-dotnet) 

**Software prerequisites:**
1. Visual Studio 2015 (or higher)

## Running this sample
1. Clone this repository or download the zip file.
2. Open the solution, perform nuget restore and build
3. Usage:
```
.\LoadGenerator.exe

  -t, --threads             Required. (Default: 5) Threads to spawn.
  -s, --size                Required. (Default: 1024) JSON Payload size, real
                            size in bytes = 35 + size
  -m, --messagestosend      Required. (Default: 100) Messages to send in each
                            thread before termination, 0 for infinity
  -c, --connectionstring    Required. Event Hub or Service Bus Namespace
                            connection String. If Event Hub, make sure it is the
                            Namespace's connection string, not the Event Hub's
  --name                    Event Hub or Queue or Topic Name
  --checkpoint              (Default: 100) Checkpoint - log to console every N
                            messages
  -b, --batchmode           (Default: True) Send messages in batches of 
                            --batchsize size
  --batchsize               (Default: 100) Determines the size of the batch if 
                            using batch mode

```

## Example
The following command line generates load in batches of 200 messages using 10 parallel threads, each message size is 150+35 bytes. The code will run infitinely until SIGTERM or Ctrl+C is received

```
.\LoadGenerator.exe --threads 10 --size 150 --messagestosend 0 --connectionstring "Endpoint=sb://latencytest.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=*****;TransportType=Amqp" --name eh1 --checkpoint 100 --batchmode True --batchsize 200
Thread: 5, started and connected
Thread: 3, started and connected
Thread: 6, started and connected
Thread: 9, started and connected
Thread: 7, started and connected
Thread: 8, started and connected
Thread: 4, started and connected
Thread: 10, started and connected
Thread: 7, started and connected
Thread: 9, started and connected
Thread: 19, sent: 200 / 0 messages total, in batches of 200, message size: 185 bytes, speed: 121.520333602481 msg/sec
Thread: 17, sent: 200 / 0 messages total, in batches of 200, message size: 185 bytes, speed: 120.234288534639 msg/sec
```

## Disclaimers
The code included in this sample is not intended to be a set of best practices on how to build scalable enterprise grade applications. This is beyond the scope of this quick start sample.

## Related Links
For more information, see these articles:
- [Microsoft Service Bus Samples](https://github.com/Azure/azure-service-bus/tree/master/samples)
- [Best Practices for performance improvements using Service Bus Messaging](https://docs.microsoft.com/en-us/azure/service-bus-messaging/service-bus-performance-improvements)
