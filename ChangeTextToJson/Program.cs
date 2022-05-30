using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;


namespace ChangeTextToJson
{
    class Program
    {
        
        static void Main(string[] args)
        {
            string filePath = @"C:\\Users\\arcan\\OneDrive\\Desktop\\Vscode BaiTap\\ChangeTextToJson\\ChangeTextToJson\\Test.txt";
            string _path = @"C:\\Users\\arcan\\OneDrive\\Desktop\\Vscode BaiTap\\ChangeTextToJson\\ChangeTextToJson\\Employee.json";
            List<Employee> employees = new List<Employee>();  
            List<string> lines = File.ReadAllLines(filePath).ToList();
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                Employee employee = new Employee();
                employee.Name = parts[0];
                employee.Age = int.Parse(parts[1]);
                employee.Job = parts[2];
                employees.Add(employee);
                
            }
            
            var jsonWrite = JsonConvert.SerializeObject(employees, Formatting.Indented);
            File.WriteAllText(_path, jsonWrite);
                
                
        }
    }
}