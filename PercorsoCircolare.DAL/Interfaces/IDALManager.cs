using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PercorsoCircolare.DAL.Interfaces
{
    public interface IDALManager : IDisposable
    {
        IResourceRepo Resources { get; }
    }
}
