using RequestTrackerDALLibrary;
using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public class AdminService : IAdminService
    {
        private readonly IRepository<int, SolutionFeedback> _solutionFeedbackRepository;
        private readonly IRepository<int, Request> _requestRepository;
        private readonly IRepository<int, RequestSolution> _requestSolutionRepository;
        private readonly IRepository<int, Employee> _employeeRepository;
        private readonly IRepository<int, Employee> _employeeRequestRepoitory;
        public AdminService(RequestTrackerContext _context)
        {
            _solutionFeedbackRepository = new SolutionFeedbackRepository(_context);
            _requestRepository = new RequestRepository(_context);
            _requestSolutionRepository = new RequestSolutionRepository(_context);
            _employeeRepository = new EmployeeRepository(_context);
            _employeeRequestRepoitory = new EmployeeRequestRepository(_context);
        }

        public async Task<ICollection<Request>> GetAllRequests()
        {
            var reqeusts = await _requestRepository.GetAll();
            if (reqeusts != null)
            {
                return reqeusts;
            }
            throw new Exception("No Requests Found");
        }

        public async Task<ICollection<RequestSolution>> GetAllSolutions()
        {
            var solutions = await _requestSolutionRepository.GetAll();
            if (solutions != null)
            {
                return solutions;
            }
            throw new Exception ("No Solutions Found");

        }

        public async Task<SolutionFeedback> GiveFeedback(SolutionFeedback feedback)
        {
            var solution = await _requestSolutionRepository.Get(feedback.SolutionId);
            if (solution != null)
            {
                feedback.Solution = solution;
                await _solutionFeedbackRepository.Add(feedback);
                return feedback;
            }
            throw new Exception("Solution Id not Found");

        }

        public async Task<Request> MarkRequestAsClosed(int RequestId, int EmployeeId)
        {
            var request = await _requestRepository.Get(RequestId);
            if (request != null)
            {
                request.RequestStatus = "Colsed";
                request.RequestClosedBy = EmployeeId;
                request.ClosedDate = DateTime.Now;
                await _requestRepository.Update(request);
                return request;
            }
            throw new Exception("Request not Found");
        }

        public async Task<RequestSolution> ProvideSolution(RequestSolution solution)
        {
            var request = await _requestRepository.Get(solution.RequestId);
            if (request == null)
            {
                throw new Exception("RequestId not valid");
            }
            var sol = await _requestSolutionRepository.Add(solution);
            if (sol != null)
            {
                return sol;
            }
            throw new Exception("Error Providing Solution");
        }


        public async Task<ICollection<SolutionFeedback>> ViewFeedbacks(int AdminId)
        {
            var requests = await _requestRepository.GetAll();
            var solutions = await _requestSolutionRepository.GetAll();
            var feedbacks = await _solutionFeedbackRepository.GetAll();

            var feedbacksForAdmin = from r in requests
                                    join s in solutions on r.RequestNumber equals s.RequestId
                                    join f in feedbacks on s.SolutionId equals f.SolutionId
                                    where r.RequestClosedBy == AdminId
                                    select f;

            if (feedbacksForAdmin != null)
            {
                return feedbacksForAdmin.ToList();
            }
            throw new Exception("No Feedbacks Found");
        }
    }
}
