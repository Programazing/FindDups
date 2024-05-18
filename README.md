Copy Catcher
==========================

Table of Contents:
--------
<!-- TOC start (generated with https://github.com/derlin/bitdowntoc) -->

- [Overview](#overview)
- [Key Benefits & Features](#keybenefits)
- [Getting Started](#gettingstarted)
    - [Prerequisites](#prerequisites)
    - [Installation](#installation)
    - [Integration](#integration)
    - [Hash Algorithms](#algorithms)
    - [Output](#output)
    - [Console App Example](#console-app-example)
- [Components](#components)
- [Workflow](#workflow)

<!-- TOC end -->

<!-- TOC --><a name="overview"></a>
Overview
--------

`Copy Catcher` is a NuGet package designed to identify and list duplicate files within specified directories. It uses advanced techniques and optimizations to ensure efficient and accurate detection of files with identical content.

<!-- TOC --><a name="keybenefits"></a>
Key Benefits & Features
-----------------------

- **Buffered Reading**: Efficiently reads large files in chunks, reducing memory usage and enhancing performance.
- **Asynchronous Operations**: Leverages async operations to ensure non-blocking I/O, resulting in a smoother user experience.
- **Early Byte Exiting**: Checks initial bytes of files before hashing to quickly identify distinct files and save computational resources.
- **Chunk Hashing**: Hashes files in chunks, allowing for memory-efficient and faster identification of large duplicate files.
- **Parallelism**: Employs parallel processing to scan and hash multiple files concurrently, taking full advantage of multi-core processors.

<!-- TOC --><a name="gettingstarted"></a>
Getting Started
---------------

<!-- TOC --><a name="prerequisites"></a>
### Prerequisites

-   .NET SDK installed on your machine.
-   A .NET project where you want to use `Copy Catcher`.

<!-- TOC --><a name="installation"></a>
### Installation

Install the `Copy Catcher` NuGet package using the NuGet Package Manager:

```bash
Install-Package CopyCatcher
```

Or using the .NET CLI:

```bash
dotnet add package CopyCatcher
```

Usage
-----

<!-- TOC --><a name="integration"></a>
### Integration

In your .NET project, add the following using directive:

```csharp
using CopyCatcher;
```

Create an instance of the `CopyCatcherService` and call the `FindDuplicatesAsync` method:

```csharp
var service = new CopyCatcherService();
var duplicates = await service.FindDuplicatesAsync(new List<string> { "path/to/directory1", "path/to/directory2" }, HashAlgorithmType.SHA256, 4096);
```

`FindDuplicatesAsync` will accept a string array of directories as the bare minimum. The method also accepts two optional parameters: `HashType` and `ChunkSize` to allow the user some control over the hashing algorithm and chunk size used for hashing.

<!-- TOC --><a name="algorithms"></a>
### Hash Algorithms

At the moment the following hash algorithms are supported:
- MD5
- SHA1
- SHA256
- SHA384
- SHA512

<!-- TOC --><a name="output"></a>
### Output

The `FindDuplicatesAsync` method will return a list of `DuplicateSet` objects, where each set contains the directory, hash value, hash algorithm, and list of file paths that have the same hash:

```csharp
{
    public class DuplicateSet
    {
        public string Directory { get; set; }
        public string Hash { get; set; }
        public HashAlgorithmType HashAlgorithm { get; set; }
        public List<string> Files { get; set; }
    }
}
```

<!-- TOC --><a name="console-app-example"></a>
### Console App Example

A simple .NET Console app using Copy Catcher would look like this:

```csharp
using CopyCatcher;
using System.Diagnostics;

Console.WriteLine("Please provide directory paths separated by a comma:");
var input = Console.ReadLine();

if (string.IsNullOrWhiteSpace(input))
{
    Console.WriteLine("No directory paths provided.");
    return;
}

var directoryPaths = input.Split(',').Select(path => path.Trim()).ToList();

HashAlgorithmType hashAlgorithm = HashAlgorithmType.MD5;
int chunkSize = 4096;

var service = new CopyCatcherService();

var stopwatch = Stopwatch.StartNew();
var duplicates = await service.FindDuplicatesAsync(directoryPaths, hashAlgorithm, chunkSize);
stopwatch.Stop();

if (duplicates.Any())
{
    foreach (var duplicateSet in duplicates)
    {
        Console.WriteLine($"Directory: {duplicateSet.Directory}");
        Console.WriteLine($"Hash: {duplicateSet.HashAlgorithm}");
        Console.WriteLine($"HashKey: {duplicateSet.Hash}");
        Console.WriteLine("Files:");
        foreach (var file in duplicateSet.Files)
        {
            Console.WriteLine(file);
        }
        Console.WriteLine();
    }

    Console.WriteLine($"Found {duplicates.Count} sets of duplicates in {stopwatch.Elapsed.TotalSeconds:0.##} seconds.\n");
}
else
{
    Console.WriteLine($"No duplicates found in {stopwatch.Elapsed.TotalSeconds:0.##} seconds.");
}
```

How It Works
------------

<!-- TOC --><a name="components"></a>
### Components

-   **CopyCatcherService**: The main service that ties all components together and provides an easy-to-use interface for finding duplicates.**
-   **DirectoryScanner**: Scans the specified directory and retrieves a list of all files.
-   **DuplicateFinder**: Finds duplicate files using the above components.
-   **DuplicateSet**: Represents a set of duplicate files with the same hash value.
-   **FileHasher**:  Computes a hash value for each file using chunk-based hashing.

<!-- TOC --><a name="workflow"></a>
### Workflow

1.  The user specifies the directories to be scanned.
2.  `DirectoryScanner` retrieves a list of all files in the directories.
3.  `FileHasher` computes a hash for each file using the specified hash algorithm.
4.  Duplicate files are identified based on their hash values and returned in a list of `DuplicateSet` objects.