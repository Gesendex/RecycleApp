using System;

namespace RecycleApi.Services.Interfaces
{
    internal interface ITimeProviderService
    {
        public DateTime CurrentDateTime { get; }
    }
}
