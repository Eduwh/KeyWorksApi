using KeyWorks.Api.Models;
using System.Collections.Generic;

namespace KeyWork.test.Dtos
{
    internal class TeamDtoEqualityComparer : IEqualityComparer<TeamModel>
    {
        public bool Equals(TeamModel x, TeamModel y)
        => x.Name == y.Name;

        public int GetHashCode( TeamModel obj) => obj.Name.GetHashCode();
    }
}
