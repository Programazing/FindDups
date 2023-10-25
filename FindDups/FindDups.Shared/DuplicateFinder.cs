namespace FindDups.Shared;

using System.Collections.Concurrent;

public class DuplicateFinder
{
    private readonly IFileHasher _fileHasher;
    private readonly IDirectoryScanner _directoryScanner;
    private readonly IFileReader _fileReader;

    public DuplicateFinder(IFileHasher fileHasher, IDirectoryScanner directoryScanner, IFileReader fileReader)
    {
        _fileHasher = fileHasher ?? throw new ArgumentNullException(nameof(fileHasher));
        _directoryScanner = directoryScanner ?? throw new ArgumentNullException(nameof(directoryScanner));
        _fileReader = fileReader ?? throw new ArgumentNullException(nameof(fileReader));
    }

    public Dictionary<string, List<string>> FindDuplicates(string directoryPath)
    {
        var files = _directoryScanner.GetAllFiles(directoryPath);
        var fileHashes = new ConcurrentDictionary<string, List<string>>();
        var hashSet = new ConcurrentDictionary<string, byte>();
        var firstBytesDictionary = new ConcurrentDictionary<string, string>();

        Parallel.ForEach(files, file =>
        {
            var firstBytes = _fileReader.ReadFirstBytes(file, 16);
            var firstBytesString = BitConverter.ToString(firstBytes);

            if (firstBytesDictionary.TryAdd(firstBytesString, file))
            {
                var hash = _fileHasher.ComputeFileHash(file);
                fileHashes.AddOrUpdate(hash, new List<string> { file }, (_, existingList) =>
                {
                    existingList.Add(file);
                    return existingList;
                });
            }
            else
            {
                if (!firstBytesDictionary.TryGetValue(firstBytesString, out var otherFile) ||
                    !CompareFilesByteByByte(file, otherFile)) return;
                
                var hash = _fileHasher.ComputeFileHash(file);
                fileHashes.AddOrUpdate(hash, new List<string> { file }, (_, existingList) =>
                {
                    existingList.Add(file);
                    return existingList;
                });

                hashSet.TryAdd(hash, 0);
            }
        });
        
        foreach (var kvp in fileHashes)
        {
            if (kvp.Value.Count > 1)
            {
                hashSet.TryAdd(kvp.Key, 0);
            }
        }

        return fileHashes
            .Where(kvp => hashSet.ContainsKey(kvp.Key))
            .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
    }

    private bool CompareFilesByteByByte(string filePath1, string filePath2)
    {
        using var stream1 = _fileReader.OpenFileForRead(filePath1);
        using var stream2 = _fileReader.OpenFileForRead(filePath2);

        const int bufferSize = 4096;
        var buffer1 = new byte[bufferSize];
        var buffer2 = new byte[bufferSize];

        while (true)
        {
            var bytesRead1 = stream1.Read(buffer1, 0, buffer1.Length);
            var bytesRead2 = stream2.Read(buffer2, 0, buffer2.Length);

            if (bytesRead1 != bytesRead2)
                return false;

            if (bytesRead1 == 0)
                return true;

            for (var i = 0; i < bytesRead1; i++)
            {
                if (buffer1[i] != buffer2[i])
                    return false;
            }
        }
    }
}