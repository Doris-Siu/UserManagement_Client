using UserManagement_Client.VM;

namespace UserManagement_Client.Interfaces;

public interface IUserService 
{

    Task<IEnumerable<UserDTO>> Get();
    Task<UserDTO> Get(long userId);

}
