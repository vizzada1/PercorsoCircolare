using System;

namespace PercorsoCircolare.DAL.Interfaces
{
    public interface IDALManager : IDisposable
    {
        IResourceRepo Resources { get; }
        IBuildingRepo Buildings { get; }
    }
}