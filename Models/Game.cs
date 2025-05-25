namespace GameCatalog.Models
{
    public class Game
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Genre { get; set; }

        public string Platform { get; set; }

        public DateTime Release_Date { get; set; }
    }
}
