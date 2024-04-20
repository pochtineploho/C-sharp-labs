using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Production.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Production.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Production.Services;

public class DefaultTraversal : IDirectoryTraversal
{
    public MyDirectory GetTree(string path, int depth)
    {
        var thisDirectory = new MyDirectory(Path.GetFileName(path));
        if (depth <= 0) return thisDirectory;
        string[] files = Directory.GetFiles(path);
        string[] directories = Directory.GetDirectories(path);

        foreach (string file in files)
        {
            thisDirectory.AddObject(new MyFile(Path.GetFileName(file), File.ReadAllText(file)));
        }

        foreach (string directory in directories)
        {
            thisDirectory.AddObject(GetTree(directory, depth - 1));
        }

        return thisDirectory;
    }
}