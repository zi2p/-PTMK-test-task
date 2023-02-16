using ptnk.DataTable;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;



namespace ptnk.Services;

public class AppService
{
    private DataTable.DataTable _table = new DataTable.DataTable();
    private SqlConnection _connection;

    public AppService(SqlConnection connection)
    {
        _connection = connection;
    }
    
    public void CreateNewPerson(string newText) // ФИО ДатаРождения Пол
    {
        _connection.Open();
        var myString = newText.Split(' ');
        
        var fullName = myString[0] + myString[1] + myString[2];  // ФИО 
        var dateBirth = myString[3];      // ДатаРождения
        var sGender = myString[4];      // Пол

        var gender = Gender.Male;
        if (sGender[0] == 'm') gender = Gender.Male;
        if (sGender[0] == 'f') gender = Gender.Female;

        var name = new Name(fullName);
        var date = new DateBirth(dateBirth);

        var person = new Person(name, date, gender);
        _table.AddPeople(person);
        _connection.Clouse();
    }

    public void ReturnNameDateGenderAge()
    {
        _connection.Open();
        /*
         SELECT distinct * FROM people ORDER BY Name
         */
        _connection.Clouse();
    }

    public void AddManyData()  // create many people
    {
        for (int i = 0; i < 1000000; i++)
        {
            var gender = "male";
            
            if (i % 2 == 1) gender = "female";
            
            var firstName = RandomString(4);
            var secondName = RandomString(4);
            var thirdName = RandomString(4);

            var date = "16.02.2023";

            CreateNewPerson(firstName + secondName + thirdName + date + gender);
        }
        
        for (int i = 0; i < 100; i++)  // create 100 men with name Frank
        {
            var gender = "male";
            
            var firstName = "Frank";
            var secondName = RandomString(4);
            var thirdName = RandomString(4);

            var date = "16.02.2023";

            CreateNewPerson(firstName + secondName + thirdName + date + gender);
        }
    }

    public void ReturnTableByNameGender(string str, string gender)
    {
        _connection.Open();
        /*
         SELECT Name, Gender FROM people WHERE Name LIKE 'str[0]%' AND Gender Like gender
        */
        _connection.Clouse();
    }
    
    private Random random = new Random();

    private string RandomString(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
    }
}