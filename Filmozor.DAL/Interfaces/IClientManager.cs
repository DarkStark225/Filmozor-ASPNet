using Filmozor.DAL.Entities;
using System;

namespace Filmozor.DAL.Interfaces
{
    public interface IClientManager:IDisposable
    {
        void Create(ClientProfile item);
    }
}
