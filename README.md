## Web API YAML MediaTypeFormatter

### Installation
The MediaTypeFormatter has been compiled against the .NET Framework v4.0 for wide compatibility, you can import it into your project either via NuGet or direcctly.  We have included the instructions for both below.

#### via NuGet
The MediaTypeFormatter uses David Ebbo's excellent WebActivator extension inject startup behaviour into your web application.  This means other than installing the package you don't have do any additional work.

##### UI
The following apply to Visual Stuido 2012+ it probably works for other versions of Visual Studio as long as you have the NuGet Package Manager and .NET Framework v4.0.

 1. Right Click on your Project, and select "Manage NuGet Packages...".
 2. Ensure "nuget.org" is selected in the Package Source drop down.
 3. Search for "YamlMediaTypeFormatter" and press <Enter>.
 4. Depending on your configuration you may be asked to preview your changes, specifically you will be asked if you want to install YamlDotNet, WebActivatorEx and YamlMediaTypeFormatter. 