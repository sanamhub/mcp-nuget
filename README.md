# MCP Weather Server

A Model Context Protocol (MCP) server to try NuGet MCP support that provides weather information tools for AI assistants. This server is built using C# and the official ModelContextProtocol SDK.

## Overview

This MCP server exposes weather-related tools that can be used by AI assistants like Claude, GitHub Copilot, and other MCP-compatible clients. The server provides random weather information for cities based on configurable weather conditions.

## Features

- **Weather Information Tool**: Get random weather descriptions for any city
- **Configurable Weather Options**: Customize available weather conditions via environment variables
- **Cross-Platform**: Built on .NET 9.0 with cross-platform support
- **Easy Integration**: Works with VS Code, Visual Studio, and other MCP-compatible environments

## Installation

### From NuGet (Recommended)

The server is available as a NuGet package at [nuget.org/packages/mcp](https://www.nuget.org/packages/mcp).

#### Global Installation

```bash
dotnet tool install --global mcp
```

#### Local Installation

```bash
dotnet new tool-manifest  # if you are setting up this repo
dotnet tool install --local mcp
```

### From Source

1. Clone the repository:

   ```bash
   git clone https://github.com/sanamhub/mcp-nuget.git
   cd mcp-nuget
   ```

2. Build and run:

   ```bash
   dotnet build
   dotnet run
   ```

## Configuration

### VS Code Setup

Create a `.vscode/mcp.json` file in your workspace:

```json
{
  "servers": {
    "mcp-weather": {
      "type": "stdio",
      "command": "dnx",
      "args": ["mcp@0.0.1", "--yes"],
      "env": {
        "WEATHER_CHOICES": "sunny,cloudy,rainy,snowy,stormy"
      }
    }
  }
}
```

### Visual Studio Setup

Create a `.mcp.json` file in your solution directory:

```json
{
  "servers": {
    "mcp-weather": {
      "type": "stdio",
      "command": "dnx",
      "args": ["mcp@0.0.1", "--yes"],
      "env": {
        "WEATHER_CHOICES": "sunny,cloudy,rainy,snowy,stormy"
      }
    }
  }
}
```

### Local Development Setup

For testing from source code:

```json
{
  "servers": {
    "mcp-weather": {
      "type": "stdio",
      "command": "dotnet",
      "args": ["run", "--project", "."],
      "env": {
        "WEATHER_CHOICES": "sunny,humid,freezing,perfect,stormy"
      }
    }
  }
}
```

## Environment Variables

| Variable          | Description                                  | Required | Default              |
| ----------------- | -------------------------------------------- | -------- | -------------------- |
| `WEATHER_CHOICES` | Comma-separated list of weather descriptions | No       | "balmy,rainy,stormy" |

## Available Tools

### `get_city_weather`

Returns random weather information for a specified city.

**Parameters:**

- `city` (string): Name of the city to get weather for

**Example:**

```text
User: What's the weather like in New York?
Assistant: The weather in New York is sunny.
```

## Development

### Prerequisites

- .NET 9.0 SDK or later
- Visual Studio 2022 or VS Code

### Building

```bash
dotnet build
```

### Testing

```bash
dotnet test
```

### Packaging

```bash
dotnet pack -c Release
```

The package will be created in `bin/Release/mcp.{version}.nupkg`.

## Publishing

To publish a new version to NuGet:

1. Update the version in `mcp.csproj`
2. Update the version in `.mcp/server.json`
3. Build and pack:

   ```bash
   dotnet pack -c Release
   ```

4. Publish:

   ```bash
   dotnet nuget push bin/Release/*.nupkg --api-key <your-api-key> --source https://api.nuget.org/v3/index.json
   ```

## Dependencies

- [ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol) - Official MCP C# SDK
- [Microsoft.Extensions.Hosting](https://www.nuget.org/packages/Microsoft.Extensions.Hosting) - .NET hosting infrastructure

## Resources

- [Model Context Protocol Documentation](https://modelcontextprotocol.io/)
- [MCP Protocol Specification](https://spec.modelcontextprotocol.io/)
- [VS Code MCP Integration](https://code.visualstudio.com/docs/copilot/chat/mcp-servers)
- [Visual Studio MCP Integration](https://learn.microsoft.com/visualstudio/ide/mcp-servers)

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.
