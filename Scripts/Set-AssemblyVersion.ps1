# Copyright 2015 Amido Limited
function Set-AssemblyVersion {
  Param(
    [ValidateScript({Test-Path $_ -PathType 'Leaf'})] 
    [Parameter(Mandatory=$True)]
    [string]
    $Path,
    [ValidateScript({[System.Version]::TryParse("1.0.0.0", [ref]$null)})]
    [Parameter(Mandatory=$True)]
    [string]
    $Version,
    [Parameter(Mandatory=$True)]
    [string]
    $SemanticVersion
    )

  process {
    $PathActual = Resolve-Path $Path;

    $assemblyVersionPattern = 'AssemblyVersion\("([0-9])+\.([0-9])+\.([0-9])+\-?(.*)?"\)';
    $assemblyFileVersionPattern = 'AssemblyFileVersion\("([0-9])+\.([0-9])+\.([0-9])+\-?(.*)?"\)';
    $assemblyInformationalVersionPattern = 'AssemblyInformationalVersion\("(.+)\)';

    $assemblyVersion = 'AssemblyVersion("' + $Version + '")';
    $assemblyFileVersion = 'AssemblyFileVersion("' + $Version + '")';
    $assemblyInformationalVersion = 'AssemblyInformationalVersion("' + $SemanticVersion + '")';

    $tempFile = ("{0}.tmp" -f $PathActual)
 
    Get-Content -Path $PathActual | ForEach-Object {
      % { $_ -Replace $assemblyVersionPattern, $assemblyVersion } |
      % { $_ -Replace $assemblyFileVersionPattern, $assemblyFileVersion } |
      % { $_ -Replace $assemblyInformationalVersionPattern, $assemblyInformationalVersion }
    } | Set-Content -Path $tempFile
 
    Remove-Item $PathActual
    Rename-Item $tempFile $PathActual
  }
}