namespace DTOs;

public partial class FormFieldWithOptionsDTO
{
    public FormFieldDTO FormField { get; set; }
    public List<FormSelectOptionDTO>? SelectOptions { get; set; }
}
