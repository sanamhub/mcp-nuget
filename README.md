# MCP Server

This README was created using the C# MCP server project template. It demonstrates how you can easily create an MCP server using C# and publish it as a NuGet package.

See [aka.ms/nuget/mcp/guide](https://aka.ms/nuget/mcp/guide) for the full guide.

Please note that this template is currently in an early preview stage. If you have feedback, please take a [brief survey](http://aka.ms/dotnet-mcp-template-survey).

## Checklist before publishing to NuGet.org

- Test the MCP server locally using the steps below.
- Update the package metadata in the .csproj file, in particular the `<PackageId>`.
- Update `.mcp/server.json` to declare your MCP server's inputs.
  - See [configuring inputs](https://aka.ms/nuget/mcp/guide/configuring-inputs) for more details.

```json
{
  "description": "A sample MCP server with weather",
  "name": "io.github.sanamhub/mcp-nuget",
  "packages": [
    {
      "registry_name": "nuget",
      "name": "sanam.mcp",
      "version": "0.0.1-preview",
      "package_arguments": [],
      "environment_variables": [
        {
          "name": "WEATHER_CHOICES",
          "description": "Comma separated list of weather descriptions",
          "is_required": true,
          "is_secret": false
        }
      ]
    }
  ],
  "repository": {
    "url": "https://github.com/sanamhub/mcp-nuget",
    "source": "github"
  },
  "version_detail": {
    "version": "0.0.1-preview"
  }
}
```

- Pack the project using `dotnet pack`.

The `bin/Release` directory will contain the package file (.nupkg), which can be [published to NuGet.org](https://learn.microsoft.com/nuget/nuget-org/publish-a-package).

## Developing locally

To test this MCP server from source code (locally) without using a built MCP server package, you can configure your IDE to run the project directly using `dotnet run`.

```json
{
  "servers": {
    "mcp-nuget": {
      "type": "stdio",
      "command": "dotnet",
      "args": ["run", "--project", "."],
      "env": {
        "WEATHER_CHOICES": "sunny,humid,freezing,perfect"
      }
    }
  }
}
```

## Testing the MCP Server

Once configured, you can ask Copilot Chat for a random number, for example, `Give me 3 random numbers`. It should prompt you to use the `get_random_number` tool on the `mcp` MCP server and show you the results.

## Publishing to NuGet.org

1. Run `dotnet pack -c Release` to create the NuGet package
2. Publish to NuGet.org with `dotnet nuget push bin/Release/*.nupkg --api-key <your-api-key> --source https://api.nuget.org/v3/index.json`

## Using the MCP Server from NuGet.org

Once the MCP server package is published to NuGet.org, you can configure it in your preferred IDE. Both VS Code and Visual Studio use the `dnx` command to download and install the MCP server package from NuGet.org.

- **VS Code**: Create a `<WORKSPACE DIRECTORY>/.vscode/mcp.json` file
- **Visual Studio**: Create a `<SOLUTION DIRECTORY>\.mcp.json` file

For both VS Code and Visual Studio, the configuration file uses the following server definition:

```json
{
  "servers": {
    "mcp": {
      "type": "stdio",
      "command": "dnx",
      "args": ["mcp@0.0.1-preview", "--yes"],
      "env": {
        "WEATHER_CHOICES": "sunny,humid,freezing,perfect"
      }
    }
  }
}
```

## More information

.NET MCP servers use the [ModelContextProtocol](https://www.nuget.org/packages/ModelContextProtocol) C# SDK. For more information about MCP:

- [Official Documentation](https://modelcontextprotocol.io/)
- [Protocol Specification](https://spec.modelcontextprotocol.io/)
- [GitHub Organization](https://github.com/modelcontextprotocol)

Refer to the VS Code or Visual Studio documentation for more information on configuring and using MCP servers:

- [Use MCP servers in VS Code (Preview)](https://code.visualstudio.com/docs/copilot/chat/mcp-servers)
- [Use MCP servers in Visual Studio (Preview)](https://learn.microsoft.com/visualstudio/ide/mcp-servers)

### Pack for Nuget

```sh
dotnet pack mcp.csproj -c Release
```

### Publish to NuGet

```sh
dotnet nuget push bin/Release/*.nupkg --api-key <your-api-key> --source https://api.nuget.org/v3/index.json
```
