//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Runtime.Serialization;
//using System.ServiceModel;

//using System.Text;

//namespace HostIndependentService
//{
//    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
//    [ServiceContract]
//    public interface IEmployeeService
//    {        
//        [OperationContract]        
//        Employee GetEmployee(int ID);
        
//        [OperationContract]        
//        int GetEmployeeSalary(int ID);
                
//        [OperationContract]        
//        IEnumerable<Employee> GetEmployeeList();

//        [OperationContract]        
//        void AddEmployee(Employee Emp);
       
//        [OperationContract]
//        void DeleteEmployee(string empId);


//    }


//    // Use a data contract as illustrated in the sample below to add composite types to service operations.
//    [DataContract]
//    public class Employee
//    {
//        [DataMember]
//        public int ID
//        {
//            get;
//            set;
//        }

//        [DataMember]
//        public string EmpName
//        {
//            get;
//            set;
//        }

//        [DataMember]
//        public int Salary
//        {
//            get;
//            set;
//        }

//    }
//}
