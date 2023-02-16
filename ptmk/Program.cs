using ptnk.DataTable;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using ptnk.Services;

namespace ptnk
{
    internal class Program
    {
        private static void Main()
        {
        
            string connectionString =
                System.Configuration.ConfigurationManager.ConnectionStrings["jdbc:mysql://localhost:3306/MySQL"]
                    .ConnectionString;

            SqlConnection connection = new SqlConnection(connectionString);
            var service = new AppService(connection);


            string command = string.Empty;
            
            Console.WriteLine("Hello, it is myApp.");
            Console.WriteLine("This is consoleApp. Write 1 to start.");
                
            command = Console.ReadLine();
            
            if (command != "1")
            {
                Console.WriteLine("Write 1, please.");
                command = Console.ReadLine();
            }

            while (command is not null)
            {
                Console.WriteLine("If you want to add a new person to bd, write 2. -> (command: <<myApp 2 FullName BirthDate Gender>>\n" +
                                  "If you want to sort by Name, write 3. -> (command: <<myApp 3>>)\n" +
                                  "If you want to add random person to bd, write 4. -> (command: <<myApp 4>>)\n" +
                                  "If you want to see a bd table by Name start F, write 5. -> (command: <<myApp 5>>)\n" +
                                  "If you want to exit, write 0. -> (command: <<myApp 0>>)");
                
                command = Console.ReadLine();

                switch (command[6])
                {
                    case '2':
                    {
                        var newStr = string.Empty;
                        for (int i = 8; i < command.Length; i++)
                        {
                            newStr += command[i];
                        }
                        service.CreateNewPerson(newStr);
                        break;
                    }
                    case '3':
                        service.ReturnNameDateGenderAge();
                        break;
                    case '4':
                        service.AddManyData();
                        break;
                    case '5':
                        service.ReturnNameDateGenderAge();
                        break;
                    case '0':
                        return;
                    default:
                        Console.WriteLine("ERROR");
                        break;
                }
            }
        }
    }

}