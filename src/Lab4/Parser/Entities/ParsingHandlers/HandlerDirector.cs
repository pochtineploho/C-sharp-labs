using Itmo.ObjectOrientedProgramming.Lab4.Production.Models;

#pragma warning disable CA1822
namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.Entities.ParsingHandlers;

public class HandlerDirector
{
    public BaseHandler BuildDefaultHandlerSystem(IFileSystemOutput? receiver = null)
    {
        var connect = new ConnectHandler(receiver);
        var disconnect = new DisconnectHandler(receiver);
        var fileCopy = new FileCopyHandler(receiver);
        var fileDelete = new FileDeleteHandler(receiver);
        var fileMove = new FileMoveHandler(receiver);
        var fileRename = new FileRenameHandler(receiver);
        var fileHandler = new FileHandler(receiver);
        var fileShow = new FileShowHandler(receiver);
        var treeTogo = new TreeGotoHandler(receiver);
        var treeList = new TreeListHandler(receiver);
        var treeHandler = new TreeHandler(receiver);

        connect.SetNext(fileHandler);
        fileHandler.SetNext(treeHandler);
        treeHandler.SetNext(disconnect);
        treeHandler.SetNextTreeHandler(treeList);
        treeList.SetNext(treeTogo);
        fileHandler.SetNextFileHandler(fileRename);
        fileRename.SetNext(fileCopy);
        fileCopy.SetNext(fileDelete);
        fileDelete.SetNext(fileShow);
        fileShow.SetNext(fileMove);

        return connect;
    }
}