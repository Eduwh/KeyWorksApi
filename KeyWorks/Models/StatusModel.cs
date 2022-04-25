namespace KeyWorks.Api.Models
{
    //Status is the class that i made to be used as the column, this way the user can add new columns if he seens fit
    public class StatusModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<CardModel> Cards { get; set; }
    }
}
