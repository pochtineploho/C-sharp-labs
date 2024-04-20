using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Services.Adapters;
using Itmo.ObjectOrientedProgramming.Lab3.Services.Builders;
using Itmo.ObjectOrientedProgramming.Lab3.Services.Proxies;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class MessengerTest // Test 6
{
    [Fact]
    public void TryToLog()
    {
        IMessageFilter filter = new BasicFilter();
        ILogger logger = new MessageLogger();
        MessengerAddressee messengerAddressee = Substitute.For<MessengerAddressee>(Substitute.For<IMessenger>());
        IAddressee addressee =
            Substitute.For<FilterProxy>(
                Substitute.For<LoggerProxy>(messengerAddressee, logger),
                filter);
        Topic topic = new TopicBuilder()
            .WithName("TestTopic")
            .WithAddressee(addressee)
            .Build();
        var message = new Message("TestHeader", "TestBody", 10);

        for (int i = 0; i < 3; i++)
        {
            topic.ReceiveMessage(message);
        }

        messengerAddressee.Received(3).ReceiveMessage(message);
    }
}