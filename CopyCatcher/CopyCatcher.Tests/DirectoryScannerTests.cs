using Moq;
using System.IO.Abstractions;

namespace CopyCatcher.Tests;

[TestFixture]
    public class DirectoryScannerTests
    {
        //private Mock<IDirectoryProvider> _mockDirectoryProvider;
        //private DirectoryScanner _directoryScanner;

        //[SetUp]
        // public void SetUp()
        // {
        //     _mockDirectoryProvider = new Mock<IDirectoryProvider>();
        //     _directoryScanner = new DirectoryScanner(_mockDirectoryProvider.Object);
        // }

        // [Test]
        // public void GetAllFiles_WhenUnauthorizedAccessException_ShouldReturnEmptyList()
        // {
        //     _mockDirectoryProvider.Setup(d => d.EnumerateFiles(It.IsAny<string>(), "*.*", SearchOption.AllDirectories))
        //                   .Throws<UnauthorizedAccessException>();
        //
        //     var result = _directoryScanner.GetAllFiles("dummy_path");
        //
        //     Assert.IsEmpty(result);
        // }

        // [Test]
        // public void GetAllFiles_WhenArgumentException_ShouldReturnEmptyList()
        // {
        //     _mockDirectoryProvider.Setup(d => d.EnumerateFiles(It.IsAny<string>(), "*.*", SearchOption.AllDirectories))
        //                   .Throws<ArgumentException>();
        //
        //     var result = _directoryScanner.GetAllFiles("dummy_path");
        //
        //     Assert.IsEmpty(result);
        // }
        //
        // [Test]
        // public void GetAllFiles_WhenPathTooLongException_ShouldReturnEmptyList()
        // {
        //     _mockDirectoryProvider.Setup(d => d.EnumerateFiles(It.IsAny<string>(), "*.*", SearchOption.AllDirectories))
        //                   .Throws<PathTooLongException>();
        //
        //     var result = _directoryScanner.GetAllFiles("dummy_path");
        //
        //     Assert.IsEmpty(result);
        // }
        //
        // [Test]
        // public void GetAllFiles_WhenDirectoryNotFoundException_ShouldReturnEmptyList()
        // {
        //     _mockDirectoryProvider.Setup(d => d.EnumerateFiles(It.IsAny<string>(), "*.*", SearchOption.AllDirectories))
        //                   .Throws<DirectoryNotFoundException>();
        //
        //     var result = _directoryScanner.GetAllFiles("dummy_path");
        //
        //     Assert.IsEmpty(result);
        // }
        //
        // [Test]
        // public void GetAllFiles_WhenIOException_ShouldReturnEmptyList()
        // {
        //     _mockDirectoryProvider.Setup(d => d.EnumerateFiles(It.IsAny<string>(), "*.*", SearchOption.AllDirectories))
        //                   .Throws<IOException>();
        //
        //     var result = _directoryScanner.GetAllFiles("dummy_path");
        //
        //     Assert.IsEmpty(result);
        // }
    }