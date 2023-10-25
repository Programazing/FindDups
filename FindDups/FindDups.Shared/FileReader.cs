using FindDups.Shared.Interfaces;

namespace FindDups.Shared;

public class FileReader : IFileReader
{
	public byte[] ReadAllBytes(string filePath)
	{
		return File.ReadAllBytes(filePath);
	}
}