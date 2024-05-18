using System.Collections.Concurrent;

namespace CopyCatcher;

internal class DuplicateFinder
{
	internal static async Task<List<DuplicateSet>> FindDuplicatesAsync(string directoryPath, HashType hashType, int chunkSize)
	{
		var files = DirectoryScanner.ScanDirectory(directoryPath);
		var fileGroups = files
			.GroupBy(f => f.Length)
			.Where(g => g.Count() > 1)
			.ToList();
		var potentialDuplicates = new ConcurrentDictionary<string, List<string>>();

		var tasks = fileGroups.SelectMany(group => group.Select(async file =>
		{
			var hash = await FileHasher.ComputeHashAsync(file.FullName, hashType, chunkSize);
			potentialDuplicates.AddOrUpdate(hash, [file.FullName], (_, list) =>
			{
				list.Add(file.FullName);
				return list;
			});
		})).ToArray();

		await Task.WhenAll(tasks);

		return potentialDuplicates
			.Where(kv => kv.Value.Count > 1)
			.Select(kv => new DuplicateSet
			{
				Directory = directoryPath,
				Hash = kv.Key,
				HashType = hashType,
				Files = kv.Value
			})
			.ToList();
	}
}