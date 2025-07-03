using Shared.Domain.Models;

namespace Shared.Application;

public interface IJwtService
{
    string GenerateToken(User user);
}