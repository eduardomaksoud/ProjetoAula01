namespace ProjetoAula01
{
    public class Program
    {
        public static void Main(string[] args)
        { 
            EmployeeRepository employeeRepository = new EmployeeRepository();
            EmployeeManager employeeManager = new EmployeeManager(employeeRepository);
            CommandHandler commandHandler = new CommandHandler(employeeManager);

            Console.WriteLine("Type 'getEmployees' to retrieve the list of employees.");
            Console.WriteLine("Type 'addEmployee' to add a new employee.");
            Console.WriteLine("Type 'deleteEmployee' to delete an employee by an id.");
            Console.WriteLine("Type 'exit' to exit.");

            while (true)
            {
                Console.Write("Enter command: ");
                string command = Console.ReadLine();

                if (command.ToLower() == "exit")
                {
                    break;
                }

                commandHandler.ProcessCommand(command);
            }

        }
    }
}