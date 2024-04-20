using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class Message
{
    public Message(string header, string body, int importanceLevel = 0)
    {
        Header = header ?? throw new ArgumentNullException(nameof(header));
        Body = body ?? throw new ArgumentNullException(nameof(body));
        ImportanceLevel = importanceLevel;
    }

    public string Header { get; }
    public string Body { get; }
    public int ImportanceLevel { get; }

    public string ToText()
    {
        return $"{Header} \n {Body}";
    }
}