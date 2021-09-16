using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
    public interface IUserModel
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        DateTime DateOfBirth { get; set; }
        string EmailAddress { get; set; }
        string PhoneNumber { get; set; }
        string Password { get; set; }

    }
}
