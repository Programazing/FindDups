namespace FindDups.Shared;

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
        _directoryScanner = new DirectoryScanner();
    }
    
    public Dictionary<string, List<string>> FindDuplicates()
    {
        var duplicateFinder = new DuplicateFinder(_fileHasher, _directoryScanner, _fileReader);
        return duplicateFinder.FindDuplicates(_directoryPath);
    }
}