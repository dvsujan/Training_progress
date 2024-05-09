using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RequestTrackerModelLibrary; 

namespace RequestTrackerBLLibrary
{
    public interface IRequestBl
    {
        public Task<ICollection<Request>> GetAllEmployeeRequestsById(int EmployeeId);
        public Task<Request> GetRequestById(int RequestId);
    }
}
