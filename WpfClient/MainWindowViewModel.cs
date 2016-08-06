using ClientProxy;
using DataContracts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ClientProxy.DataContracts;

namespace WpfClient
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        EmployeeClient proxyClient;
        public MainWindowViewModel()
        {
            proxyClient = new EmployeeClient("tcpEP");
        }
        public ObservableCollection<string> GetEmployee
        {
            get
            {
                // EmployeeClient proxyClient = new EmployeeClient("tcpEP");

                //This is something works without settings in config file
                //Binding b = new NetTcpBinding();
                //EndpointAddress a = new EndpointAddress("net.tcp:\\localhost:8990\\EmployeeService");
                //EmployeeClient proxyClient = new EmployeeClient(b, a);

                IEnumerable<Employee> empList = proxyClient.GetEmployeeList();
                if (empList == null)
                    return null;
                ObservableCollection<string> temp = new ObservableCollection<string>();
                foreach(var emp in empList)
                {
                    temp.Add(emp.EmpName);
                }

               // proxyClient.Close();
                return temp;
            }
        }

        string empName;
        public string EmpName
        {
            get
            {
                return empName;
            }
            set
            {
                empName = value;
                PropertyChanged(this, new PropertyChangedEventArgs("EmpName"));
            }
        }

        ICommand _refreshList;
        public ICommand RefreshListCommand
        {
            get
            {
                _refreshList = new MyCommand(RefreshListCommandHandler);
                return _refreshList;
            }
        }

        void RefreshListCommandHandler(object param)
        {
            PropertyChanged(this, new PropertyChangedEventArgs("GetEmployee"));
        }

        ICommand _AddEmployee;
        public ICommand AddEmployeeCommand
        {
            get
            {
                _AddEmployee = new MyCommand(AddEmployeeCommandHandler);
                return _AddEmployee;
            }
        }

        void AddEmployeeCommandHandler(object param)
        {
            Employee emp = new Employee();
            emp.EmpName = EmpName;
           // EmployeeClient proxyClient = new EmployeeClient("httpEP");
            proxyClient.AddEmployee(emp);
           // proxyClient.Close();
        }


        /////Logger Service


        public ObservableCollection<string> LoggerGetEmployee
        {
            get
            {
                //using not custom proxy but channel factory ; wrapper around my proxy

                ChannelFactory<ILoggerService> factory = new ChannelFactory<ILoggerService>("tcpEP");
                ILoggerService channel = factory.CreateChannel();
                IList<string> namelist = channel.getNameList();
               

               
                ObservableCollection<string> temp = new ObservableCollection<string>();
                foreach (var emp in namelist)
                {
                    temp.Add(emp);
                }

                factory.Close();
                return temp;
            }
        }

        string loggerempName;
        public string LoggerEmpName
        {
            get
            {
                return loggerempName;
            }
            set
            {
                loggerempName = value;
                PropertyChanged(this, new PropertyChangedEventArgs("LoggerEmpName"));
            }
        }

        ICommand _loggerrefreshList;
        public ICommand LoggerRefreshListCommand
        {
            get
            {
                _loggerrefreshList = new MyCommand(LoggerRefreshListCommandHandler);
                return _loggerrefreshList;
            }
        }

        void LoggerRefreshListCommandHandler(object param)
        {
            PropertyChanged(this, new PropertyChangedEventArgs("LoggerGetEmployee"));
        }

        ICommand _loggerAddEmployee;
        public ICommand LoggerAddEmployeeCommand
        {
            get
            {
                _loggerAddEmployee = new MyCommand(LoggerAddEmployeeCommandHandler);
                return _loggerAddEmployee;
            }
        }

        void LoggerAddEmployeeCommandHandler(object param)
        {
            ChannelFactory<ILoggerService> factory = new ChannelFactory<ILoggerService>("tcpEP");
            ILoggerService channel = factory.CreateChannel();

            channel.pName(loggerempName);

            factory.Close();            
        }
    }
}
