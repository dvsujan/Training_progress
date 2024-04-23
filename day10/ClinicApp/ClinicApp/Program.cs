using ClinicDALLibrary;
using ClinicModelLibrary; 
namespace ClinicApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Doctor doc = new Doctor("doc1",DateTime.Now,"cardio","heart");
            DoctorReposotory repo = new DoctorReposotory();
            var result = repo.Insert(doc);
            Console.WriteLine(result.Id);
        }
    }
}
