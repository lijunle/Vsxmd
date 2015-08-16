# Vsxmd

[![Build status](https://ci.appveyor.com/api/projects/status/mxm9wcf5j5yrf1uu/branch/master?svg=true)](https://ci.appveyor.com/project/lijunle/vsxmd/branch/master)

A MSBuild task to convert VS generated XML document to Markdown syntax.

# Usage

- In Visual Studio, right click project name to open project properties window.
- Open **Build** tab, in **Output** section, check **XML documentation file**.
- Install [Vsxmd](https://www.nuget.org/packages/Vsxmd/) package from NuGet.
- Build the project, then a `.md` file is generated next to the XML document.

# License

MIT License.
