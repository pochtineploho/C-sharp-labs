using System.Collections;
using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class Lab4TestDataGenerator : IEnumerable<object[]>
{
    public static IEnumerable<object[]> ConnectPath => new List<object[]>
    {
        new object[]
        {
            @"D:\TheoreticalPath",
        },
        new object[]
        {
            @"C:\Homework\Maths",
        },
        new object[]
        {
            @"X:\SecretInformation\PentagonHacking\Area51",
        },
    };

    public static IEnumerable<object[]> TreeGotoData => new List<object[]>
    {
        new object[]
        {
            @"D:\TheoreticalPath1",
            @"D:\TheoreticalPath2",
        },
        new object[]
        {
            @"C:\Homework\Maths",
            @"C:\Homework\Maths\Geometry",
        },
        new object[]
        {
            @"X:\SecretInformation\PentagonHacking\Area51",
            @"D:\WhatIfFbiFollowsYou",
        },
    };

    public static IEnumerable<object[]> TreeListData => new List<object[]>
    {
        new object[]
        {
            @"D:\TheoreticalPath",
            3,
        },
        new object[]
        {
            @"C:\Homework\Maths",
            22,
        },
        new object[]
        {
            @"X:\SecretInformation\PentagonHacking\Area51",
            8,
        },
    };

    public static IEnumerable<object[]> FileDeleteShowData => new List<object[]>
    {
        new object[]
        {
            @"D:\TheoreticalPath1",
            @"TheoreticalFile.txt",
        },
        new object[]
        {
            @"C:\Homework\Maths",
            @"C:\Homework\Maths\Geometry\graph.py",
        },
        new object[]
        {
            @"X:\SecretInformation\PentagonHacking\Area51",
            @"calculator.h",
        },
    };

    public static IEnumerable<object[]> FileMoveCopyData => new List<object[]>
    {
        new object[]
        {
            @"D:\TheoreticalPath",
            @"TheoreticalFile.txt",
            @"D:\TheoreticalPath2",
        },
        new object[]
        {
            @"C:\Homework\Maths",
            @"C:\Homework\Maths\Geometry\graph.py",
            @"C:\Bin",
        },
        new object[]
        {
            @"X:\SecretInformation",
            @"PentagonHacking\Area51.doc",
            @"D:\DefinitelyNotSecretInformation",
        },
    };

    public static IEnumerable<object[]> FileRenameData => new List<object[]>
    {
        new object[]
        {
            @"D:\TheoreticalPath",
            @"TheoreticalFile.txt",
            @"File.txt",
        },
        new object[]
        {
            @"C:\Homework\Maths",
            @"C:\Homework\Maths\Geometry\graph.py",
            @"graphics.py",
        },
        new object[]
        {
            @"X:\SecretInformation",
            @"PentagonHacking\Area51.doc",
            @"Playground.doc",
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