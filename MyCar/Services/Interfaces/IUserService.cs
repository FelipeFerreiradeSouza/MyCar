using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyCar.Context;
using MyCar.DTOs;
using MyCar.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyCar.Services.Interfaces
{
    public interface IUserService
    {
        public Task<List<UserModel>> GetUsers();
        public Task<UserModel> GetUserById(int id);
        public Task<UserModel> GetUserByEmail(string email);
        public Task<UserModel> CreateUser(UserDTO userDTO);
        public Task<UserModel> UpdateUser(int id, UserDTO userDTO);
        public Task<bool> RemoveUserById(int id);
    }

}
