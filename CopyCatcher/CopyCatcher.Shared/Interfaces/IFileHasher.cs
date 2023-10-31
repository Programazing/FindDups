namespace CopyCatcher.Shared.Interfaces;

public interface IFileHasher
{
    string ComputeFileHash(string filePath);
}