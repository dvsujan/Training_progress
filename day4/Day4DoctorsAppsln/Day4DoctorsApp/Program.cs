namespace Day4DoctorsApp
{
    internal class Program
    {
        /// <summary>
        /// prints the doctors data by the given specilization data 
        /// </summary>
        /// <param name="specilization">Doctor specilization</param>
        /// <param name="doctors">doctors array</param>
        static void printDoctorWithSpecalization(string specilization, Doctor[] doctors)
        {
            Console.WriteLine("Results Found are: ");
            for (int i = 0; i<doctors.Length; i++)
            {
                if (doctors[i] == null)
                {
                    return; 
                }
                if (doctors[i].Speciality == specilization) {
                    doctors[i].printDoctorData();
                }
            }

        }
        /// <summary>
        /// function to return random id for the doctor 
        /// </summary>
        /// <returns>Random Integer between 100 and 1000</returns>
        static int RandomIdGenerator()
        {
            Random r = new Random();
            return r.Next(100, 1000);
        }
        /// <summary>
        /// geths the
        /// </summary>
        /// <returns></returns>
        static Doctor getDoctorData()
        {
            int age;
            int id = RandomIdGenerator();
            Console.WriteLine("Enter Doctor Name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Doctor Age");
            while (!int.TryParse(Console.ReadLine(), out age))
            {
                Console.WriteLine("Enter The Age of the Doctor");
            }
            Console.WriteLine("Enter Doctor Qualificatoin:");
            string qualification = Console.ReadLine();
            Console.WriteLine("Enter Doctor Speciality:");
            string speciality = Console.ReadLine();
            Doctor doc = new Doctor(id, name, age, qualification, speciality);
            return doc;
        }
        /// <summary>
        /// Main Funcation for the program
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int n;
            Console.WriteLine("enter No of Doctors");
            while (!int.TryParse(Console.ReadLine(), out n))
            {
                Console.WriteLine("enter No of Doctors");
            }
            Doctor[] doctors = new Doctor[n];
            int i = 0;
            while (true)
            {
                Console.WriteLine("Menu:\npress 1 to Create Doctor\npress 2 to print all doctors data\n press 3 to find doctors based on specalization\n press 4 to exit");
                int input;
                while (!int.TryParse(Console.ReadLine(), out input))
                {
                    Console.WriteLine("Enter Vaid Input");
                }
                if (input == 4)
                {
                    break;
                }
                else if (input == 1)
                {
                    if(i > n)
                    {
                        Console.WriteLine("max no of doctors reached");
                    }
                    else { 
                        Doctor doc = getDoctorData();
                        doctors[i] = doc;
                        i++; 
                    }
                    
                }
                else if (input == 2)
                {
                    for (int ii = 0; i < doctors.Length; i++)
                    {
                        doctors[ii].printDoctorData();
                    }
                }
                else if (input == 3)
                {
                    Console.WriteLine("Enter Doctor Specalization");
                    string specalization = Console.ReadLine();
                    if (specalization == null)
                    {
                        Console.WriteLine("not a valid string");
                    }
                    printDoctorWithSpecalization(specalization, doctors); 
                }
                else
                {
                    Console.WriteLine("Enter Valid Input");
                }
            }
            Console.WriteLine("thank you for using");
            Console.ReadLine();
        }
    }
}
