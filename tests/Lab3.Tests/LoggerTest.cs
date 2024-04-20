using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Services.Builders;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class LoggerTest // Test 5
{
    [Fact]
    public void TryToLog()
    {
        IMessageFilter filter = new BasicFilter();
        ILogger logger = Substitute.For<ILogger>();
        IMessenger messenger = Substitute.For<IMessenger>();
        var addresseeBuilder = new MessengerBuilder();
        Topic topic = new TopicBuilder()
            .WithName("TestTopic")
            .WithAddressee(addresseeBuilder
                .WithMessenger(messenger)
                .WithLogger(logger)
                .WithFilter(filter))
            .Build();

        var message = new Message("TestHeader", "TestBody");
        for (int i = 0; i < 3; i++)
        {
            topic.ReceiveMessage(message);
        }

        logger.Received(3).Log(message.ToText());
    }
}