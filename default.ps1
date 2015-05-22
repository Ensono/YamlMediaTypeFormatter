# Copyright 2015 Amido Limited

Framework 4.6

Include "Scripts/Initialize-SharedAssemblyInfo.ps1";
Include "Scripts/Set-AssemblyVersion.ps1";

properties {
  $buildSequenceNumber = 0;
  $packageVersion = "1.0.0";
  $rev = $(git rev-parse --short HEAD);
  $metadata = "-beta.1";
  $toolsVersion = "14.0";
  $buildConfiguration = "Release";
  $solution = "Solutions/Amido.Net.Http.Formatting.YamlMediaTypeFormatter.sln";
  $sharedAssemblyInfo = "Solutions/SharedAssemblyInfo.cs";
}

task default -depends Compile

task GitClean -preCondition { (git status | Where-Object { $_ -match 'nothing to commit' } | Measure-Object).Count -eq 1 } {
  & git clean -df
}

task Clean -depends GitClean {
  msbuild $solution /m /t:clean /p:VisualStudioVersion=$toolsVersion /p:Configuration=$buildConfiguration
}

task SetupSharedAssemblyInfo {
  Initialize-SharedAssemblyInfo -RemoveComments;
}

task SetVersion -depends SetupSharedAssemblyInfo {
  $buildVersion = "+build.sha.{0}.seq.{1}" -f $rev, $buildSequenceNumber;
  $semanticVersion = "$($packageVersion)$($metadata)$($buildVersion)";
  Set-AssemblyVersion -Path $sharedAssemblyInfo -Version $packageVersion -SemanticVersion $semanticVersion;
}

task Compile -depends SetVersion, Clean { 
  msbuild $solution /m /p:VisualStudioVersion=$toolsVersion /p:Configuration=$buildConfiguration
  Set-AssemblyVersion -Path $sharedAssemblyInfo -Version $packageVersion -SemanticVersion "From Source";
}

task Pack -depends Compile {
  & tools/nuget.exe pack "Solutions/Amido.Net.Http.Formatting.YamlMediaTypeFormatter/Amido.Net.Http.Formatting.YamlMediaTypeFormatter.nuspec" -OutputDirectory "Artefacts" -Version $packageVersion;
}