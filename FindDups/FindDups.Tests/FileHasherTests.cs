using System.Text;
using Moq;

namespace FindDups.Tests;

[TestFixture]
public class FileHasherTests
{
    [Test]
    public void ComputeFileHash_ShouldReturnExpectedHash_ForGivenFile()
    {
        // Arrange
        var mockFileReader = new Mock<IFileReader>();
        
        var mockFileContent = "dummy_path"u8.ToArray();
        mockFileReader.Setup(fr => fr.ReadAllBytes(It.IsAny<string>())).Returns(mockFileContent);

        FileHasher.SetFileReader(mockFileReader.Object);

        const string expectedHash = "f9ff3effe6bd6674e293e57fba89891bb576bb23876bf0997748f5bb41b0bb25";

        // Act
        var actualHash = FileHasher.ComputeFileHash("dummy_path");

        // Assert
        actualHash.Should().Be(expectedHash);
    }
}