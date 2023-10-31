namespace CopyCatcher.Shared.Interfaces;

public interface IDirectoryScanner
{
    IEnumerable<string> GetAllFiles(string directoryPath);
}