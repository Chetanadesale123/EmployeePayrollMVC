using ModelLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepoLayer.Interfaces
{
    public interface IEmployeeRL
    {
        public string AddEmployee(EmployeeModel emp);
        public IEnumerable<EmployeeModel> GetAllEmployees();
        public EmployeeModel GetEmployeeData(int? id);
        public string UpdateEmployee(EmployeeModel emp);
        public string DeleteEmployee(int? id);
    }
}
