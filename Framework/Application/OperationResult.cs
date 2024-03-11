namespace Framework.Application;

public class OperationResult
{
    public bool IsSuccessfully { get; set; } = false;
    public string? Message { get; set; }

    public OperationResult()
    {

    }

    public OperationResult Succeeded(string? message = Application.OperationMessage.Done)
    {
        IsSuccessfully = true;
        Message = message;
        return this;
    }

    public OperationResult Failed(string? message = Application.OperationMessage.Failed)
    {
        IsSuccessfully = false;
        Message = message;
        return this;
    }
}