using DsvSerializerLib.ConsoleTest;
using DsvSerializerLib.Core;

var person = new Person()
{
    FirstName = "Andrey",
    LastName = "Starinin",
    BirthDate = new DateTime(1986, 2, 18)
};

var dsv = DsvSerializer.Serialize(person, ',');
Console.WriteLine(dsv);