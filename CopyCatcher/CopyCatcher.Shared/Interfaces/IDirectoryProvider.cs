namespace CopyCatcher.Shared.Interfaces;

public interface IDirectoryProvider
{
    IEnumerable<string> EnumerateFiles(string path, string searchPattern, SearchOption searchOption);
}