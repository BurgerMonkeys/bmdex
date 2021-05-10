using System;
using System.Threading.Tasks;

namespace BMDex.Abstractions
{
    public interface IInitialize
    {
        Task InitializeAsync();
    }
}
