namespace KeyWorks.Api.Models
{
    public class ProjectModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<CardModel> Cards { get; set; }
    }
}
