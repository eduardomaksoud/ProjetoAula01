using ProjetoAula01.Entities;

class UserManager
{
    private readonly UserRepository userRepository;
    private readonly List<User> users;

    public UserManager(UserRepository userRepository)
    {
        this.userRepository = userRepository;
        this.users = userRepository.GetUsers();
    }

    public List<User> GetUsers()
    {
        return users;
    }

    public void AddUser(User user)
    {
        users.Add(user);
        userRepository.SaveUsers(users);
    }

    public bool DeleteUserById(Guid userId)
    {
        User userToDelete = users.FirstOrDefault(u => u.Id == userId);
        if (userToDelete != null)
        {
            users.Remove(userToDelete);
            userRepository.SaveUsers(users);
            return true;
        }
        return false;
    }
}
