using ProjetoAula01.Entities;

class EmployeeManager
{
    private readonly EmployeeRepository employeeRepository;
    private readonly List<Employee> employees;

    public EmployeeManager(EmployeeRepository employeeRepository)
    {
        this.employeeRepository = employeeRepository;
        this.employees = employeeRepository.GetEmployees();
    }

    public List<Employee> GetEmployees()
    {
        return employees;
    }

    public void AddEmployee(Employee employee)
    {
        employees.Add(employee);
        employeeRepository.SaveEmployees(employees);
    }

    public bool DeleteEmployeeById(Guid id)
    {
        Employee userToDelete = employees.FirstOrDefault(u => u.Id == id);
        if (userToDelete != null)
        {
            employees.Remove(userToDelete);
            employeeRepository.SaveEmployees(employees);
            return true;
        }
        return false;
    }
}
