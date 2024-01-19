namespace ProjetoAula01.Entities
{
    public class Employee
    {
        public Guid? Id;

        public string? Name;

        public string? Cpf;

        string? Code;

        DateTime? AdmissionDate;

        string? Role;

        decimal? Salary;
        public Employee(Guid id, string name, string cpf, string code, DateTime admissionDate, string role, decimal salary)
        {
            Id = id;
            Name = name;
            Cpf = cpf;
            Code = code;
            AdmissionDate = admissionDate;
            Role = role;
            Salary = salary;
        }

        public void Print()
        {
            Console.WriteLine($"" +
                $"Id: {this.Id}," +
                $"Username: {this.Name}, " +
                $"CPF: {this.Cpf}, " +
                $"Code: {this.Code}, " +
                $"AdmissionDate: {this.AdmissionDate.ToString()}, " +
                $"Role: {this.Role}, " +
                $"Salary: {this.Salary}"
                );
        }

    }
}
