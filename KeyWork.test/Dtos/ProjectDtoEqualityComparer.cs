using KeyWorks.Api.Models;
using System.Collections.Generic;

namespace KeyWork.test.Dtos
{
    internal class ProjectDtoEqualityComparer : IEqualityComparer<ProjectModel>
    {
        public bool Equals(ProjectModel x, ProjectModel y)
        => x.Name == y.Name;

        public int GetHashCode( ProjectModel obj) => obj.Name.GetHashCode();
    }
}
