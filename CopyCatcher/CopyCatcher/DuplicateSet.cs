namespace CopyCatcher;

public class DuplicateSet
{
	public string? Directory { get; init; }
	public string? Hash { get; init; }
	public HashType HashType { get; init; }
	public List<string>? Files { get; init; }
}