namespace CopyCatcher;

internal static class DirectoryScanner
{
	internal static List<FileInfo> ScanDirectory(string directoryPath)
	{
		var directoryInfo = new DirectoryInfo(directoryPath);
		return directoryInfo.GetFiles("*", SearchOption.AllDirectories).ToList();
	}
}