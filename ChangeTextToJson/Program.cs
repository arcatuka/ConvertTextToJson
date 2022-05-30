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
            
            string filePath = "Test.txt";
            string JsonPath = "Employee.json";
            List<Employee> Employees = new List<Employee>();
            
            /*
            List<Employee> Employees = new List<Employee>();  
            List<string> lines = File.ReadAllLines(filePath).ToList();
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                Employee employee = new Employee();
                employee.Name = parts[0];
                employee.Age = int.Parse(parts[1]);
                employee.Job = parts[2];
                Employees.Add(employee);
            }
            */
            try
            {
                if (File.Exists(filePath))
                {
                    List<string> lines = File.ReadAllLines(filePath).ToList();
                    foreach (string line in lines)
                    {
                        string[] parts = line.Split(',');
                        Employee employee = new Employee();
                        employee.Name = parts[0];
                        employee.Age = int.Parse(parts[1]);
                        employee.Job = parts[2];
                        Employees.Add(employee);
                    }
                }
                else if (!File.Exists(filePath))
                {
                    using (var WriteText = new StreamWriter(filePath, true))
                    {
                        WriteText.Write("New Text File created");
                        WriteText.Close();
                    }
                }
            }
            catch
            {

            }

            var jsonWrite = JsonConvert.SerializeObject(Employees, Formatting.Indented);
            try
            {
                if(File.Exists(JsonPath))
                {
                    File.WriteAllText(JsonPath, jsonWrite);
                }    
                else if(!File.Exists(JsonPath))
                {
                    using (var WriteJson = new StreamWriter(JsonPath, true))
                    {
                        WriteJson.Write(jsonWrite.ToString());
                        WriteJson.Close();
                    }

                }
            }
            catch { }
        }  
    }
}