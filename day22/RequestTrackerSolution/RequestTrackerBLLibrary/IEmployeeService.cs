using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public interface IEmployeeService
    {
        public Task<Request> RaiseRequest(Request request);
        public Task<Request> ViewRequestStatus(int RequestId, int EmployeeId);
        public Task<RequestSolution> ViewSolution(int employeeId, int requestId);
        public Task<SolutionFeedback> GiveFeedback(int solutionid , SolutionFeedback feedback);
    }
}
