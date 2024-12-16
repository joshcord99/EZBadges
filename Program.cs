using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Spectre.Console;

namespace BadgeMaker
{
    class Program
    {
        static async Task Main(string[] args)
        {
            while (true)
            {
                // Display a menu and get the user's choice
                var choice = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("What [green]function[/] would you like to run?")
                        .AddChoices(new[] { "Fetch employee from an API", "Input new employee", "Exit" }));

                switch (choice)
                {
                    case "Fetch employee from an API":
                        await APICall();
                        break;

                    case "Input new employee":
                        await ManualInput();
                        break;

                    case "Exit":
                        AnsiConsole.MarkupLine("[blue]Goodbye![/]");
                        return;

                    default:
                        AnsiConsole.MarkupLine("[red]Invalid option![/]");
                        break;
                }
            }
        }

        static List<Employee> InputEmployees()
        {
            List<Employee> employees = new List<Employee>();

            while (true)
            {
                Console.Write("Enter first name (leave empty to exit): ");
                string firstName = Console.ReadLine() ?? "";

                if (string.IsNullOrWhiteSpace(firstName))
                {
                    break;
                }

                Console.Write("Enter last name: ");
                string lastName = Console.ReadLine() ?? "";

                Console.Write("Enter ID: ");
                if (!int.TryParse(Console.ReadLine(), out int id))
                {
                    Console.WriteLine("Invalid ID. Please enter a valid number.");
                    continue;
                }

                Console.Write("Enter Photo URL: ");
                string photoUrl = Console.ReadLine() ?? "";

                Employee currentEmployee = new Employee(firstName, lastName, id, photoUrl);
                employees.Add(currentEmployee);
            }

            return employees;
        }

        static void PrintEmployees(List<Employee> employees)
        {
            foreach (var employee in employees)
            {
                string template = "{0,-10}\t{1,-20}\t{2}";
                Console.WriteLine(String.Format(template, employee.GetId(), employee.GetFullName(), employee.GetPhotoUrl()));
            }
        }

        static async Task APICall()
        {
            List<Employee> employees = await EmployeeFetcher.GetFromApi();
            Util.PrintEmployees(employees);
            Util.MakeCSV(employees);
            await Util.MakeBadges(employees);
        }

        static async Task ManualInput()
        {
            List<Employee> employees = InputEmployees();
            Util.PrintEmployees(employees);
            Util.MakeCSV(employees);
            await Util.MakeBadges(employees);
        }
    }
}