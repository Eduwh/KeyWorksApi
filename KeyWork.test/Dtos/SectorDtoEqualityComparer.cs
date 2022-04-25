using KeyWorks.Api.Models;
using System.Collections.Generic;

namespace KeyWork.test.Dtos
{
    internal class SectorDtoEqualityComparer : IEqualityComparer<SectorModel>
    {
        public bool Equals(SectorModel x, SectorModel y)
        => x.Name == y.Name;

        public int GetHashCode( SectorModel obj) => obj.Name.GetHashCode();
    }
}
