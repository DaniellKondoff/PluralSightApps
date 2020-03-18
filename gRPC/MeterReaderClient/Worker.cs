using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;
using MeterReaderWeb.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MeterReaderClient
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> logger;
        private readonly IConfiguration config;
        private readonly ReadingFactory readingFactory;
        private readonly LoggerFactory loggerFactory;
        private MeterReadingService.MeterReadingServiceClient client;

        public Worker(ILogger<Worker> logger, IConfiguration config, ReadingFactory readingFactory, LoggerFactory loggerFactory)
        {
            this.logger = logger;
            this.config = config;
            this.readingFactory = readingFactory;
            this.loggerFactory = loggerFactory;
        }

        protected MeterReadingService.MeterReadingServiceClient Client
        {
            get
            {
                if(client == null)
                {
                    var opt = new GrpcChannelOptions()
                    {
                        LoggerFactory = this.loggerFactory
                    };

                    var channel = GrpcChannel.ForAddress(this.config.GetValue<string>("ServerUrl"), opt);
                    client = new MeterReadingService.MeterReadingServiceClient(channel);
                }

                return client;
            }
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var counter = 0;
            var customerId = this.config.GetValue<int>("Service:CustomerId");

            while (!stoppingToken.IsCancellationRequested)
            {
                counter++;

                if(counter % 10 == 0)
                {
                    Console.WriteLine("Sending Diagostics");
                    var stream = Client.SendDiagnostic();

                    for (int i = 0; i < 5; i++)
                    {
                        var reading = await this.readingFactory.Generate(customerId);
                        await stream.RequestStream.WriteAsync(reading);
                    }

                   await stream.RequestStream.CompleteAsync();
                }
                logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                

                var pkt = new ReadingPacket()
                {
                    Successful = ReadingStatus.Success,
                    Notes = "This is a test"
                };

                for (int i = 0; i < 5; i++)
                {
                    var reading = await this.readingFactory.Generate(customerId);
                    pkt.Readings.Add(reading);
                }

                var result = await Client.AddReadingAsync(pkt);

                if (result.Success == ReadingStatus.Success)
                {
                    logger.LogInformation("Successfully sent");
                }
                else
                {
                    logger.LogInformation("Failed to sent");
                }

                await Task.Delay(this.config.GetValue<int>("Service:DelayInterval"), stoppingToken);
            }
        }
    }
}
