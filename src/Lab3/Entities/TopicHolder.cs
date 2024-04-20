using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class TopicHolder
{
    private readonly List<Topic> _topics;

    public TopicHolder(IReadOnlyCollection<Topic>? topics = null)
    {
        _topics = new List<Topic>(topics ?? new List<Topic>());
    }

    public void AddTopic(Topic topic)
    {
        if (topic is null) throw new ArgumentNullException(nameof(topic));
        if (_topics.Any(checkTopic => checkTopic.Name == topic.Name)) throw new AlreadyExistsException();

        _topics.Add(topic);
    }

    public void SendMessage(string topicName, Message message)
    {
        if (topicName is null) throw new ArgumentNullException(nameof(topicName));
        if (message is null) throw new ArgumentNullException(nameof(message));

        _topics.Find(topic => topic.Name == topicName)?.ReceiveMessage(message);
    }
}