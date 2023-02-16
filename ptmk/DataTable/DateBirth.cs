namespace ptnk.DataTable;

public class DateBirth
{
    public DateTime BirthDate;
    private string DateToString;

    public DateBirth(string birthDate)
    {
        DateToString = birthDate;
        BirthDate = DateTime.Parse(DateToString);
    }

}