using System.Text.Json.Serialization;

namespace ProjetoAula01.Entities
{
    public class User
    {
        public Guid? Id;

        public string? Name;

        public string? Email;

        public string? Cpf;
        public User(Guid id, string name, string email, string cpf)
        {
            Id = id;
            Name = name;
            Email = email;
            Cpf = cpf;
        }

        public void Print()
        {
            Console.WriteLine($"Id: {this.Id},Username: {this.Name}, Email: {this.Email}, CPF: {this.Cpf}");

        }

    }
}
