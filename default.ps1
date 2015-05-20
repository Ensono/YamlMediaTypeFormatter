Framework 4.6

properties {
  $packageVersion = "1.0.$((Get-Date).Year - 2000)$((Get-Date).DayOfYear).$([Math]::Floor(((Get-Date) - (Get-Date).Date).TotalSeconds))";
  $toolsVersion = "14.0";
  $buildConfiguration = "Release";
}

task default -depends Compile

task Compile -depends Clean { 
  msbuild Amido.Net.Http.Formatting.YamlMediaTypeFormatter.sln /p:VisualStudioVersion=$toolsVersion /p:Configuration=$buildConfiguration
}

task Clean { 
  msbuild Amido.Net.Http.Formatting.YamlMediaTypeFormatter.sln /t:clean /p:VisualStudioVersion=$toolsVersion /p:Configuration=$buildConfiguration
}

task Pack -depends Compile {
  & tools/nuget.exe pack "Amido.Net.Http.Formatting.YamlMediaTypeFormatter/Amido.Net.Http.Formatting.YamlMediaTypeFormatter.nuspec" -OutputDirectory "artefacts" -Version $packageVersion
}