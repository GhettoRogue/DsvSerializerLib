using DsvSerializerLib.Core;

namespace DsvSerializerLib.ConsoleTest;

public class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    [DsvIgnore]
    public string FullName => $"{LastName} {FirstName}";
    
    public DateTime BirthDate { get; set; }
}