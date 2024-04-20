using System;
using System.Text;
using Itmo.ObjectOrientedProgramming.Lab4.Production.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Production.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Production.Services;

public class DefaultTreeVisitor : IDirectoryTreeVisitor
{
    private const string DefaultTabulation = "   ";
    private const string DefaultFileMark = "+ ";
    private const string DefaultDirectoryMark = "> ";
    private const string DefaultLineSeparator = "\n";

    private readonly string _tabulation;
    private readonly string _fileMark;
    private readonly string _directoryMark;
    private readonly string _lineSeparator;

    private StringBuilder _output;

    public DefaultTreeVisitor(string? tabulation = null, string? fileMark = null, string? directoryMark = null, string? lineSeparator = null)
    {
        _tabulation = tabulation ?? DefaultTabulation;
        _fileMark = fileMark ?? DefaultFileMark;
        _directoryMark = directoryMark ?? DefaultDirectoryMark;
        _lineSeparator = lineSeparator ?? DefaultLineSeparator;
        _output = new StringBuilder();
    }

    private string Result => _output.ToString();

    public string TreeToText(MyDirectory directory)
    {
        if (directory == null) throw new ArgumentNullException(nameof(directory));
        AddDirectory(directory);
        return Result;
    }

    public void AddFile(MyFile file, string tabulation)
    {
        if (file == null) throw new ArgumentNullException(nameof(file));
        _output.Append(tabulation)
            .Append(_fileMark)
            .Append(file.Name)
            .Append(_lineSeparator);
    }

    public void AddDirectory(MyDirectory directory, string tabulation = "")
    {
        if (directory == null) throw new ArgumentNullException(nameof(directory));
        _output.Append(tabulation)
            .Append(_directoryMark)
            .Append(directory.Name)
            .Append(_lineSeparator);
        foreach (FileSystemObject systemObject in directory.Content)
        {
            systemObject.AcceptTreeVisitor(this, tabulation + _tabulation);
        }
    }
}