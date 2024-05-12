using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RequestTrackerBLLibrary;
using RequestTrackerModelLibrary;
using System.Runtime.InteropServices;
using System.Threading.Channels;
using System.Transactions;

namespace RequestTrackerFEAPP
{
    internal class Program
    {
        static Employee loggedInEmployee = null ; 
        static RequestTrackerContext context = new RequestTrackerContext();
        static IEmployeeService employeeService = new EmployeeService(context);
        static IAdminService adminService = new AdminService(context);
        async Task AdminMenu()
        {
            while (true)
            {
                int choice;
                await Console.Out.WriteLineAsync("Admin Menu:");
                await Console.Out.WriteLineAsync("1. Raise Request");
                await Console.Out.WriteLineAsync("2. View Request Status(All Status)");
                await Console.Out.WriteLineAsync("3. View Solutions(All Solutions)");
                await Console.Out.WriteLineAsync("4. Give Feedback(Only for request raised by them)");
                await Console.Out.WriteLineAsync("5. Provide Solution");
                await Console.Out.WriteLineAsync("6. Mark Request as Closed");
                await Console.Out.WriteLineAsync("7. View Feedbacks(Only feedbacks given to you)");
                await Console.Out.WriteLineAsync("8. Exit");

                getIntFromConsole(out choice);
                switch (choice)
                {
                    case 1:
                        try
                        {
                            Request req = new Request();
                            await Console.Out.WriteLineAsync("Enter Your Request");
                            req.RequestMessage = Console.ReadLine();
                            req.RequestRaisedBy = loggedInEmployee.Id;
                            req.RequestStatus = "Open";
                            Request Raisedrequest = await employeeService.RaiseRequest(req);
                            await Console.Out.WriteLineAsync("Request Raised Successfully");
                            Console.Out.WriteLineAsync(Raisedrequest.ToString());
                        }
                        catch (Exception e)
                        {
                            await Console.Out.WriteLineAsync(e.Message);
                        }
                        break;
                    case 2:
                        try
                        {
                            ICollection<Request> requests = await adminService.GetAllRequests();
                            foreach (var request in requests)
                            {
                                await Console.Out.WriteLineAsync(request.ToString());
                            }
                        }
                        catch (Exception e)
                        {
                            await Console.Out.WriteLineAsync(e.Message);
                        }
                        break;
                    case 3:
                        try
                        {
                            ICollection<RequestSolution> solutions = await adminService.GetAllSolutions();
                            foreach (var s in solutions)
                            {
                                await Console.Out.WriteLineAsync(s.ToString());
                            }
                        }
                        catch(Exception e)
                        {
                            await Console.Out.WriteLineAsync(e.Message);
                        }
                        break;
                    case 4:
                        try
                        {
                            await Console.Out.WriteLineAsync("Enter Solution Id to Give Feedback");
                            int solutionId;
                            getIntFromConsole(out solutionId);
                            SolutionFeedback feedback = new SolutionFeedback();
                            await Console.Out.WriteLineAsync("Enter Your Feedback");
                            string fbs = Console.ReadLine();
                            float rating;
                            await Console.Out.WriteLineAsync("Enter Rating");
                            while (!float.TryParse(Console.ReadLine(), out rating))
                            {
                                await Console.Out.WriteLineAsync("Invalid Input");
                            }
                            feedback.Rating = rating;
                            feedback.Remarks = fbs;
                            feedback.FeedbackBy = loggedInEmployee.Id;
                            feedback.FeedbackDate = DateTime.Now;
                            SolutionFeedback givenFeedback = await adminService.GiveFeedback(feedback);
                            await Console.Out.WriteLineAsync("Feedback Given Successfully");
                            Console.Out.WriteLineAsync(givenFeedback.ToString());

                        }
                        catch (Exception e)
                        {
                            await Console.Out.WriteLineAsync(e.Message);
                        }
                        break;
                    case 5:
                        RequestSolution solution = new RequestSolution();
                        await Console.Out.WriteLineAsync("Enter Request Id");
                        int requestId; 
                        getIntFromConsole(out requestId);
                        await Console.Out.WriteLineAsync("Enter Solution");
                        solution.SolutionDescription = Console.ReadLine();
                        solution.RequestId = requestId;
                        solution.SolvedBy = loggedInEmployee.Id;
                        RequestSolution providedSolution = await adminService.ProvideSolution(solution);
                        await Console.Out.WriteLineAsync("Solution Added Successfully");
                        Console.Out.WriteLineAsync(providedSolution.ToString());
                        break;
                    case 6:
                        try
                        {
                            await Console.Out.WriteLineAsync("Enter Request Id to Mark as Closed");
                            int reqId;
                            getIntFromConsole(out reqId);
                            Request request = await adminService.MarkRequestAsClosed(reqId, loggedInEmployee.Id);
                            await Console.Out.WriteLineAsync($"Request Id: {reqId} Marked as Closed");
                        }
                        catch (Exception e)
                        {
                            await Console.Out.WriteLineAsync(e.Message);
                        }
                    break;
                    case 7:
                        try
                        {
                            ICollection<SolutionFeedback> feedbacks = await adminService.ViewFeedbacks(loggedInEmployee.Id);
                            foreach (var feedback in feedbacks)
                            {
                                await Console.Out.WriteLineAsync(feedback.ToString());
                            }
                        }
                        catch (Exception e)
                        {
                            await Console.Out.WriteLineAsync(e.Message);
                        }
                        break; 
                    case 8:
                            return;
                        break;
                    default:
                        await Console.Out.WriteLineAsync("Invalid Choice");
                        break;
                }
            }
        }

        async Task EmployeeMenu()
        {
            await Console.Out.WriteLineAsync("User Menu:");
            await Console.Out.WriteLineAsync("1. Raise Request");
            await Console.Out.WriteLineAsync("2. View Request Status");
            await Console.Out.WriteLineAsync("3. View Solutions");
            await Console.Out.WriteLineAsync("4. Give FeedBack");
            await Console.Out.WriteLineAsync("5. Exit");
            await Console.Out.WriteLineAsync("Enter a Choice");
            int choice;
            getIntFromConsole(out choice);
            switch (choice)
            {
                case 1:
                    try
                    {
                        Request req = new Request();
                        await Console.Out.WriteLineAsync("Enter Your Request");
                        req.RequestMessage = Console.ReadLine();
                        req.RequestRaisedBy = loggedInEmployee.Id;
                        req.RequestStatus = "Open";
                        Request Raisedrequest = await employeeService.RaiseRequest(req);
                        await Console.Out.WriteLineAsync("Request Raised Successfully");
                        Console.Out.WriteLineAsync(Raisedrequest.ToString());
                    }
                    catch (Exception e)
                    {
                        await Console.Out.WriteLineAsync(e.Message);
                    }
                     
                    break;
                case 2:
                    try
                    {
                        await Console.Out.WriteLineAsync("Enter Request Id to View Status");
                        int requestId;
                        getIntFromConsole(out requestId);
                        Request request = await employeeService.ViewRequestStatus(requestId, loggedInEmployee.Id);
                        await Console.Out.WriteLineAsync($"RequestId:${requestId} status:${request.RequestStatus}");
                    }
                    catch (Exception e)
                    {
                        await Console.Out.WriteLineAsync(e.Message);
                    }
                    break;
                case 3:
                    try
                    {
                        await Console.Out.WriteLineAsync("Enter Request Id to View Solution");
                        int requestId;
                        getIntFromConsole(out requestId);
                        RequestSolution solution = await employeeService.ViewSolution(loggedInEmployee.Id, requestId);
                        await Console.Out.WriteLineAsync($"RequestId:${requestId} Solution:${solution}");
                    }
                    catch (Exception e)
                    {
                        await Console.Out.WriteLineAsync(e.Message);
                    }
                    break;
                case 4:
                    try
                    {
                        await Console.Out.WriteLineAsync("Enter Solution Id to Give Feedback");
                        int solutionId;
                        getIntFromConsole(out solutionId);
                        SolutionFeedback feedback = new SolutionFeedback();
                        await Console.Out.WriteLineAsync("Enter Your Feedback");
                        string fbs = Console.ReadLine();
                        float rating;
                        await Console.Out.WriteLineAsync("Enter Rating");
                        while (!float.TryParse(Console.ReadLine(), out rating))
                        {
                            await Console.Out.WriteLineAsync("Invalid Input");
                        }
                        feedback.Rating = rating;
                        feedback.Remarks = fbs;
                        feedback.FeedbackBy = loggedInEmployee.Id;
                        feedback.FeedbackDate = DateTime.Now;
                        SolutionFeedback givenFeedback = await employeeService.GiveFeedback(solutionId, feedback);
                        await Console.Out.WriteLineAsync("Feedback Given Successfully");
                        Console.Out.WriteLineAsync(givenFeedback.ToString());
                    }
                    catch (Exception e)
                    {
                        await Console.Out.WriteLineAsync(e.Message);
                    }

                    break;
                case 5:
                    return; 
                    break;
                default:
                    await Console.Out.WriteLineAsync("Invalid Choice");
                    break;
            }
        }
        static void getIntFromConsole(out int input)
        {
            input = 0;
            while (!int.TryParse(Console.ReadLine(), out input))
            {
                Console.WriteLine("Invalid Input");
            }
        }

        static async Task Main(string[] args)
        {
            EmployeeLoginBL employeeLoginBL = new EmployeeLoginBL(context);
            Program program = new Program();
            int userId;
            string password;
            await Console.Out.WriteLineAsync("Login");
            await Console.Out.WriteLineAsync("Enter UserId: ");
            getIntFromConsole(out userId);
            await Console.Out.WriteLineAsync("Enter Password: ");
            password = Console.ReadLine();
            Employee e = new Employee();
            e.Id = userId;
            e.Password = password;
            Employee employee = null;
            while (true)
            {
                try
                {
                    employee = await employeeLoginBL.Login(e);
                }
                catch (Exception ex)
                {
                    await Console.Out.WriteLineAsync(ex.Message);
                }
                if (employee != null)
                {
                    loggedInEmployee = employee;
                    if (employee.Role == "Admin")
                    {
                        await program.AdminMenu();
                    }
                    else
                    {
                        await program.EmployeeMenu();
                    }
                }
            }
        }
    }
}
