namespace Utils;

public class Letter
{
    public int? LetterId { get; set; }
    public string? Name { get; set; }
    public string? ReferenceNumber { get; set; }
    public string? Programme { get; set; }
    public string? LetterType { get; set; }
    public string? Status { get; set; }
}


    public static class DummyData 
    {
    public static List<Letter> Letters = new List<Letter>
    {
        new Letter
        {
            LetterId = 1,
            Name = "John Doe",
            ReferenceNumber = "10125452",
            Programme = "Bsc Electrical Engineering",
            LetterType = "Reference Letter",
            Status = "Pending",
        },

        new Letter
        {
             LetterId = 2,
            Name = "Sean Prestly",
            ReferenceNumber = "14230021",
            Programme = "Bsc Politcal Studies",
            LetterType = "Attestation Letter",
            Status = "Processed"
        },

        new Letter
        {
            LetterId = 3,
            Name = "Steve Molaro",
            ReferenceNumber = "02365878",
            Programme = "Msc Computer Science",
            LetterType = "Transcript",
            Status = "Processed"
        },

        new Letter
        {
            LetterId = 4,
            Name = "Brain Cole",
            ReferenceNumber = "96874517",
            Programme = "Bsc Optometry",
            LetterType = "Introductory",
            Status = "Pending",
        },

        new Letter
        {
            LetterId = 5,
            Name = "Mark Gillies",
            ReferenceNumber = "36997454",
            Programme = "Bsc Business Admin",
            LetterType = "Recommendation Letter",
            Status = "Completed",
        },

        new Letter
        {
            LetterId = 6,
            Name = "Sarah Willies",
            ReferenceNumber = "14578560",
            Programme = "Bsc Nursing",
            LetterType = "Recommendation Letter",
            Status = "Completed",
        },
    };
}