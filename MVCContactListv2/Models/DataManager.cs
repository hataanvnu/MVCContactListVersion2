using AutoMapper;
using MVCContactListv2.Models.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MVCContactListv2.Models
{
    public static class DataManager
    {
        const string filePath = @"C:\Users\Administrator\Documents\Visual Studio 2017\Projects\MVCContactListv2\MVCContactListv2\Data\ContactList.json";
        //static List<Person> persons = new List<Person>();
        

        public static Person[] GetAllPeople()
        {
            var persons = LoadListFromJsonFile();
            return persons.ToArray();
        }

        public static PeopleIndexVM[] ListPeople()
        {
            var persons = LoadListFromJsonFile();

            List<PeopleIndexVM> peopleIndexVMs = new List<PeopleIndexVM>();

            foreach (var person in persons)
            {
                peopleIndexVMs.Add(new PeopleIndexVM
                {
                    Email = person.Email,
                    Name = person.Name,
                    Id = person.Id,
                    ShowAsHighlighted = person.Email.EndsWith("acme.com"),
                });
            }

            return peopleIndexVMs.ToArray();
        }

        public static PeopleEditVM GetContactById(int id)
        {
            var persons = LoadListFromJsonFile();

            var person = persons
                .SingleOrDefault(p => p.Id == id);

            var ret = new PeopleEditVM
            {
                Name = person.Name,
                Email = person.Email,
                ID = id,
            };

            return ret;
        }

        internal static void RemoveContactById(int id)
        {
            var persons = LoadListFromJsonFile();

            var newPersons = persons
                .Where(p => p.Id != id);

            newPersons.SaveListToJsonFile();
        }


        //public static void AddPerson(Person person)
        //{
        //    var persons = LoadListFromJsonFile();

        //    int maxID;
        //    if (persons.Count > 0)
        //    {
        //        maxID = persons
        //            .Max(p => p.Id);
        //    }
        //    else
        //    {
        //        maxID = 0;
        //    }

        //    person.Id = maxID + 1;
        //    persons.Add(person);

        //    persons.SaveListToJsonFile();
        //}

        public static void AddPerson(PeopleCreateVM peopleCreateVM)
        {
            // Todo: ta bort originalmetoden

            var persons = LoadListFromJsonFile();


            // Den här koden är det jag behövde skriva innan jag körde AutoMapper
            //Person person = new Person
            //{
            //    Name = peopleCreateVM.Name,
            //    Email = peopleCreateVM.Email,
            //};

            var person = Mapper.Map<Person>(peopleCreateVM); 

            int maxID;
            if (persons.Count > 0)
            {
                maxID = persons
                    .Max(p => p.Id);
            }
            else
            {
                maxID = 0;
            }

            person.Id = maxID + 1;
            persons.Add(person);

            persons.SaveListToJsonFile();
        }


        internal static void EditContact(int id, PeopleEditVM newPeopleEditVM)
        {
            var persons = LoadListFromJsonFile();

            var person = persons
                .SingleOrDefault(p => p.Id == id);

            person.Name = newPeopleEditVM.Name;
            person.Email = newPeopleEditVM.Email;

            persons.SaveListToJsonFile();
        }


        #region JSON IO
        private static void SaveListToJsonFile<Person>(this IEnumerable<Person> persons)
        {
            string jsonString = JsonConvert.SerializeObject(persons, Formatting.Indented);
            File.WriteAllText(filePath, jsonString);
        }

        private static List<Person> LoadListFromJsonFile()
        {
            string jsonFromFile = File.ReadAllText(filePath);
            List<Person> persons = JsonConvert.DeserializeObject<List<Person>>(jsonFromFile);
            if (persons == null)
            {
                return new List<Person>();
            }
            return persons;
        }
        #endregion
    }
}
