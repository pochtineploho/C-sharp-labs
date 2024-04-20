#pragma warning disable CA1062
using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Services.Builders;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class ReadMessageTest
{
    [Theory]
    [MemberData(nameof(Lab3TestDataGenerator.MessagesExamples), MemberType = typeof(Lab3TestDataGenerator))]
    public void CheckMessageStatus(Message message)
    {
        var user = new User("Name");
        var userBuilder = new UserBuilder(user);
        Topic topic = new TopicBuilder()
            .WithName("Topic Name")
            .WithAddressee(userBuilder
                .WithLogger(new MessageLogger())
                .WithFilter(new BasicFilter()))
            .Build();

        topic.ReceiveMessage(message);

        Assert.Equal(MessageStatus.Delivered, user.GetMessageStatus(message.Header));
    }
}