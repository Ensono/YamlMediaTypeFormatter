properties {
  
}

task default -depends Compile

task Compile -depends Clean { 
  msbuild Amido.Net.Http.Formatting.YamlMediaTypeFormatter.sln /p:VisualStudioVersion=14.0 /p:Configuration=Release
}

task Clean { 
  msbuild Amido.Net.Http.Formatting.YamlMediaTypeFormatter.sln /t:clean /p:VisualStudioVersion=14.0 /p:Configuration=Release
}

task Pack -depends Compile {
  & tools/nuget.exe pack "Amido.Net.Http.Formatting.YamlMediaTypeFormatter/Amido.Net.Http.Formatting.YamlMediaTypeFormatter.nuspec" -OutputDirectory "artefacts" -Version 1.0.0.0
}