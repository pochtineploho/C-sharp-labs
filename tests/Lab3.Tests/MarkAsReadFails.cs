#pragma warning disable IDE0005
using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab3.Services.Builders;
using Xunit;

#pragma warning disable CA1062
namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class MarkAsReadFails
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
        user.SetMessageRead(message.Header);

        Assert.Throws<AlreadyReadException>(() => user.SetMessageRead(message.Header));
    }
}