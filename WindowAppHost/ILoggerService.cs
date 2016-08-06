using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WindowAppHost.DataContracts
{
    [ServiceContract(Namespace = "http:\\www.vishalbhardwaj\\LoggerService")]
    interface ILoggerService
    {
        [OperationContract]
        void printName(string strName);

        [OperationContract]
        void printAge(int age);

        [OperationContract]
        IList<int> getAgeList();

        [OperationContract]
        IList<string> getNameList();
    }


}
