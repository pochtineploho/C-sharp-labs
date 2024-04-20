using Itmo.ObjectOrientedProgramming.Lab4.Production.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Production.Services;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.Entities.Fabrics;

public class FileSystemFabric : FabricBase<IFileSystemOutput>
{
    public FileSystemFabric()
        : base(new[]
        {
            new FabricType<IFileSystemOutput>(
                "local",
                new FileSystemBuilder()
                .WithFileHandler(new DefaultFileTexifyer())
                .WithFileReader(new DefaultFileReader())
                .WithDirectoryTraversal(new DefaultTraversal())
                .WithDirectoryTreeHandler(new DefaultTreeVisitor())
                .BuildLocalFileSystem()),

            new FabricType<IFileSystemOutput>(
                "test",
                new FileSystemBuilder()
                    .WithFileHandler(new DefaultFileTexifyer())
                    .WithDirectoryTreeHandler(new DefaultTreeVisitor())
                    .BuildTestFileSystem()),
        })
    { }
}