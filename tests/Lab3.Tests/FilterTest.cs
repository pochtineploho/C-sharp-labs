using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Services.Builders;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class FilterTest // Test 4
{
    [Fact]
    public void TryToFilter()
    {
        var displayBuilder = new DisplayWithDriverBuilder();
        ILogger logger = Substitute.For<ILogger>();
        IDisplay display = Substitute.For<IDisplay>();
        IMessageFilter filter = new BasicFilter(10);
        Topic topic = new TopicBuilder()
            .WithName("TestTopic")
            .WithAddressee(displayBuilder
                .WithDisplay(display)
                .WithLogger(logger)
                .WithFilter(filter))
            .Build();

        var message = new Message("TestHeader", "TestBody");
        topic.ReceiveMessage(new Message(message.Header, message.Body, 5));
        topic.ReceiveMessage(new Message(message.Header, message.Body, 10));
        topic.ReceiveMessage(new Message(message.Header, message.Body, 15));

        logger.Received(2).Log(message.ToText());
    }
}