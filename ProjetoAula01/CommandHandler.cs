using ProjetoAula01.Entities;

class CommandHandler
{
    private readonly UserManager userManager;

    public CommandHandler(UserManager userManager)
    {
        this.userManager = userManager;
    }

    public void ProcessCommand(string command)
    {
        string[] commandParts = command.Split(' ');

        switch (commandParts[0].ToLower())
        {
            case "getusers":
                DisplayUsers();
                break;
            case "adduser":
                AddUser();
                break;
            case "deleteuser":
                if (commandParts.Length > 1)
                {
                    string userIdString = commandParts[1];
                    DeleteUserById(userIdString);
                }
                else
                {
                    Console.WriteLine("Invalid command format. Usage: deleteUser <userId>");
                }
                break;
            default:
                Console.WriteLine("Invalid command. Try again.");
                break;
        }
    }

    private void DisplayUsers()
    {
        Console.WriteLine("List of users:");
        foreach (var user in userManager.GetUsers())
        {
            user.Print();
        }
    }

    private void AddUser()
    {
        Console.Write("Enter username: ");
        string username = Console.ReadLine();

        Console.Write("Enter email: ");
        string email = Console.ReadLine();

        Console.Write("Enter cpf: ");
        string cpf = Console.ReadLine();

        User newUser = new User(Guid.NewGuid(), username, email, cpf);
        userManager.AddUser(newUser);

        Console.WriteLine($"User {newUser.Name} added successfully!");
    }

    private void DeleteUserById(string userIdString)
    {
        if (Guid.TryParse(userIdString, out Guid userId) || Guid.TryParseExact(userIdString, "D", out userId))
        {
            if (userManager.DeleteUserById(userId))
            {
                Console.WriteLine($"User with ID {userId} deleted successfully.");
            }
            else
            {
                Console.WriteLine($"User with ID {userId} not found.");
            }
        }
        else
        {
            Console.WriteLine("Invalid GUID format. Usage: deleteUser <userId>");
        }
    }
}