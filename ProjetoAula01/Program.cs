namespace ProjetoAula01
{
    public class Program
    {
        public static void Main(string[] args)
        { 
            UserRepository userRepository = new UserRepository();
            UserManager userManager = new UserManager(userRepository);
            CommandHandler commandHandler = new CommandHandler(userManager);

            Console.WriteLine("Type 'getUsers' to retrieve the list of users.");
            Console.WriteLine("Type 'addUser' to add a new user.");
            Console.WriteLine("Type 'deleteUser' to delete a user by ID.");
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