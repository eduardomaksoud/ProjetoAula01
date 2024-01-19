using ProjetoAula01.Entities;
using Newtonsoft.Json;
class EmployeeRepository
{
    private const string FilePath = "employees.json";
    public List<Employee> GetEmployees()
    {
        if (File.Exists(FilePath))
        {
            string jsonData = File.ReadAllText(FilePath);
            if(jsonData != null && jsonData != "")
            {
                return JsonConvert.DeserializeObject<List<Employee>>(jsonData);
            }
        }
        return new List<Employee>();
    }

    public void SaveEmployees(List<Employee> employees)
    {
        string jsonData = JsonConvert.SerializeObject(employees);
        File.WriteAllText(FilePath, jsonData);
    }
}






