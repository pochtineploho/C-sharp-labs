using System.Collections;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class Lab3TestDataGenerator : IEnumerable<object[]>
{
    public static IEnumerable<object[]> MessagesExamples => new List<object[]>
    {
        new object[]
        {
            new Message("TestHeader1", "TestBody1"),
        },
        new object[]
        {
            new Message("TestHeader2", "TestBody3"),
        },
        new object[]
        {
            new Message("TestHeader3", "TestBody3"),
        },
    };

    public IEnumerator<object[]> GetEnumerator()
    {
        throw new System.NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}