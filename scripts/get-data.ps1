[CmdletBinding()]
Param(
    [Parameter(Mandatory=$true, Position=1)]
    [string]$endpoint
)

. .\Settings.ps1

$requestURL = "$BaseUrl/$endpoint"
Invoke-RestMethod -Method Get -Uri $requestURL -Headers $table_headers | ConvertTo-Json >> outfile.json