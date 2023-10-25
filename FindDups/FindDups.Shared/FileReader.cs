namespace FindDups.Shared;

using System.IO;

public class FileReader : IFileReader
{
    public FileStream OpenFileForRead(string path)
    {
        return new FileStream(path, FileMode.Open, FileAccess.Read);
    }

    public byte[] ReadFirstBytes(string filePath, int byteCount)
    {
        using var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
        var buffer = new byte[byteCount];
        _ = fileStream.Read(buffer, 0, byteCount);
        return buffer;
    }
}