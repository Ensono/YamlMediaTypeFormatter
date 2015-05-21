Framework 4.6

properties {
  $assemblyVersion = 0;
  $packageVersion = "1.0.0.{0}" -f $assemblyVersion;
  $toolsVersion = "14.0";
  $buildConfiguration = "Release";
  $solution = "Solutions/Amido.Net.Http.Formatting.YamlMediaTypeFormatter.sln";
}

task default -depends Compile

task Clean {
  msbuild $solution /m /t:clean /p:VisualStudioVersion=$toolsVersion /p:Configuration=$buildConfiguration
}

task Compile -depends Clean { 
  msbuild $solution /m /p:VisualStudioVersion=$toolsVersion /p:Configuration=$buildConfiguration
}

task Pack -depends Compile {
  & tools/nuget.exe pack "Solutions/Amido.Net.Http.Formatting.YamlMediaTypeFormatter/Amido.Net.Http.Formatting.YamlMediaTypeFormatter.nuspec" -OutputDirectory "Artefacts" -Version $packageVersion
}