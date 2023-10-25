namespace FindDups.Shared;

public class DirectoryScanner : IDirectoryScanner
{
    public IEnumerable<string> GetAllFiles(string directoryPath)
    {
        try
        {
            return Directory.EnumerateFiles(directoryPath, "*.*", SearchOption.AllDirectories);
        }
        catch (UnauthorizedAccessException)
        {
            // TODO: Handle permission errors, e.g., log the error, notify the user, or skip the directory.
            return Enumerable.Empty<string>();
        }
    }
}