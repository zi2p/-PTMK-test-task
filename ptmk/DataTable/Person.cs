namespace ptnk.DataTable;

public class Person
{
    public Name Name;
    public DateBirth Date;
    public Gender Gender;

    public Person(Name name, DateBirth date, Gender gender)
    {
        Name = name;
        Date = date;
        Gender = gender;
    }
}