namespace FindDups.Shared.Interfaces;

public interface IFileReader
{
	byte[] ReadAllBytes(string filePath);
}