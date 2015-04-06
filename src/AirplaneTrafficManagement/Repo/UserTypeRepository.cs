using AirplaneTrafficManagement.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AirplaneTrafficManagement.Repo
{
    public class UserTypeRepository : IUserTypeRepository
    {
        private AirplaneTrafficEntities _context;

        public UserTypeRepository()
        {
            _context = new AirplaneTrafficEntities();
        }

        public IEnumerable<UserType> GetUserTypes()
        {
            return _context.UserType.ToList();
        }

        public UserType GetUserTypesById(int id)
        {
            return _context.UserType.Find(id);
        }

        //----------------------------------------------ADMIN FUNCTIONALITIES-----------------//

        public void InsertUserType(UserType user)
        {
            _context.UserType.Add(user);
        }

        public void DeleteUserType(int Id)
        {
            UserType user = _context.UserType.Find(Id);
            _context.UserType.Remove(user);
        }

        public void UpdateUserType(UserType user)
        {
            _context.Entry(user).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

    }
}