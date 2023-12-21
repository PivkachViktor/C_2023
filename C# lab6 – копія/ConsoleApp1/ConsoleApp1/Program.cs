using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;
using Microsoft.Data.SqlClient;
using ConsoleApp1.Models;

namespace lab5 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Варіант 5.Створити таблицю бази даних про співробітників, що мають комп'ютер: прізвище, номер
            //кімнати, назва відділу, дані про комп'ютери.

            //Завдання
            ////1.Використовуючи інструмент SQL Server Object Explorer у Visual Studio створити БД з іменем
            //назва_групи_прізвище_студента.

            ////2.Створити таблицю у базі даних у відповідності до індивідуального варіанту.Наповнити таблицю даними
            //(не менше 20 записів).

            //3.Cтворити наступні види SQL - запитів:
            //a) простий запит на вибірку;
            //b) запит на вибірку з використанням спеціальних функцій: LIKE, IS NULL, IN, BETWEEN;
            //c) запит зі складним критерієм;
            //d) запит з унікальними значеннями;
            //e) запит з використанням обчислювального поля;
            //f) запит з групуванням по заданому полю, використовуючи умову групування;
            //g) запит із сортування по заданому полю в порядку зростання та спадання значень;
            //h) запит з використанням дій по модифікації записів.


            //Лабораторна 6
            //Використовуючи SqlCommand підготувати програмну оболонку для виконання завдань лабораторної роботи 5.
            //Забезпечити користувачу можливість ввести значення параметрів запиту.


            const string CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\MegaNotik\Desktop\C# lab5\ConsoleApp1\ConsoleApp1\Employees1.mdf;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                var rep = new EmployeesRepository(connection);

                while (true)
                {
                Start: Console.WriteLine("Таблиця Співробітники. Введіть яку операцію ви хочете робити з таблицею:");
                    Console.WriteLine("а - вибрати всіх співробітників;");
                    Console.WriteLine("b - вибрати прізвища яких починаються на \"S\".;");
                    Console.WriteLine("с - вибрати всіх співробітників з відділу IT, які мають кімнати у діапазоні від 101 до 105 або прізвище, що починається на \"S\".;");
                    Console.WriteLine("d - знайти унікальні комбінації стовпців Department та RoomNumber;");
                    Console.WriteLine("e - знайти середню зарплату;");
                    Console.WriteLine("f - вивести кількість співробітників в кожному відділі;");
                    Console.WriteLine("g - Сортування зарплат за зростанням;");
                    Console.WriteLine("h - змінити зарплату для всіх співробітників, які належать до відділу \"IT\"");
                    Console.WriteLine(":");
                    string request = Console.ReadLine();
                    List<Employees> employees = new List<Employees>();

                    if (request.ToLower() == "a")
                    {
                        employees = rep.GetAllEmployees();
                    }
                    else if (request.ToLower() == "b")
                    {
                        Console.Write("Введіть літеру, з якої починається прізвище: ");
                        string startingLetter = Console.ReadLine();
                        employees = rep.GetEmployeesWithLastNameStartingWith(startingLetter);
                    }
                    else if (request == "c")
                    {
                        employees = rep.GetEmployeesFromITWithRoomInRangeOrLastNameStartingWithS();

                    }
                    else if (request == "d")
                    {
                        var combinations = rep.GetUniqueDepartmentRoomCombinations();
                        foreach (var combination in combinations)
                        {
                            Console.WriteLine(combination);
                        }
                    }
                    if (request.ToLower() == "e")
                    {
                        decimal averageSalary = rep.GetAverageSalary();
                        Console.WriteLine($"Середня зарплата: {averageSalary}");
                    }
                    else if (request.ToLower() == "f")
                    {
                        Dictionary<string, int> employeesCountByDepartment = rep.GetEmployeesCountByDepartment();
                        foreach (var department in employeesCountByDepartment)
                        {
                            Console.WriteLine($"Відділ: {department.Key}, Кількість співробітників: {department.Value}");
                        }
                    }
                    else if (request.ToLower() == "g")
                    {
                        List<Employees> sortedEmployees = rep.GetEmployeesSortedBySalaryAscending();
                        foreach (var employee in sortedEmployees)
                        {
                            Console.WriteLine($"Employee ID: {employee.EmployeeID}, Last Name: {employee.LastName}, Room Number: {employee.RoomNumber}, Department: {employee.Department}, Salary: {employee.Salary}");
                        }
                    }
                    else if (request.ToLower() == "h")
                    {
                        Console.WriteLine("Введіть нову зарплату для співробітників відділу IT:");
                        decimal newSalary = Convert.ToDecimal(Console.ReadLine());
                        rep.UpdateSalaryForITDepartment(newSalary);
                        Console.WriteLine("Зарплату змінено для всіх співробітників відділу IT.");
                    }
                   
                    foreach (var employee in employees)
                    {
                        Console.WriteLine($"Employee ID: {employee.EmployeeID}, Last Name: {employee.LastName}, Room Number: {employee.RoomNumber}, Department: {employee.Department}, Salary: {employee.Salary}");
                        
                    }

                    Console.ReadLine();
                    goto Start;
                }
            }
        }
    }
}