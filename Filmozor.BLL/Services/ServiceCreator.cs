using Filmozor.BLL.Interfaces;
using Filmozor.DAL.Repositories;

namespace Filmozor.BLL.Services
{
    public class ServiceCreator : IServiceCreator
    {
        public IUserService CreateUserService(string connection)
        {
            return new UserService(new IdentityUnitOfWork(connection));
        }
    }
}
