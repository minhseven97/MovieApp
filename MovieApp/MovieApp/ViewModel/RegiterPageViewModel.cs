using Firebase.Database;
using Firebase.Database.Query;
using MovieApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.ViewModel
{
    public class RegiterPageViewModel
    {
        FirebaseClient firebase = new FirebaseClient("https://sample-notification-12baf.firebaseio.com/");

        public async Task<List<Register>> GetAllAcc()
        {

            return (await firebase
              .Child("Registers")
              .OnceAsync<Register>()).Select(item => new Register
              {
                  UserName = item.Object.UserName,
                  Password = item.Object.Password
              }).ToList();
        }

        public async Task AddAcc(string userName, string password)
        {

            await firebase
              .Child("Registers")
              .PostAsync(new Register() { UserName = userName, Password = password });
        }

        //public async Task<Person> GetPerson(int personId)
        //{
        //    var allPersons = await GetAllPersons();
        //    await firebase
        //      .Child("Persons")
        //      .OnceAsync<Person>();
        //    return allPersons.Where(a => a.PersonId == personId).FirstOrDefault();
        //}

        //public async Task UpdatePerson(int personId, string name)
        //{
        //    var toUpdatePerson = (await firebase
        //      .Child("Persons")
        //      .OnceAsync<Person>()).Where(a => a.Object.PersonId == personId).FirstOrDefault();

        //    await firebase
        //      .Child("Persons")
        //      .Child(toUpdatePerson.Key)
        //      .PutAsync(new Person() { PersonId = personId, Name = name });
        //}

        //public async Task DeletePerson(int personId)
        //{
        //    var toDeletePerson = (await firebase
        //      .Child("Persons")
        //      .OnceAsync<Person>()).Where(a => a.Object.PersonId == personId).FirstOrDefault();
        //    await firebase.Child("Persons").Child(toDeletePerson.Key).DeleteAsync();

        //}
    }
}
