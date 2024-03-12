using UserManagement_Client.DtoModel;

namespace UserManagement_Client.Interfaces;

public interface ILogger
{
    
    Task LogTrace(string message);
    Task LogError(string message);
    Task<List<UserLogDTO>> GetLog(long userId);
}
