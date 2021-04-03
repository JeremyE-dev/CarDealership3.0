using CarDealership2.Interfaces;
using CarDealership2.Models;
using CarDealership2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership2.Repositories
{
    public class UserRepositoryQA : IUserRepository
    {

        //QA Repositories are serving MockRepositories, therefore do not write to the database
        //The UserData model is being used in place of an AppUser for this reason

        public static List<UserData> users;

        public  UserRepositoryQA()
        {
            users = new List<UserData>();
            
            UserData alan = new UserData { UserId = 1, Email = "awatts@sgcars.com", FirstName = "Alan", LastName = "Watts", UserName = "awatts@sgcars.com", Password = "testing123", RoleName = "sales" };
            UserData tom = new UserData { UserId = 2, Email = "tbaker@sgcars.com", FirstName = "Tom", LastName = "Baker", UserName = "tbaker@sgcars.com", Password = "testing123", RoleName = "sales" };
            UserData jeremy = new UserData { UserId = 3, Email = "jeudaly@sgcars.com", FirstName = "Jeremy", LastName = "Eudaly", UserName = "jeudaly@sgcars.com", Password = "testing123", RoleName = "admin" };
            UserData gene = new UserData { UserId = 4, Email = "gwilder@sgcars.com", FirstName = "Gene", LastName = "Wilder", UserName = "gwilder@sgcars.com", Password = "testing123", RoleName = "admin" };

            users.Add(alan);
            users.Add(tom);
            users.Add(jeremy);
            users.Add(gene);

        }


        public void Add(AddUserVM viewmodel)
        {
            var user = new UserData
            {
                FirstName = viewmodel.FirstName,
                LastName = viewmodel.LastName,
                Email = viewmodel.Email,
                UserName = viewmodel.Email,
                RoleName = viewmodel.SelectedRoleType.ToString(),
                Password = viewmodel.Password

            };

            users.Add(user);
        }

        public void ChangePassword(ChangePasswordVM viewmodel)
        {
            UserData user = users.FirstOrDefault(u => u.UserName == viewmodel.UserName);

            user.Password = viewmodel.NewPassword;

        }

        public void Edit(EditUserVM viewmodel)
        {

            var user = users.FirstOrDefault(u => u.UserId.Equals(viewmodel.UserId));
            user.FirstName = viewmodel.FirstName;
            user.LastName = viewmodel.LastName;
            user.Email = viewmodel.Email;

            //What to do with the roles
            if (!string.IsNullOrEmpty(viewmodel.Password))
            {
                user.Password = viewmodel.Password;
            }

            string selectedrolename = Enum.GetName(typeof(RoleType), viewmodel.SelectedRoleType);

            if (viewmodel.SelectedRoleType.ToString() != user.RoleName)
            {
                user.RoleName = user.RoleName;
            }


        }

        public IEnumerable<UserData> TestGetAll()
        {
            var u = from user in users
                    select user;
            return u.ToList();
        }

        List<AppUser> IUserRepository.GetAll()
        {
            throw new NotImplementedException();
        }
    }



}