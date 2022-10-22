using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ProjectManagementSystem.App;
namespace ProjectManagementSystem.Model
{
    public class Users
    
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public async Task<bool> AddUser(string fname, string lname, string mail, string pass)
        {
            try
            {
                var evaluateEmail = (await client
                    .Child("Users")
                    .OnceAsync<Users>())
                    .FirstOrDefault
                    (a => a.Object.Email == mail);
                if (evaluateEmail == null)
                {
                    var user = new Users()
                    {
                        Firstname = fname,
                        Lastname = lname,
                        Email = mail,
                        Password = pass
                    };
                    await client.Child("Users").PostAsync(user  );
                    client.Dispose();

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {

                return false;
            }
        }
        public async Task<bool> UserLogin(string email, string Pass)
        {
            try
            {
                var evaluateEmail = (await client
               .Child("Users")
               .OnceAsync<Users>())
               .FirstOrDefault
               (a => a.Object.Email == email && a.Object.Password == Pass);
                return evaluateEmail != null;
            }
            catch
            {
                return false;
            }

        }
    }
    

}

