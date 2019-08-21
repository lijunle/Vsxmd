# Vsxmd

[![AppVeyor](https://img.shields.io/appveyor/ci/lijunle/Vsxmd/master.svg?logo=AppVeyor&logoColor=white)](https://ci.appveyor.com/project/lijunle/vsxmd/branch/master)
[![NuGet](https://img.shields.io/nuget/v/Vsxmd.svg?logo=NuGet&logoColor=white)](https://www.nuget.org/packages/Vsxmd)

A MSBuild task to convert [XML documentation](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/xmldoc/xml-documentation-comments) to Markdown syntax. Support both .Net Framework and .Net Core projects.

## Features

- Provide full information from the XML documentation file.
- Provide easy reading facilities - parameter table, link tooltip, etc.
- Provide table of contents to type and member links.
- Highlight code block through `<code lang="csharp">` tag.
- Reference `System` types to official MSDN pages.

## Get Started

If you are using Visual Studio:

- In Visual Studio, right click project name to open project properties window.
- Switch to **Build** tab, in **Output** section, check **XML documentation file** checkbox.
- Install [Vsxmd](https://www.nuget.org/packages/Vsxmd/) package from NuGet.
- Build the project, then a markdown file is generated next to the XML documentation file.

If you are using .Net Core CLI:

- Open project's CSPROJ file, declare [`DocumentationFile`](https://docs.microsoft.com/en-us/visualstudio/msbuild/common-msbuild-project-properties) property in `PropertyGroup` section. The path is relative to the project directory. [MSBuild Reserved and Well-Known properties](https://docs.microsoft.com/en-us/visualstudio/msbuild/msbuild-reserved-and-well-known-properties) are also available for this property.
- Run `dotnet add package Vsxmd` to install the the package to the project.
- Run `dotnet build` to build the project and generate the XML documentation and Markdown files.

## Vsxmd Options

There are some properties to customize the Markdown file generation process. They are all optional. If you want to use them, declare them in CSPROJ file's `PropertyGroup` section.

### `DocumentationMarkdown`

It is used to specify the generated Markdown file path. It defaults to the XML documentation file name with `.md` extension, under the same folder as the XML file. Similar to `DocumentationFile` property, the path is relative to the project directory and [MSBuild properties](https://docs.microsoft.com/en-us/visualstudio/msbuild/msbuild-reserved-and-well-known-properties) are available.

#### Example

```xml
<PropertyGroup>
    <DocumentationMarkdown>$(MSBuildProjectDirectory)\API.md</DocumentationMarkdown>
</PropertyGroup>
```

### `VsxmdAutoDeleteXml`

A boolean flag to delete the XML documentation file after the Markdown file is generated.

#### Example

```xml
<PropertyGroup>
    <VsxmdAutoDeleteXml>True</VsxmdAutoDeleteXml>
</PropertyGroup>
```

### `VsxmdSkipInternal`

A boolean flag to skip types and members that are internal, or protected inside a sealed type, in the generated Markdown file.
This flag depends on the ability to load the assembly associated with the XML documentation file. Types that have dependencies on other assemblies that are missing may be added to the Markdown file instead of being skipped.
For the most reliable results, all dependencies should be next to the assembly or installed globally.

#### Example

```xml
<PropertyGroup>
    <VsxmdSkipInternal>True</VsxmdSkipInternal>
</PropertyGroup>
```

### `VsxmdSkipNonBrowsable`

A boolean flag to skip types and members that are marked with the `[EditorBrowsable(EditorBrowsableState.Never)]` attribute in the generated Markdown file.
This flag depends on the ability to load the assembly associated with the XML documentation file. Types that have dependencies on other assemblies that are missing may be added to the Markdown file instead of being skipped.
For the most reliable results, all dependencies should be next to the assembly or installed globally.

#### Example

```xml
<PropertyGroup>
    <VsxmdSkipNonBrowsable>True</VsxmdSkipNonBrowsable>
</PropertyGroup>
```

## Extend XML documentation

There are some extended features based on XML documentation. They are not described in [XML recommended tags](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/xmldoc/recommended-tags-for-documentation-comments), but they are worth to use.

### Highlight Code Block

To highlight code block in the Markdown file, declare the attribute `lang` in `<code>` tag and set it to a program language identifier.

#### Example

```xml
<code lang="javascript">
    function test() {
        console.log("notice the blank line before this function?");
    }
</code>
```

## Programmatic API

This library provides the following programmatic API to convert XML documentation file to Markdown syntax programmatically.

- [Converter](Vsxmd/Vsxmd.md#T-Vsxmd-Converter) : [IConverter](Vsxmd/Vsxmd.md#T-Vsxmd-IConverter)
  - [string ToMarkdown()](Vsxmd/Vsxmd.md#M-Vsxmd-IConverter-ToMarkdown)
  - [string ToMarkdown(ConverterSettings settings)](Vsxmd/Vsxmd.md#M-Vsxmd-Converter-ToMarkdown-Vsxmd-ConverterSettings-)
  - [static string ToMarkdown(XDocument document)](Vsxmd/Vsxmd.md#M-Vsxmd-Converter-ToMarkdown-System-Xml-Linq-XDocument-)

## Markdown File Demo

The best demo is this project's documentation file, [Vsxmd.md](Vsxmd/Vsxmd.md). It is generated by this project itself.

## Known Issue

The syntax for the [`list`](https://msdn.microsoft.com/en-us/library/y3ww3c7e.aspx) comment tag is not well defined. It will be skipped during render. If you have ideas, please [open an issue](https://github.com/lijunle/Vsxmd/issues).

## Credits

This project is initially inspired from a [gist](https://gist.github.com/formix/515d3d11ee7c1c252f92). But in the later releases, the implementation is rewritten.

## License

MIT License.
