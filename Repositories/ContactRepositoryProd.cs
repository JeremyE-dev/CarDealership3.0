using CarDealership2.Interfaces;
using CarDealership2.Models;
using CarDealership2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership2.Repositories
{
    public class ContactRepositoryProd : IContactRepository
    {
        public void Add(ContactVM viewmodel)
        {
            var repository = new CarDealership2DbContext();

            Contact model = new Contact();

            if (!repository.Contacts.Any())
            {
                model.ContactId = 1;
            }

            else
            {
                model.ContactId = repository.Contacts.Max(m => m.ContactId) + 1;
            }

            model.Name = viewmodel.Name;
            model.Email = viewmodel.Email;
            model.Phone = viewmodel.Phone;
            model.Message = viewmodel.Message;

            repository.Contacts.Add(model);
            repository.SaveChanges();

        }
    }
}