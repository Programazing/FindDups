using System.Security.Cryptography;

namespace CopyCatcher;

internal static class FileHasher
{
	internal static async Task<string> ComputeHashAsync(string filePath, HashType hashType, int chunkSize)
	{
		using HashAlgorithm hashAlgorithm = hashType switch
		{
			HashType.Sha1 => SHA1.Create(),
			HashType.Sha256 => SHA256.Create(),
			HashType.Sha384 => SHA384.Create(),
			HashType.Sha512 => SHA512.Create(),
			_ => MD5.Create(),
		};

		await using var fileStream = 
			new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, chunkSize, true);
		var buffer = new byte[chunkSize];
		int bytesRead;

		while ((bytesRead = await fileStream.ReadAsync(buffer.AsMemory(0, chunkSize))) > 0)
		{
			hashAlgorithm
				.TransformBlock(buffer, 0, bytesRead, buffer, 0);
		}

		hashAlgorithm.TransformFinalBlock([], 0, 0);
		return BitConverter
			.ToString(hashAlgorithm.Hash ?? throw new InvalidOperationException())
			.Replace("-", "")
			.ToLowerInvariant();
	}
}