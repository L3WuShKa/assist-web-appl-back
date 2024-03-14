using System;
using System.Collections.Generic;

namespace YourNamespace.Services
{
    public class AuthService
    {
        private Dictionary<string, User> users = new Dictionary<string, User>();

        public AuthService()
        {
            // Constructor
        }

        // Metoda pentru inregistrarea unui nou administrator de organizatie
        public void SignUpOrganizationAdmin(string name, string email, string password, string organizationName, string headquarterAddress)
        {
            // Verifica daca email-ul este deja folosit pentru un alt cont
            if (users.ContainsKey(email))
            {
                throw new Exception("Email already registered.");
            }

            // Creeaza un nou administrator de organizatie
            OrganizationAdmin newAdmin = new OrganizationAdmin(name, email, password, organizationName, headquarterAddress);

            // Adauga utilizatorul in dictionarul de utilizatori
            users.Add(email, newAdmin);
        }

        // Metoda pentru generarea URL-ului de inregistrare pentru angajati
        public string GenerateEmployeeSignUpUrl(string adminEmail)
        {
            // Verifica daca exista un administrator de organizatie cu acest email
            if (!users.ContainsKey(adminEmail) || !(users[adminEmail] is OrganizationAdmin))
            {
                throw new Exception("Invalid organization administrator email.");
            }

            // Genereaza URL-ul de inregistrare pentru angajati
            return "https://yourwebsite.com/signup?admin=" + adminEmail;
        }

        // Metoda pentru inregistrarea unui nou angajat
        public void SignUpEmployee(string name, string email, string password, string signUpUrl)
        {
            // Verifica daca URL-ul de inregistrare este valid
            // Aici ar trebui sa fie logica pentru validarea URL-ului, poate folosind un token sau un alt mecanism de securitate
            // Daca URL-ul nu este valid, ar trebui aruncata o exceptie

            // Creeaza un nou angajat
            Employee newEmployee = new Employee(name, email, password);

            // Adauga utilizatorul in dictionarul de utilizatori
            users.Add(email, newEmployee);
        }

        // Metoda pentru autentificarea utilizatorului
        public bool AuthenticateUser(string email, string password)
        {
            // Verifica daca exista un utilizator cu acest email
            if (!users.ContainsKey(email))
            {
                return false;
            }

            // Verifica parola utilizatorului
            return users[email].Password == password;
        }

        // Metoda pentru obtinerea rolului unui utilizator
        public string GetUserRole(string email)
        {
            // Verifica daca exista un utilizator cu acest email
            if (!users.ContainsKey(email))
            {
                throw new Exception("User not found.");
            }

            // Returneaza rolul utilizatorului
            return users[email].Role;
        }

        // Clasa de baza pentru utilizatori
        public abstract class User
        {
            public string Name { get; }
            public string Email { get; }
            public string Password { get; }
            public string Role { get; }

            public User(string name, string email, string password, string role)
            {
                Name = name;
                Email = email;
                Password = password;
                Role = role;
            }
        }

        // Clasa pentru administratorii de organizatie
        public class OrganizationAdmin : User
        {
            public string OrganizationName { get; }
            public string HeadquarterAddress { get; }

            public OrganizationAdmin(string name, string email, string password, string organizationName, string headquarterAddress)
                : base(name, email, password, "OrganizationAdmin")
            {
                OrganizationName = organizationName;
                HeadquarterAddress = headquarterAddress;
            }
        }

        // Clasa pentru angajati
        public class Employee : User
        {
            public Employee(string name, string email, string password)
                : base(name, email, password, "Employee")
            {
            }
        }
    }
}
