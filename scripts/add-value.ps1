[CmdletBinding()]
Param(
    [Parameter(Mandatory=$true, Position=1)]
    [string]$value
)

. .\Settings.ps1

$requestURL = "$BaseUrl/values"
$body = @{
    Name = $value
}

$jsonBody = $body | ConvertTo-Json

Invoke-RestMethod -Method Post -Uri $requestURL -Body $jsonBody -Headers $table_headers