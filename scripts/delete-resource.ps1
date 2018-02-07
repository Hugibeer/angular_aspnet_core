[CmdletBinding()]
Param(
    [Parameter(Mandatory=$true, Position=1)]
    [string]$resource,
    [Parameter(Mandatory=$true, Position=2)]
    [string]$id
)

. .\Settings.ps1

$requestURL = "$BaseUrl/$resource/$id"

$data_type = "application/json"
$table_headers = @{
    "Content-Type" = $data_type
    "Accept" = "application/json;odata=fullmetadata"
}
Invoke-RestMethod -Method Delete -Uri $requestURL -Headers $table_headers