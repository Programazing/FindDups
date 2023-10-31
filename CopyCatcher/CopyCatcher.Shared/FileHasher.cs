namespace CopyCatcher.Shared;

using System;
using System.Security.Cryptography;

public class FileHasher : IFileHasher
{
    private readonly IFileReader _fileReader;
    private const int BufferSize = 4096;

    public FileHasher(IFileReader fileReader)
    {
        _fileReader = fileReader ?? throw new ArgumentNullException(nameof(fileReader));
    }

    public string ComputeFileHash(string filePath)
    {
        using var md5 = MD5.Create();
        using var fileStream = _fileReader.OpenFileForRead(filePath);

        var buffer = new byte[BufferSize];
        int bytesRead;
        while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) > 0)
        {
            md5.TransformBlock(buffer, 0, bytesRead, null, 0);
        }
        md5.TransformFinalBlock(buffer, 0, 0);

        return BitConverter.ToString(md5.Hash!).Replace("-", "").ToLower();
    }
}