using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WindowAppHost.DataContracts;

namespace WindowAppHost
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    class LoggerService : ILoggerService
    {
        IList<string> nameList;
        IList<int> ageList;
        public LoggerService()
        {
            nameList = new List<string>() {"rey","riy" };
            ageList = new List<int>() { 19, 20 };
        }
        public void printAge(int age)
        {
            ageList.Add(age);
        }

        public IList<int> getAgeList()
        {
            return ageList;
        }
        public IList<string> getNameList()
        {
            return nameList;
        }

        public void printName(string strName)
        {
            nameList.Add(strName);
        }

        
    }
}
