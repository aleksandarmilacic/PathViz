# PathViz

## Overview

PathViz is a pathfinding visualization tool designed to assist in understanding and debugging pathfinding algorithms. Developed using C# and .NET, the project allows users to interactively set start and end points, insert obstacles, and run pathfinding algorithms like Dijkstra's algorithm.

## Prerequisites

- .NET SDK (7.0 or higher)
- Visual Studio 2019 or 2022 (or any compatible IDE)

## Installation

### Clone the Repository

To get started, clone the repository to your local machine.

```bash
git clone https://github.com/yourusername/PathViz.git
```

### Install NuGet Packages

Navigate to the project folder and install the necessary NuGet packages. This can also be done within Visual Studio through the NuGet Package Manager.

```bash
cd PathViz
dotnet restore
```

## Running Tests

The project uses xUnit for unit testing. To run the tests, you can use the following command:

```bash
dotnet test
```

Alternatively, you can run the tests using the Test Explorer in Visual Studio.

## Usage

Open the solution in Visual Studio and set `PathViz` as the startup project. Hit `F5` to run the application. Use the UI to set start and end points, add obstacles, and run the pathfinding algorithm.

## Contributing

Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

## License

[MIT](https://choosealicense.com/licenses/mit/)

