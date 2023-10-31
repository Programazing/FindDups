namespace CopyCatcher.Shared.Interfaces;

public interface IFileReader
{
	FileStream OpenFileForRead(string path);
	byte[] ReadFirstBytes(string filePath, int byteCount);
}