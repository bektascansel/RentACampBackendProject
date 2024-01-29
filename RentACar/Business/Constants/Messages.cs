using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public class Messages
    {
        public static string Listed = "Data Listed Successfully ";
        public static string Update = "Data Updated Succesfully";
        public static string Delete = "Data Deleted Succesfully";
        public static string Add = "Data Added Succesfully";
        public static string Get = "Data Fetched Succesfully";
        public static string NotData = "The Requested Data Could Not Be Found";

        public static string ImageLimitExceded = "The Picture Count is Full For This Car";
        public static string UserNotFound = "User Not Found";
        public static string PasswordError = "The Password is Wrong";
        public static string SuccessfulLogin = "Login Successfully";

        public static string UserAlreadyExist = "The User Already Exist";

        public static string UserRegistered = "The User Registered Sucessfully";
        public static string AccessTokenCreated="Access Token Created Successfully";
        public static string AuthorizationDenied = "You Have No Authority";
        public static string EmailNotFound = "Email Not Found";
    }
}
