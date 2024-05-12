using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public interface  IAdminService
    {
        public Task<ICollection<Request>> GetAllRequests();
        public Task<ICollection<RequestSolution>> GetAllSolutions();
        public Task<SolutionFeedback> GiveFeedback(SolutionFeedback feedback);
        public Task<RequestSolution> ProvideSolution(RequestSolution solution);
        public Task<Request> MarkRequestAsClosed(int RequestId, int EmployeeId);
        public Task<ICollection<SolutionFeedback>> ViewFeedbacks(int AdminId);
    }
}
