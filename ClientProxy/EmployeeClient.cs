using DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace ClientProxy
{
   public class EmployeeClient : ClientBase<IEmployeeService>, IEmployeeService
    {
        public EmployeeClient(string EndPoint):base(EndPoint)
        {

        }
        public EmployeeClient(Binding b, EndpointAddress addr):base(b,addr)
        {

        }
        public void AddEmployee(Employee Emp)
        {
            Channel.AddEmployee(Emp);
        }

        public void DeleteEmployee(string empId)
        {
            Channel.DeleteEmployee(empId);
        }

        public Employee GetEmployee(int ID)
        {
            return Channel.GetEmployee(ID);
        }

        public IEnumerable<Employee> GetEmployeeList()
        {
            return Channel.GetEmployeeList();
        }

        public int GetEmployeeSalary(int ID)
        {
            return Channel.GetEmployeeSalary(ID);
        }
    }
}
