namespace GameCatalog.Models
{
    public class Game
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Genre { get; set; }

        public string Platform { get; set; }

        public string Opinion { get; set; }

        public DateOnly Release_Date { get; set; }

        public float Price { get; set; }

        public Game() { }

        public Game(int id, string name, string genre, string platform, string opinion, DateOnly release_Date, float price)
        {
            Id = id;
            Name = name;
            Genre = genre;
            Platform = platform;
            Opinion = opinion;
            Release_Date = release_Date;
            Price = price;
        }
    }
}
