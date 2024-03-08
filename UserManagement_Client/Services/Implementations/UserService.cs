using System;
using System.Collections.Generic;

using UserManagement.Services.Domain.Interfaces;
using UserManagement_Data.Data;
using UserManagement_Services.DTO;

namespace UserManagement.Services.Domain.Implementations;

public class UserService : IUserService
{
    private readonly ApplicationDbContext _dataAccess;
    public UserService(ApplicationDbContext dataAccess) => _dataAccess = dataAccess;

    /// <summary>
    /// Return users by active state
    /// </summary>
    /// <param name="isActive"></param>
    /// <returns></returns>
    public IEnumerable<UserDTO> FilterByActive(bool isActive)
        => _dataAccess.ApplicationUsers.Where(x=> isActive != x.LockoutEnabled).Select(x =>
    new UserDTO
    {
        Email = x.Email,
        Id = x.Id,
        Name = x.Name,
        PhoneNumber = x.PhoneNumber
    });

    public IEnumerable<UserDTO> GetAll() => _dataAccess.ApplicationUsers.Select(x =>
    new UserDTO
    {
        Email = x.Email,
        Id = x.Id,
        Name = x.Name,
        PhoneNumber = x.PhoneNumber
    });
}
