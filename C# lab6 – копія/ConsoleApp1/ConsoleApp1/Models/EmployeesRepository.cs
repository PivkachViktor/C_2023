using System;
using System.Collections.Generic;
//using System.IdentityModel.Protocols.WSTrust;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace ConsoleApp1.Models
{
    internal class EmployeesRepository : IRepository<Employees>
    {


        protected SqlConnection _connection;
        public EmployeesRepository(SqlConnection connection)
        {
            _connection = connection;
        }

        //a) простий запит на вибірку
        public List<Employees> GetAllEmployees()
        {
            var employees = new List<Employees>();
            string query = "SELECT * FROM Employees";

            using (SqlCommand command = new SqlCommand(query, _connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Employees employee = new Employees()
                        {
                            EmployeeID = Convert.ToInt32(reader["EmployeeID"]),
                            LastName = Convert.ToString(reader["LastName"]),
                            RoomNumber = Convert.ToInt32(reader["RoomNumber"]),
                            Department = Convert.ToString(reader["Department"]),
                            Salary = Convert.ToInt32(reader["Salary"]),
                            // Додайте інші поля, які потрібно отримати
                        };
                        employees.Add(employee);
                    }
                }
            }
            return employees;
        }

        // b) Вибірка працівників, прізвища яких починаються на певну літеру
        public List<Employees> GetEmployeesWithLastNameStartingWith(string startingLetter)
        {
            var employees = new List<Employees>();
            string query = $"SELECT * FROM Employees WHERE LastName LIKE '{startingLetter}%'";

            using (SqlCommand command = new SqlCommand(query, _connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Employees employee = new Employees()
                        {
                            EmployeeID = Convert.ToInt32(reader["EmployeeID"]),
                            LastName = Convert.ToString(reader["LastName"]),
                            RoomNumber = Convert.ToInt32(reader["RoomNumber"]),
                            Department = Convert.ToString(reader["Department"]),
                            // Додайте інші поля, які потрібно отримати
                        };
                        employees.Add(employee);
                    }
                }
            }
            return employees;
        }

        // c) вибрати всіх співробітників з відділу IT, які мають кімнати у діапазоні від 101 до 105 або прізвище, що починається на "S"
        public List<Employees> GetEmployeesFromITWithRoomInRangeOrLastNameStartingWithS()
        {
            var employees = new List<Employees>();
            string query = "SELECT * FROM Employees WHERE Department = 'IT' AND (RoomNumber BETWEEN 101 AND 110 OR LastName LIKE 'S%')";

            using (SqlCommand command = new SqlCommand(query, _connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Employees employee = new Employees()
                        {
                            EmployeeID = Convert.ToInt32(reader["EmployeeID"]),
                            LastName = Convert.ToString(reader["LastName"]),
                            RoomNumber = Convert.ToInt32(reader["RoomNumber"]),
                            Department = Convert.ToString(reader["Department"])
                            // Add other fields needed
                        };
                        employees.Add(employee);
                    }
                }
            }
            return employees;
        }

        // d) знайти унікальні комбінації стовпців Department та RoomNumber
        public List<string> GetUniqueDepartmentRoomCombinations()
        {
            var combinations = new List<string>();
            string query = "SELECT DISTINCT Department, RoomNumber FROM Employees";

            using (SqlCommand command = new SqlCommand(query, _connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string department = Convert.ToString(reader["Department"]);
                        int roomNumber = Convert.ToInt32(reader["RoomNumber"]);
                        combinations.Add($"{department} - {roomNumber}");
                    }
                }
            }
            return combinations;
        }

        // Метод для отримання середньої зарплати співробітників
        public decimal GetAverageSalary()
        {
            decimal averageSalary = 0;
            string query = "SELECT AVG(Salary) AS AverageSalary FROM Employees";

            using (SqlCommand command = new SqlCommand(query, _connection))
            {
                averageSalary = Convert.ToDecimal(command.ExecuteScalar());
            }

            return averageSalary;
        }

        // Метод для отримання кількості співробітників у кожному відділі
        public Dictionary<string, int> GetEmployeesCountByDepartment()
        {
            var employeesCountByDepartment = new Dictionary<string, int>();
            string query = "SELECT Department, COUNT(*) AS EmployeeCount FROM Employees GROUP BY Department";

            using (SqlCommand command = new SqlCommand(query, _connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string department = Convert.ToString(reader["Department"]);
                        int count = Convert.ToInt32(reader["EmployeeCount"]);
                        employeesCountByDepartment.Add(department, count);
                    }
                }
            }

            return employeesCountByDepartment;
        }

        // Метод для сортування зарплат за зростанням
        public List<Employees> GetEmployeesSortedBySalaryAscending()
        {
            var employees = new List<Employees>();
            string query = "SELECT * FROM Employees ORDER BY Salary ASC";

            using (SqlCommand command = new SqlCommand(query, _connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Employees employee = new Employees()
                        {
                            EmployeeID = Convert.ToInt32(reader["EmployeeID"]),
                            LastName = Convert.ToString(reader["LastName"]),
                            RoomNumber = Convert.ToInt32(reader["RoomNumber"]),
                            Department = Convert.ToString(reader["Department"]),
                            Salary = Convert.ToInt32(reader["Salary"]),
                            // Додайте інші поля, які потрібно отримати
                        };
                        employees.Add(employee);
                    }
                }
            }

            return employees;
        }

        // Метод для зміни зарплати для співробітників відділу "IT"
        public void UpdateSalaryForITDepartment(decimal newSalary)
        {
            string query = $"UPDATE Employees SET Salary = {newSalary} WHERE Department = 'IT'";

            using (SqlCommand command = new SqlCommand(query, _connection))
            {
                command.ExecuteNonQuery();
            }
        }

    }
}
