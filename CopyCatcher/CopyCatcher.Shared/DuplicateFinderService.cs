using CopyCatcher.Shared;

namespace CopyCatcher;

public class DuplicateFinderService
{
    private readonly IFileHasher _fileHasher;
    private readonly IDirectoryScanner _directoryScanner;
    private readonly IFileReader _fileReader;
    private readonly string _directoryPath;
    
    public DuplicateFinderService(string directoryPath)
    {
        _directoryPath = directoryPath;
        
        _fileReader = new FileReader();
        _fileHasher = new FileHasher(_fileReader);
        
        var directoryProvider = new DirectoryProvider();
        _directoryScanner = new DirectoryScanner(directoryProvider);
    }
    
    public Dictionary<string, List<string>> FindDuplicates()
    {
        var duplicateFinder = new DuplicateFinder(_fileHasher, _directoryScanner, _fileReader);
        return duplicateFinder.FindDuplicates(_directoryPath);
    }
}