# Copyright 2015 Amido Limited
$ProgressPreference = "SilentlyContinue";
Get-Module psake | Remove-Module;

$psakeModule = "$PSScriptRoot\Scripts\psake\psake.psm1";

if (-Not (Test-Path $psakeModule)) {
  throw "Couldn't load Psake, as the Psake module was not found in the repository.";
}

Import-Module $psakeModule;

Invoke-psake Pack;