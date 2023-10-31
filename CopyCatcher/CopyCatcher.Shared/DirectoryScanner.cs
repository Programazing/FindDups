namespace CopyCatcher.Shared;

public class DirectoryScanner : IDirectoryScanner
{
    private readonly IDirectoryProvider _directoryProvider;

    public DirectoryScanner(IDirectoryProvider directoryProvider)
    {
        _directoryProvider = directoryProvider;
    }
    
    public IEnumerable<string> GetAllFiles(string directoryPath)
    {
        try
        {
            return Directory.EnumerateFiles(directoryPath, "*.*", SearchOption.AllDirectories);
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine($"Permission denied to access directory: {directoryPath}. Skipping...");
            return Enumerable.Empty<string>();
        }
        catch (ArgumentException)
        {
            Console.WriteLine($"Invalid argument provided for directory path: {directoryPath}. Skipping...");
            return Enumerable.Empty<string>();
        }
        catch (PathTooLongException)
        {
            Console.WriteLine($"The directory path is too long: {directoryPath}. Skipping...");
            return Enumerable.Empty<string>();
        }
        catch (DirectoryNotFoundException)
        {
            Console.WriteLine($"Directory not found: {directoryPath}. Skipping...");
            return Enumerable.Empty<string>();
        }
        catch (IOException ex)
        {
            Console.WriteLine($"An I/O error occurred while accessing directory: {directoryPath}. Error: {ex.Message}. Skipping...");
            return Enumerable.Empty<string>();
        }
    }
}