using ProjetoAula01.Entities;

class CommandHandler
{
    private readonly EmployeeManager employeeManager;

    public CommandHandler(EmployeeManager employeeManager)
    {
        this.employeeManager = employeeManager;
    }

    public void ProcessCommand(string command)
    {
        string[] commandParts = command.Split(' ');

        switch (commandParts[0].ToLower())
        {
            case "getemployees":
                DisplayUsers();
                break;
            case "addemployee":
                AddEmployee();
                break;
            case "deleteemployee":
                if (commandParts.Length > 1)
                {
                    string userIdString = commandParts[1];
                    DeleteUserById(userIdString);
                }
                else
                {
                    Console.WriteLine("Invalid command format. Usage: deleteEmployee <employeeId>");
                }
                break;
            default:
                Console.WriteLine("Invalid command. Try again.");
                break;
        }
    }

    private void DisplayUsers()
    {
        Console.WriteLine("List of employees:");
        foreach (var employee in employeeManager.GetEmployees())
        {
            employee.Print();
        }
    }

    private void AddEmployee()
    {
        Console.Write("Enter username: ");
        string username = Console.ReadLine();

        Console.Write("Enter cpf: ");
        string cpf = Console.ReadLine();

        Console.Write("Enter code: ");
        string code = Console.ReadLine();

        Console.Write("Enter admission date (YYYY-MM-DD): ");
        string admissionDateInput = Console.ReadLine();

        Console.Write("Enter role: ");
        string role = Console.ReadLine();

        Console.Write("Enter salary: ");
        decimal salary = decimal.Parse(Console.ReadLine());

        Employee newEmployee = new Employee(Guid.NewGuid(), username, cpf, code, DateTime.Parse(admissionDateInput), role, salary);
        employeeManager.AddEmployee(newEmployee);

        Console.WriteLine($"Employee {newEmployee.Name} added successfully!");
    }

    private void DeleteUserById(string employeeIdString)
    {
        if (Guid.TryParse(employeeIdString, out Guid employeeId) || Guid.TryParseExact(employeeIdString, "D", out employeeId))
        {
            if (employeeManager.DeleteEmployeeById(employeeId))
            {
                Console.WriteLine($"Employee with ID {employeeId} deleted successfully.");
            }
            else
            {
                Console.WriteLine($"Employee with ID {employeeId} not found.");
            }
        }
        else
        {
            Console.WriteLine("Invalid GUID format. Usage: deleteEmployee <employeeId>");
        }
    }
}