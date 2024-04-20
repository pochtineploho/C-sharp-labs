using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models;

public interface IDisplay
{
    public void Write(string text, Color color = default);
    public void Clear();
}