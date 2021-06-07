$InstalledSoftware64 = Get-ChildItem "HKLM:\Software\Microsoft\Windows\CurrentVersion\Uninstall" -Depth 0
$InstalledSoftware32 = Get-ChildItem "HKLM:\Software\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall" -Depth 0

$AllInstalledSoftware = @()

$InstalledSoftware32 | ForEach-Object {
    $displayName = $_.GetValue('DisplayName')
    $version = $_.GetValue('DisplayVersion')
    $vendor = $_.GetValue('Publisher')

    if ($displayName) {
        $AllInstalledSoftware += [pscustomobject]@{
            Name = $displayName
            Vendor = $vendor
            Version = $version
            BitDepth = "32bit"
        }
    }
}

$InstalledSoftware64 | ForEach-Object {
    $displayName = $_.GetValue('DisplayName')
    $version = $_.GetValue('DisplayVersion')
    $vendor = $_.GetValue('Publisher')

    if ($displayName) {
        $AllInstalledSoftware += [pscustomobject]@{
            Name = $displayName
            Vendor = $vendor
            Version = $version
            BitDepth = "64bit"
        }
    }
}

#[string]$output = "Applications found on $($env:ComputerName): `nVendor, Name, Version, BitDepth"
#$AllInstalledSoftware | Sort-Object -Property Vendor | Foreach-Object { $output += "`n$($_.Vendor), $($_.Name), $($_.Version), $($_.BitDepth)" }
#Write-Information $output

$AllInstalledSoftware | Sort-Object -Property Vendor

Write-Information "Done"

<#ActionSettings
{
    "DisplayName": "Get Applications",
    "DisplayElement": "Tab",
    "Description": "List installed applications recorded in registry",
    "RunOnConnect": false,
    "LogScriptContent": false,
    "FilterProperties": ["Name", "Vendor"]
}
ActionSettings#>