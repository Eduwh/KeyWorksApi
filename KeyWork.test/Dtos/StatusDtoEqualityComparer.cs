using KeyWorks.Api.Models;
using System.Collections.Generic;

namespace KeyWork.test.Dtos
{
    internal class StatusDtoEqualityComparer : IEqualityComparer<StatusModel>
    {
        public bool Equals(StatusModel x, StatusModel y)
        => x.Name == y.Name;

        public int GetHashCode( StatusModel obj) => obj.Name.GetHashCode();
    }
}
