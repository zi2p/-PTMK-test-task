using ptnk.DataTable.Dao;
namespace ptnk.DataTable;

public class DataTable
{
    private List<PeopleDao> People;

    public List<PeopleDao> GetPeople()
    {
        return People;
    }

    public List<string> GetNamesPeople()
    {
        List<string> names = People.Select(people => people.GetName()).ToList();
        return names;
    }

    public void AddPeople(Person person)
    {
        var dao = new PeopleDao(person);
        People.Add(dao);
    }
}