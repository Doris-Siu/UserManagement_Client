using UserManagement_Client.DtoModel;

namespace UserManagement_Client.Interfaces;

public interface IUserService 
{
    Task<IEnumerable<UserDTO>> Get();
    Task<UserDTO> Get(long userId);
    Task<UserDTO?> Get(string emailAddress, string dateOfBirth);
    Task<(bool success, UserDTO dto, string error)> Create(UserDTO dto);
    Task<(bool success, UserDTO dto, string error)> Update(UserDTO dto);
    Task<(bool success, UserDTO dto, string error)> Delete(UserDTO dto);
}
