using CarDealership2.Interfaces;
using CarDealership2.Models;
using CarDealership2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership2.Repositories
{
       
    public class ContactRepositoryQA : IContactRepository
    {
        public static List<Contact> contacts;

        public ContactRepositoryQA()
        {
            contacts = new List<Contact>();
        }

        public void Add(ContactVM viewmodel)
        {
            Contact model = new Contact();

            if (!contacts.Any())
            {
                model.ContactId = 1;
            }

            else
            {
                model.ContactId = contacts.Max(m => m.ContactId) + 1;
            }

            model.Name = viewmodel.Name;
            model.Email = viewmodel.Email;
            model.Phone = viewmodel.Phone;
            model.Message = viewmodel.Message;

            contacts.Add(model);
        }
    }
}