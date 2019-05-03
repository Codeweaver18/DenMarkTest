using DenMarkTest.DataAccessLayer.Dbcontexts;
using System;
using System.Collections.Generic;
using System.Text;
using DenMarkTest.DataAccessLayer.Entities;

namespace DenMarkTest.DataAccessLayer.Identity
{
   public  class DataSeeding
    {
        private DanishContext _dbContext;
        private IdentityContext _identity;
        private Dictionary<string, string> _users;
        private Dictionary<string, string> _roles;


        public DataSeeding(DanishContext dbContect, IdentityContext identity)
        {
            _dbContext = dbContect;
            _identity = identity;
        }

        //intending users seeding
        public void  addusers()
        {
           
            try
            {
                _users.Add("Mitchel", "Fausto");
                _users.Add("Queen ", "Jacobi");
                _users.Add("Magen ", "Faye");
                _users.Add("Delicia", "Ledonne ");
                _users.Add("Camille", "Grantham ");
                _users.Add("Marc", "Voth");
                _users.Add("Randy", "Rondon");
                _users.Add("Delora", "Saville");
                _users.Add("Rosario ", "Reuben");
                _users.Add("Rosario ", "Uhlman ");


                foreach (var item in _users)
                {
                    _dbContext.Users.Add(new User
                    {
                        fname = item.Key,
                        lname = item.Value
                           
                    });

               
                }

                _dbContext.SaveChanges();

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public void addRoles()
        {
            _roles.Add("Coach", "Coach");
            _roles.Add("Athelete", "Athelete");
            //
            try
            {


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
