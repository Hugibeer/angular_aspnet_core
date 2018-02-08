[CmdletBinding()]
Param(
    [Parameter(Mandatory=$true, Position=1)]
    [string]$username,
    [Parameter(Mandatory=$true, Position=2,ParameterSetName = "Secret")]
    [string]$password
)

. .\Settings.ps1

$requestURL = "$BaseUrl/auth/register"
$body = @{
    userName = $username;
    password = $password
}

$jsonBody = $body | ConvertTo-Json
Write-Host $jsonBody
Invoke-RestMethod -Method Post -Uri $requestURL -Body $jsonBody -Headers $table_headers