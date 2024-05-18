// using Moq;
//
// namespace CopyCatcher.Tests;
//
// [TestFixture]
// public class FileHasherTests
// {
//     private Mock<IFileReader>? _mockFileReader;
//     private FileHasher? _fileHasher;
//     private string? _tempFilePath;
//
//     [SetUp]
//     public void SetUp()
//     {
//         _mockFileReader = new Mock<IFileReader>();
//         _fileHasher = new FileHasher(_mockFileReader.Object);
//     }
//
//     [Test]
//     public void ComputeFileHash_ShouldReturnExpectedMD5Hash_ForGivenFileContent()
//     {
//         // Arrange
//         var content = "dummy_content"u8.ToArray();
//         _tempFilePath = Path.GetTempFileName();
//         File.WriteAllBytes(_tempFilePath, content);
//         _mockFileReader?.Setup(fr => 
//             fr
//             .OpenFileForRead(
//         It
//             .IsAny<string>()))
//             .Returns(new 
//                 FileStream(
//                     _tempFilePath, 
//                     FileMode.Open, 
//                     FileAccess.Read, 
//                     FileShare.Read, 
//                     4096, 
//                     FileOptions.DeleteOnClose));
//
//         // Expected MD5 hash for "dummy_content"
//         const string expectedHash = "1be4338df03bd55ba2d3b951d0d13d58";
//
//         // Act
//         var sut = _fileHasher?.ComputeFileHash("dummy_path");
//
//         // Assert
//         sut.Should().Be(expectedHash);
//     }
//
//     [TearDown]
//     public void TearDown()
//     {
//         if (File.Exists(_tempFilePath))
//         {
//             File.Delete(_tempFilePath);
//         }
//     }
// }
