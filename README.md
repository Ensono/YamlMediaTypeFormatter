![Web API YAML MediaTypeFormatter](Artefacts/logo.png)

[![Build status](https://ci.appveyor.com/api/projects/status/x53x7nq4ppfn15y0/branch/master?svg=true)](https://ci.appveyor.com/project/richard-slater/yamlmediatypeformatter/branch/master)

## Web API YAML MediaTypeFormatter

### Installation
The `MediaTypeFormatter` has been compiled against the .NET Framework v4.0 to provide compatibility across a range of recent ASP.NET Web API releases. Developers can import it into your project either via NuGet or directly as an Assembly Reference, instructions are included for both below.

#### NuGet Method
The `MediaTypeFormatter` NuGet package uses [David Ebbo's](https://github.com/davidebbo) excellent [WebActivator extension](https://github.com/davidebbo/WebActivator) to inject startup behavior into your web application.  This means other than installing the package you don't have do any additional work to be able to accept and emit YAML.

##### UI
The following instructions apply to Visual Studio 2012+ it probably works for other versions of Visual Studio as long as you have the appropriate NuGet Package Manager extension and .NET Framework v4.0.

 1. Right Click on your Project, and select **"Manage NuGet Packages..."**.
 2. Ensure **"nuget.org"** is selected in the Package Source drop down.
 3. Search for **"YamlMediaTypeFormatter"** and press <Enter>.
 4. Depending on your configuration you may be asked to preview your changes, specifically you will be asked if you want to install `YamlDotNet`, `WebActivatorEx` and `YamlMediaTypeFormatter`.

##### Command Line

The following instructions apply to Visual Studio 2012+ it probably works for other versions of Visual Studio as long as you have the appropriate NuGet Package Manager extension and .NET Framework v4.0.

 1. From the Visual Studio Menu Bar, Select **"Tools"**.
 2. Select **"NuGet Package Manager"**, then **"Package Manager Console"**.
 3. Ensure **"nuget.org"** is selected in the Package Source drop down.
 4. Enter the following command in the console, replacing *[YourProjectName]* with the name of the project you wish to install the package into:

        PM> Install-Package Amido.Net.Http.Formatting.YamlMediaTypeFormatter -ProjectName [YourProjectName]

#### Manual Method

If you do not want, or for some reason can not use NuGet or WebActivator then it is possible to install and use `YamlMediaTypeFormatter` without either by compiling and referencing `YamlMediaTypeFormatter` and `YamlDotNet` directly.

In the examples below, I use the HTTPS Git endpoints for each repository as these provide for the widest support.  It is possible use SSH or Git protocols to clone the repositories although firewalls may interfere with their function.

 1. Obtain the `YamlMediaTypeFormatter` solution source code, by cloning the Git repository into an appropriate location, such as `C:\Source`:

        cd C:\Source
        git clone https://github.com/amido/YamlMediaTypeFormatter.git

 2. From PowerShell execute the following command:

        cd YamlMediaTypeFormatter
        ./build.ps1

 3. After the build has completed browse to the following path in PowerShell or Windows Explorer:

        Solutions\Amido.Net.Http.Formatting.YamlMediaTypeFormatter\bin\Release

 4. Copy `Amido.Net.Http.Formatting.YamlMediaTypeFormatter.dll` to a location that you can reference from within your own project.
 5. Add a reference to `Amido.Net.Http.Formatting.YamlMediaTypeFormatter.dll`.
 6. Obtain the `YamlDotNet` solution source code, by cloning the Git repository into an appropriate location such as `C:\Source` using PowerShell:

        cd C:\Source
        git clone https://github.com/aaubry/YamlDotNet.git

 7. Change directory to `YamlDotNet` and execute the command to download and unblock NuGet.exe:

        cd YamlDotNet
        Invoke-WebRequest https://nuget.org/nuget.exe -OutFile nuget.exe
        Unblock-File nuget.exe

 8. Restore NuGet packages:

        & .\nuget.exe restore

 9. Use MSBuild to compile the solution:

        & "${ENV:ProgramFiles(x86)}\MSBuild\14.0\bin\MSBuild.exe" .\YamlDotNet.sln /p:configuration=Release-Signed

 10. After the build has completed browse to the following path in PowerShell or Windows Explorer:

        YamlDotNet\bin\Release-Signed

 11. Copy `YamlDotNet.dll` to a location that you can reference from within your own project.
 12. Add a reference to `YamlDotNet.dll`.
 13. The `MediaTypeFormatter` will need to be registered with ASP.NET Web API, in your `WebApiConfig.cs` at the following code to the `Register` method:

        config.Formatters.Add(new YamlMediaTypeFormatter()); 

## Contributing

We welcome contributions from the community in the form of GitHub Pull Requests, you will need to use Visual Stuido 2015 as I use some of the syntactic sugar from C# 6.0.  I would also suggest you use ReSharper 9.1 to maintain coding style through the project.