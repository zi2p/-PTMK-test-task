namespace ptnk.DataTable.Dao;

public class PeopleDao
{
    private Person _person;
    
    public PeopleDao(Person person)
    {
        _person = person;
    }

    public string? GetName()
    {
        var name = _person.Name.ToString();
        return name;
    }

    public string? GetBirthDate()
    {
        var newDate = _person.Date.ToString();
        return newDate;
    }
    
    public string? GetGender()
    {
        var gender = _person.Gender.ToString();
        return gender;
    }

    public string? GetFullAge()
    {
        var age = ((DateTime.Now - _person.Date.BirthDate).Days / 365).ToString();
        return age;
    }
    
}