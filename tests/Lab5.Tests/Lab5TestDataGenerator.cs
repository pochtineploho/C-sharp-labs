using System.Collections;
using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

public class Lab5TestDataGenerator : IEnumerable<object[]>
{
    public static IEnumerable<object[]> CashOutFailTestData => new List<object[]>
    {
        new object[]
        {
            100,
            101,
        },
        new object[]
        {
            780123,
            888888,
        },
        new object[]
        {
            69,
            420,
        },
    };

    public static IEnumerable<object[]> CashOutSuccessTestData => new List<object[]>
    {
        new object[]
        {
            100,
            99,
        },
        new object[]
        {
            780123,
            780123,
        },
        new object[]
        {
            96,
            69,
        },
    };

    public static IEnumerable<object[]> DepositTestData => new List<object[]>
    {
        new object[]
        {
            100,
            9960,
        },
        new object[]
        {
            0,
            780123,
        },
        new object[]
        {
            4,
            1,
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