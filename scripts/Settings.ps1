$BaseUrl = "http://localhost:56691/api"
$data_type = "application/json"
$table_headers = @{
    "Content-Type" = $data_type;
    "Accept" = "application/json;odata=fullmetadata";
    "Authorization" = "Bearer eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiIyIiwidW5pcXVlX25hbWUiOiJodWdpYmVlciIsIm5iZiI6MTUxODA1MjgxMiwiZXhwIjoxNTE4MTM5MjEyLCJpYXQiOjE1MTgwNTI4MTJ9.4PD2Sea3K87-Y7vPcwK9KEO_64zZO4RMFSK2xBX6qZHEEqG7kZPLVyV-xCaxDUHdf9k2rwirMmDXGMxZmZYYPA";
}
