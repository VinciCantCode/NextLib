namespace BestLibraryManagement.Models;

public class ErrorViewModel
{
    public string? RequestId { get; set; }
    public string? ExceptionMessage { get; set; }

    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    public int OriginalStatusCode { get; set; }
    public string? OriginalPathAndQuery { get; set; }
}
