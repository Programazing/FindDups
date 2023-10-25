namespace FindDups.Shared;

using System;
using System.Security.Cryptography;
using Interfaces;

public static class FileHasher
{
	private static IFileReader _fileReader = new FileReader();

	public static void SetFileReader(IFileReader fileReader)
	{
		_fileReader = fileReader;
	}

	public static string ComputeFileHash(string filePath)
    {

        var buffer = _fileReader.ReadAllBytes(filePath);
        var hashBytes = SHA256.HashData(buffer);

        return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
    }
}

