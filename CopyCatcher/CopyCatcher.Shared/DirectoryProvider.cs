namespace CopyCatcher.Shared;

public class DirectoryProvider : IDirectoryProvider
{
    public IEnumerable<string> EnumerateFiles(string path, string searchPattern, SearchOption searchOption)
    {
        return Directory.EnumerateFiles(path, searchPattern, searchOption);
    }
}