using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karthick_VaccinationDriveApplication
{
    class Program
    {
        static List<BeneficiaryDeatials> PeopleList = new List<BeneficiaryDeatials>();

        static void Main(string[] args)
        {     //Adds default object in the list
            BeneficiaryDeatials person1 = new BeneficiaryDeatials("karthick", 9488847139, "tindivanam", 12, 1);
            BeneficiaryDeatials person2 = new BeneficiaryDeatials("Prasath", 9443292299, "tindivanam", 12, 1);
            PeopleList.Add(person1);
            PeopleList.Add(person2);

            Console.WriteLine("Welcome to Vaccination" );
            Console.WriteLine();

            int goIn;

            bool value;
            do
            {
                
                Console.WriteLine("");
                Console.WriteLine("Please select the following options");
                Console.WriteLine("Press 1-New Registration \n Press 2-Vaccination \n Press 3-Exit ");
                Console.WriteLine();
                value = int.TryParse(Console.ReadLine(), out goIn);
                if (value)
                {
                    switch (goIn)
                    {
                        case 1:
                            PersonDetial();
                            break;
                        case 2:
                            VaccinationDetials();
                            break;
                        case 3:
                            Console.WriteLine("Thank You");
                            break;
                        default:
                            Console.WriteLine("Invalid input");
                            break;


                    }
                }
            } while (goIn != 3);

        }
        public static void PersonDetial()  //getting the user info
        {
            Console.WriteLine("");
            Console.WriteLine("Enter your name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter your your Age:");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("Choose your Gender:\n1.Male\n2.Female\n3.Transgender");
            int gender = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter your Phone number:");
            double mobile = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter your Address:");
            string address = Console.ReadLine();
            BeneficiaryDeatials person = new BeneficiaryDeatials(name, mobile, address, age, gender);

            Console.WriteLine("{0} your Regestration_Id is {1}", name, person.RegistrationID);
            PeopleList.Add(person);
        }
        //Vaccination detials
        public static void VaccinationDetials() //Vaccination Detials creation for registered user
        {
            bool flag = true;


            Console.WriteLine("Enter your Registration Id");
            int regId = int.Parse(Console.ReadLine());
            BeneficiaryDeatials person = null;
            foreach (var i in PeopleList)
            {

                if (i.RegistrationID == regId)
                {
                    do
                    {
                        

                        foreach (var men in PeopleList) //fectching detials of beneficiary registered id from the peopleList
                        {
                            if (regId == men.RegistrationID)
                            {
                                person = men;
                            }
                        }
                        Console.WriteLine("Enter the Corresponding Action");
                        Console.WriteLine("Press 1-Take Vaccation \n Press 2-Vaccination History \n Press 3-Vaccine DueDate press 4-Home Menu \n");

                        int option = int.Parse(Console.ReadLine());
                        switch (option)
                        {
                            case 1:
                                VaccinatingPeople(person);
                                 
                                break;
                                

                            case 2:
                                VaccinationHistory( person);

                                break;
                            case 3:

                                Console.WriteLine(person.DueDate());
                               

                                break;
                            case 4:
                                flag = false;
                                break;
                            default:
                                Console.WriteLine("invalid input");
                                break;


                        }
                    } while (flag);
                }
            }

        }

        public enum Option
        {
            YES = 1,
            NO
        }
        private static void ShowListOfBeneficiaries() //show beneficiary deatials
        {
            foreach (BeneficiaryDeatials beneficiary in PeopleList)
            {
                Console.WriteLine($"REGISTRATION ID: {beneficiary.RegistrationID}  BENEFICIARY NAME:{beneficiary.Name}");
            }
        }
        private static void VaccinationHistory(BeneficiaryDeatials person) // vaccination history of beneficiary
        {
            



            foreach (VaccineDetails detail in person.VaccinatedDetails)//traverse through vaccinated details list
            {
                Console.WriteLine($"Vaccine: {detail.Vaccine}  Dosage:{detail.Dosage} dose  Date:{detail.VaccinatedDate.ToString("dd/MM/yyyy")}");
            }



        }
        public static void VaccinatingPeople(BeneficiaryDeatials person) // checking for vaccinated beneficiary
        {    
            
            if (person.VaccinatedDetails.Count == 0) //checks whether beneficiary has taken vaccine
            {


                Console.WriteLine("Slelct the type of Vaccine");
                Console.WriteLine("Press-1 Covaxin\n ,Press-2 Covishield,\n  Press 3-Sputnik,");
                int type = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Date in dd/mm/yyyy");
                string enteredDate = Console.ReadLine();
                string[] splitDate = enteredDate.Split('/');
                DateTime date = new DateTime(int.Parse(splitDate[2]), int.Parse(splitDate[1]), int.Parse(splitDate[0]));
                int gh = 1;
                VaccineDetails temp = new VaccineDetails(type, date, gh);
                person.VaccinatedDetails.Add(temp);
                Console.WriteLine("{0}your next vaccine date is {1}", person.Name, temp.VaccinatedDate.AddDays(30).ToString("dd/MM/yyyy"));

                Console.WriteLine("Thankyou");
                Console.WriteLine();

            }

            else if (person.VaccinatedDetails.Count == 1) //checks for the beneficiary has taken first dose
            {

                Console.WriteLine("Enter the type of Vaccine");
                Console.WriteLine("Press-1 Covaxin\n ,Press-2 Covishield,\n  Press 3-Sputnik,");
                int type = int.Parse(Console.ReadLine());


                if ((VaccineType)type == person.VaccinatedDetails[0].Vaccine) // check for  the 2st Dose taken
                {
                    Console.WriteLine("Enter the Date time ");
                    String enterDate = Console.ReadLine();
                    string[] splitDate = enterDate.Split('/');
                    DateTime date = new DateTime(int.Parse(splitDate[2]), int.Parse(splitDate[1]), int.Parse(splitDate[0]));
                    int dose = 2;
                    Console.WriteLine("{0} You have taken your {1} in {3}", person.Name, type, date);
                    VaccineDetails temp = new VaccineDetails(type, date, dose);
                    person.VaccinatedDetails.Add(temp);
                    Console.WriteLine("{0}your next vaccine date is {1}",person.Name, temp.VaccinatedDate.AddDays(30).ToString("dd/MM/yyyy"));
                    Console.WriteLine();

                }
                else // if the choosen dose is different
                {
                    Console.WriteLine($"You have selected different vaccine. Your First vaccine is {person.VaccinatedDetails[0].Vaccine}");
                }

            }
        }
    }
}


