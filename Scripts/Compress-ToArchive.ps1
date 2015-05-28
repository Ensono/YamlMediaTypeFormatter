# Copyright 2015 Amido Limited
function Compress-ToArchive {
  Param(
    [Parameter(Mandatory=$true)]
    $Source,
    [Parameter(Mandatory=$true)]
    $Destination
    )
  process {
    Add-Type -assembly "System.IO.Compression.FileSystem";

    [IO.Compression.ZipFile]::CreateFromDirectory($Source, $Destination);
  }
}