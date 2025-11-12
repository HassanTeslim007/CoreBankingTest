using Azure.Messaging.ServiceBus;

namespace CoreBankingTest.DAL.ServiceBus
{
    public interface IServiceBusClientFactory
    {
        ServiceBusClient CreateClient();
        ServiceBusSender CreateSender(string queueOrTopicName);
        ServiceBusReceiver CreateReceiver(string queueName, ServiceBusReceiverOptions options = null);
        ServiceBusProcessor CreateProcessor(string queueName, ServiceBusProcessorOptions options = null);
        ServiceBusProcessor CreateProcessor(string topicName, string subscriptionName, ServiceBusProcessorOptions options = null);
    }
}