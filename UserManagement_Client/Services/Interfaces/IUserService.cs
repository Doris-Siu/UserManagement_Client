using System.Collections.Generic;
using UserManagement_Services.DTO;

namespace UserManagement_Client.Interfaces;

public interface IUserService 
{
    /// <summary>
    /// Return users by active state
    /// </summary>
    /// <param name="isActive"></param>
    /// <returns></returns>
    IEnumerable<UserDTO> FilterByActive(bool isActive);
    IEnumerable<UserDTO> GetAll();
}
