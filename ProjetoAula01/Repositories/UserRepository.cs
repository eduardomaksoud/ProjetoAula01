using ProjetoAula01.Entities;
using Newtonsoft.Json;


class UserRepository
{
    private const string FilePath = "users.json";

    public List<User> GetUsers()
    {
        if (File.Exists(FilePath))
        {
            string jsonData = File.ReadAllText(FilePath);
            if(jsonData != null && jsonData != "")
            {
                return JsonConvert.DeserializeObject<List<User>>(jsonData);
            }
        }
        return new List<User>();
    }

    public void SaveUsers(List<User> users)
    {
        string jsonData = JsonConvert.SerializeObject(users);
        File.WriteAllText(FilePath, jsonData);
    }
}






