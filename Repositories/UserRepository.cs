﻿using Entities;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Repositories
{
    public class UserRepository : IUserRepository
    {
        ManagerDbContext _managerDbContext;

        public UserRepository(ManagerDbContext managerDbContext)
        {
            _managerDbContext = managerDbContext;
        }

        public async Task<User> PostLoginR(string username, string password)
        {
            User user = await _managerDbContext.Users.FirstOrDefaultAsync(u => u.UserName == username && u.Password == password);
            return user;
        }
        public async Task<User> Post(User user)
        {
            var res=await _managerDbContext.Users.AddAsync(user);
            await _managerDbContext.SaveChangesAsync();
            //return user;
            return res;// - the created user with the id

        }
        public async Task Put(int id,User user1)//return user
        {
            _managerDbContext.Users.Update(user1);
            await _managerDbContext.SaveChangesAsync();
        }
    }
}
