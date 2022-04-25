namespace KeyWorks.Api.Models
{
    //My interpretation of the card class usign the image from the PDF
    public class CardModel

    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ForeseenDate { get; set; }
        //Order in rows
        public int Priority { get; set; }

        public string UserId { get; set; }
        public UserModel User { get; set; }

        //Order in columns
        public int StatusId { get; set; }
        public StatusModel Status { get; set; }

        public int ProjectId { get; set; }
        public ProjectModel Project { get; set; }

        public int TeamId { get; set; }
        public TeamModel Team { get; set; }

        public int SectorId { get; set; }
        public SectorModel Sector { get; set; }
    }
}
