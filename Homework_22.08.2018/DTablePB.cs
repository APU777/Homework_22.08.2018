using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_22._08._2018
{
    class DTablePB
    {
        public DTablePB(string _LastName, string _FirstName, string _SurName, char _Sex, string _Date, string _Country, string _City, string _Address, string _PhoneNumber)
        {
            this.LastName = _LastName;
            this.FirstName = _FirstName;
            this.SurName = _SurName;
            this.Sex = _Sex;
            this.Date = _Date;
            this.Country = _Country;
            this.City = _City;
            this.Address = _Address;
            this.PhoneNumber = _PhoneNumber;
            
        }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public char Sex { get; set; }
        public string Date { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}
