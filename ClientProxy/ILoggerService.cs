using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ClientProxy.DataContracts
{
    // this is to match contract defined on service side and on client side
    [ServiceContract(Namespace ="http:\\www.vishalbhardwaj\\LoggerService")]
    public interface ILoggerService
    {
        // this is to match operation defined on service side and on client side
        [OperationContract(Name ="printName")]
        void pName(string strName);

        [OperationContract]
        void printAge(int age);

        [OperationContract]
        IList<int> getAgeList();

        [OperationContract]
        IList<string> getNameList();
    }


}
