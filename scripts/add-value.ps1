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

$data_type = "application/json"
$table_headers = @{
    "Content-Type" = $data_type
    "Accept" = "application/json;odata=fullmetadata"
}
Invoke-RestMethod -Method Post -Uri $requestURL -Body $jsonBody -Headers $table_headers