using Microsoft.EntityFrameworkCore;
using RequestTrackerDALLibrary;
using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository<int, SolutionFeedback> _solutionFeedbackRepository;
        private readonly IRepository<int, Request> _requestRepository;
        private readonly IRepository<int, RequestSolution> _requestSolutionRepository;
        private readonly IRepository<int, Employee> _employeeRepository;
        private readonly IRepository<int, Employee> _employeeRequestRepoitory; 
        public EmployeeService(RequestTrackerContext _context)
        {
            _solutionFeedbackRepository = new SolutionFeedbackRepository(_context);
            _requestRepository = new RequestRepository(_context);
            _requestSolutionRepository = new RequestSolutionRepository(_context);
            _employeeRepository = new EmployeeRepository(_context);
            _employeeRequestRepoitory = new EmployeeRequestRepository(_context);
        }

        public async Task<SolutionFeedback> GiveFeedback(int solutionId , SolutionFeedback feedback)
        {
            var requestSolution = await _requestSolutionRepository.Get(solutionId);
            if (requestSolution != null)
            {
                feedback.Solution = requestSolution;
                await _solutionFeedbackRepository.Add(feedback);
                return feedback;
            }
            throw new Exception("Solution Id not Found");
        }

        public async Task<Request> RaiseRequest(Request request)
        { 
            var req = await _requestRepository.Add(request);
            if (req != null)
            {
                return req;
            }
            throw new Exception("Error Raising Request");
        }

        public async Task<Request> ViewRequestStatus(int RequestId , int EmployeeId)
        {
            var requests = await _requestRepository.GetAll();
            var request = requests.FirstOrDefault(r => r.RequestNumber == RequestId);
            if (request != null)
            {
                return request;
            }
            throw new Exception("Request not Found");
        }

        public async Task<RequestSolution> ViewSolution(int employeeId, int requestId)
        {
            var solutions = await _requestSolutionRepository.GetAll();
            var request = await _requestRepository.Get(requestId);
            var solution = solutions.FirstOrDefault(s => s.RequestId == requestId);
            if(request == null )
            {
                throw new Exception("RequestId not valid");
            }
            if (solution != null)
            {
                if(request.RequestRaisedBy == employeeId)
                {
                    return solution;
                }
                throw new Exception("You are not authorized to view the Solution");
            }
            throw new Exception("Solution not Found For the Reqest");
        }
    }
}
