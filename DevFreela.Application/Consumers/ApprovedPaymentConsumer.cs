using DevFreela.Core.IntegrationEvents;
using DevFreela.Core.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace DevFreela.Application.Consumers
{
    public class ApprovedPaymentConsumer : BackgroundService
    {
        private const string APPROVED_PAYMENT_QUEUE = "ApprovedPayments";

        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly IServiceProvider _serviceProvider;

        public ApprovedPaymentConsumer(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;

            var factory = new ConnectionFactory
            {
                HostName = "localhost"
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            
            _channel.QueueDeclare(APPROVED_PAYMENT_QUEUE, false, false, false, null);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += async (sender, eventArgs) =>
            {
                var approvedPaymentBytes = eventArgs.Body.ToArray();

                var approvedPaymentJson = Encoding.UTF8.GetString(approvedPaymentBytes);

                var approvedPaymentIntegrationEvent = JsonSerializer.Deserialize<ApprovedPaymentIntegrationEvent>(approvedPaymentJson);

                await FinishProject(approvedPaymentIntegrationEvent.IdProject);

                _channel.BasicAck(eventArgs.DeliveryTag, false);
            };

            _channel.BasicConsume(APPROVED_PAYMENT_QUEUE, false, consumer);

            return Task.CompletedTask;
        }

        public async Task FinishProject(Guid id)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var projectRepository = scope.ServiceProvider.GetRequiredService<IProjectRepository>();
                var project = await projectRepository.GetByIdAsync(id);

                project.Finish();

                await projectRepository.SaveChangesAsync();            
            }
        }
    }
}
