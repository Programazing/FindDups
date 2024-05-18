// using Moq;
//
// namespace CopyCatcher.Tests;
//
// [TestFixture]
// public class DuplicateFinderTests
// {
//     private Mock<IFileHasher>? _mockFileHasher;
//     private Mock<IDirectoryScanner>? _mockDirectoryScanner;
//     private Mock<IFileReader>? _mockFileReader;
//     private DuplicateFinder? _duplicateFinder;
//
//     [SetUp]
//     public void SetUp()
//     {
//         _mockFileHasher = new Mock<IFileHasher>();
//         _mockDirectoryScanner = new Mock<IDirectoryScanner>();
//         _mockFileReader = new Mock<IFileReader>();
//         _duplicateFinder = new DuplicateFinder(_mockFileHasher.Object, _mockDirectoryScanner.Object, _mockFileReader.Object);
//     }
//
//     [Test]
//     public void FindDuplicates_ShouldReturnListOfDuplicateFiles()
//     {
//         // Arrange
//         var mockFiles = new List<string>
//         {
//             "path/to/file1.txt",
//             "path/to/file2.jpg",
//             "path/to/file3.png"
//         };
//
//         _mockDirectoryScanner?.Setup(ds => ds.GetAllFiles(It.IsAny<string>())).Returns(mockFiles);
//
//         _mockFileHasher?.Setup(fh => fh.ComputeFileHash("path/to/file1.txt")).Returns("hash1");
//         _mockFileHasher?.Setup(fh => fh.ComputeFileHash("path/to/file2.jpg")).Returns("hash1");
//         _mockFileHasher?.Setup(fh => fh.ComputeFileHash("path/to/file3.png")).Returns("hash2");
//
//         // Mock the ReadFirstBytes method to return distinct bytes for each file
//         _mockFileReader?.Setup(fr => fr.ReadFirstBytes("path/to/file1.txt", 16)).Returns(new byte[] { 1, 2, 3 });
//         _mockFileReader?.Setup(fr => fr.ReadFirstBytes("path/to/file2.jpg", 16)).Returns(new byte[] { 4, 5, 6 });
//         _mockFileReader?.Setup(fr => fr.ReadFirstBytes("path/to/file3.png", 16)).Returns(new byte[] { 7, 8, 9 });
//
//         // Act
//         var sut = _duplicateFinder?.FindDuplicates("dummy_directory_path");
//
//         // Assert
//         sut.Should().ContainKey("hash1").WhoseValue.Should().BeEquivalentTo(new List<string>
//         {
//             "path/to/file1.txt",
//             "path/to/file2.jpg"
//         });
//         sut.Should().NotContainKey("hash2");
//     }
// }