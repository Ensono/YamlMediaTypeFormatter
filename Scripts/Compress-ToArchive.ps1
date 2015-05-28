# Copyright 2015 Amido Limited
function Compress-ToArchive {
  Param(
    [ValidateScript( { Test-Path $_ -PathType 'Container' } )] 
    [Parameter(Mandatory=$true)]
    $Source,
    [ValidateScript( { -Not (Test-Path $_) } )] 
    [Parameter(Mandatory=$true)]
    $Destination
    )
  process {
    Add-Type -assembly "System.IO.Compression.FileSystem";

    [IO.Compression.ZipFile]::CreateFromDirectory($Source, $Destination);
  }
}