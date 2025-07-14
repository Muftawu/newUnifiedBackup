
public class NewFormField
{
    public  string? Type { get; set; }
    public  string? IsRequired { get; set; }
    public  string? Label { get; set; }
    public  string? Placeholder { get; set; }
    public  string? Width { get; set; }
    public  byte[]? fileHolder = Array.Empty<byte>();
}

public class NewFormSelectOptionField 
{
    public string? OptionName { get; set; } 
}

public class NewFormStep
{
    public string StepNumber { get; set; }
    public string StepName { get; set; }
    public string StepDescription { get; set; }
}
