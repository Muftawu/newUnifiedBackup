namespace DTOs;

public class ResponseDTO
{
    public bool Status { get; set; } = false;

    public string? Message { get; set; }

    public object? DataObject { get; set; }

     public object? MetaData { get; set; }

    public ResponseDTO SetStatus(bool status)
    {
        Status = status;
        return this;
    }
    public ResponseDTO SetMessage(string message)
    {
        Message = message;
        return this;
    }

    public ResponseDTO SetDataObject(object dataObject)
    {
        DataObject = dataObject;
        return this;
    }

     public ResponseDTO SetMetaData(object metadata)  
    {
        this.MetaData = metadata;
        return this;
    }

}

