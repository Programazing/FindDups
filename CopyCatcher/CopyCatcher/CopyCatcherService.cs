namespace CopyCatcher;

public class CopyCatcherService
{
	private readonly DuplicateFinder _duplicateFinder = new();

	public async Task<List<DuplicateSet>> FindDuplicatesAsync(IEnumerable<string> directoryPaths, HashType hash = HashType.Md5, int chunkSize = 4096)
	{
		var tasks = directoryPaths.Select(path => DuplicateFinder.FindDuplicatesAsync(path, hash, chunkSize));
		var results = await Task.WhenAll(tasks);
		return results.SelectMany(result => result).ToList();
	}
}