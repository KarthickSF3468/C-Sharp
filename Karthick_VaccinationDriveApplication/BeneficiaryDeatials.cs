using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karthick_VaccinationDriveApplication
{
    class BeneficiaryDeatials   //beneficiary detials 
    {
        private static int _autoIncreamentedNumber = 1001;
        public int RegistrationID { get; set; }
        public string Name { get; set; }
        public double Mobile { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public GenderChoice Gender { get; set; }
        public List<VaccineDetails> VaccinatedDetails = new List<VaccineDetails>(); //list for adding vaccinating detials
      

        public BeneficiaryDeatials(string name, double mobile, string address, int age, int gender) 
        {
            
            Name = name;
            Mobile = mobile;
            Address = address;
            Age = age;
            Gender = (GenderChoice)gender;
            RegistrationID = _autoIncreamentedNumber++;

        }
      
        public enum GenderChoice //enum for gender choice
        {
            Male = 1, Female, Transgender
        }
       
        public string DueDate() //checking for the beneficiary duedate
        {
            string message = string.Empty;

            if (VaccinatedDetails.Count == 0)
            {
                message = $"Please take vaccine First";
            }

            if (VaccinatedDetails.Count == 1)
            {

                message = $"Your Next dose due time is {VaccinatedDetails[0].VaccinatedDate.AddDays(30).ToString("dd/MM/yyyy")}";
                return message;

            }
            else
            {
                message = "You have completed the vaccination course. \n  Thanks for your participation in the vaccination drive.";
                return message;
            }
        }
    }
}
