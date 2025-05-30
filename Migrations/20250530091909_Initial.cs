using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GameCatalog.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Game",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Platform = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Opinion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Release_Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Game",
                columns: new[] { "Id", "Genre", "Name", "Opinion", "Platform", "Price", "Release_Date" },
                values: new object[,]
                {
                    { 1, "RPG", "The Witcher 3: Wild Hunt", "Critically acclaimed for its story", "PC", 59.99f, new DateOnly(2015, 5, 19) },
                    { 2, "Action RPG", "Cyberpunk 2077", "Ambitious open-world experience", "PC", 59.99f, new DateOnly(2020, 12, 10) },
                    { 3, "Survival Horror", "Dying Light", "Thrilling zombie survival", "PC", 49.99f, new DateOnly(2015, 1, 27) },
                    { 4, "Sandbox", "Minecraft", "Endlessly creative gameplay", "PC", 29.99f, new DateOnly(2011, 11, 18) },
                    { 5, "Action-Adventure", "Grand Theft Auto V", "Massive open-world adventure", "PC", 59.99f, new DateOnly(2013, 9, 17) },
                    { 6, "Platformer", "Super Mario Bros.", "Iconic platforming classic", "NES", 49.99f, new DateOnly(1985, 9, 13) },
                    { 7, "Action-Adventure", "The Legend of Zelda: Ocarina of Time", "Timeless adventure masterpiece", "N64", 49.99f, new DateOnly(1998, 11, 21) },
                    { 8, "Puzzle", "Tetris", "Addictive and timeless", "Game Boy", 29.99f, new DateOnly(1989, 6, 14) },
                    { 9, "RPG", "Final Fantasy VII", "Groundbreaking narrative", "PlayStation", 49.99f, new DateOnly(1997, 9, 7) },
                    { 10, "RPG", "Pokémon Red/Blue", "Sparked a global phenomenon", "Game Boy", 39.99f, new DateOnly(1998, 9, 28) },
                    { 11, "Platformer", "Super Mario 64", "Revolutionary 3D platformer", "N64", 49.99f, new DateOnly(1996, 9, 26) },
                    { 12, "FPS", "Halo: Combat Evolved", "Defined console shooters", "Xbox", 49.99f, new DateOnly(2001, 11, 15) },
                    { 13, "Sports", "Wii Sports", "Accessible family fun", "Wii", 49.99f, new DateOnly(2006, 11, 19) },
                    { 14, "FPS", "Call of Duty: Modern Warfare", "Set multiplayer standard", "PC", 59.99f, new DateOnly(2007, 11, 5) },
                    { 15, "RPG", "The Elder Scrolls V: Skyrim", "Expansive fantasy world", "PC", 59.99f, new DateOnly(2011, 11, 11) },
                    { 16, "Battle Royale", "Fortnite", "Cultural phenomenon", "PC", 0f, new DateOnly(2017, 7, 25) },
                    { 17, "Action-Adventure", "The Legend of Zelda: Breath of the Wild", "Redefined open-world games", "Switch", 59.99f, new DateOnly(2017, 3, 3) },
                    { 18, "Arcade", "Pong", "Pioneered video gaming", "Arcade", 0.25f, new DateOnly(1972, 11, 29) },
                    { 19, "Arcade", "Pac-Man", "Cultural icon", "Arcade", 0.25f, new DateOnly(1980, 5, 22) },
                    { 20, "Platformer", "Donkey Kong", "Introduced Mario", "Arcade", 0.25f, new DateOnly(1981, 7, 9) },
                    { 21, "Fighting", "Street Fighter II", "Defined fighting games", "Arcade", 0.25f, new DateOnly(1991, 2, 6) },
                    { 22, "FPS", "Doom", "Pioneered FPS genre", "PC", 39.99f, new DateOnly(1993, 12, 10) },
                    { 23, "FPS", "GoldenEye 007", "Console FPS benchmark", "N64", 49.99f, new DateOnly(1997, 8, 25) },
                    { 24, "Fighting", "Super Smash Bros. Melee", "Competitive classic", "GameCube", 49.99f, new DateOnly(2001, 12, 3) },
                    { 25, "Survival Horror", "Resident Evil 4", "Redefined survival horror", "GameCube", 49.99f, new DateOnly(2005, 1, 11) },
                    { 26, "MMORPG", "World of Warcraft", "MMO giant", "PC", 49.99f, new DateOnly(2004, 11, 23) },
                    { 27, "Rhythm", "Guitar Hero", "Music game revolution", "PS2", 49.99f, new DateOnly(2005, 11, 8) },
                    { 28, "FPS", "BioShock", "Immersive storytelling", "PC", 59.99f, new DateOnly(2007, 8, 21) },
                    { 29, "Puzzle", "Portal", "Innovative puzzle design", "PC", 19.99f, new DateOnly(2007, 10, 10) },
                    { 30, "RPG", "Mass Effect 2", "Epic sci-fi narrative", "PC", 59.99f, new DateOnly(2010, 1, 26) },
                    { 31, "Action-Adventure", "Red Dead Redemption", "Cinematic Western epic", "PS3", 59.99f, new DateOnly(2010, 5, 18) },
                    { 32, "Action-Adventure", "Batman: Arkham City", "Superhero perfection", "PC", 59.99f, new DateOnly(2011, 10, 18) },
                    { 33, "Action RPG", "Dark Souls", "Challenging masterpiece", "PC", 59.99f, new DateOnly(2011, 9, 22) },
                    { 34, "MOBA", "League of Legends", "Esports juggernaut", "PC", 0f, new DateOnly(2009, 10, 27) },
                    { 35, "Party", "Among Us", "Social deduction hit", "PC", 4.99f, new DateOnly(2018, 6, 15) },
                    { 36, "Simulation", "Animal Crossing: New Horizons", "Charming life sim", "Switch", 59.99f, new DateOnly(2020, 3, 20) },
                    { 37, "Platformer", "Super Mario Odyssey", "Joyful 3D platformer", "Switch", 59.99f, new DateOnly(2017, 10, 27) },
                    { 38, "FPS", "Overwatch", "Team-based shooter", "PC", 59.99f, new DateOnly(2016, 5, 24) },
                    { 39, "Action-Adventure", "God of War (2018)", "Emotional epic", "PS4", 59.99f, new DateOnly(2018, 4, 20) },
                    { 40, "Metroidvania", "Hollow Knight", "Atmospheric indie gem", "PC", 14.99f, new DateOnly(2017, 2, 24) },
                    { 41, "Simulation", "Stardew Valley", "Charming farming sim", "PC", 14.99f, new DateOnly(2016, 2, 26) },
                    { 42, "Simulation", "The Sims", "Life simulation classic", "PC", 49.99f, new DateOnly(2000, 2, 4) },
                    { 43, "Action RPG", "Diablo II", "Addictive loot-driven RPG", "PC", 49.99f, new DateOnly(2000, 6, 29) },
                    { 44, "FPS", "Half-Life 2", "Groundbreaking narrative FPS", "PC", 49.99f, new DateOnly(2004, 11, 16) },
                    { 45, "Stealth", "Metal Gear Solid", "Cinematic stealth classic", "PlayStation", 49.99f, new DateOnly(1998, 9, 3) },
                    { 46, "RPG", "Chrono Trigger", "Timeless RPG masterpiece", "SNES", 49.99f, new DateOnly(1995, 3, 11) },
                    { 47, "Metroidvania", "Super Metroid", "Exploration masterpiece", "SNES", 49.99f, new DateOnly(1994, 3, 19) },
                    { 48, "Racing", "Mario Kart 8", "Fun multiplayer racing", "Switch", 59.99f, new DateOnly(2014, 5, 29) },
                    { 49, "FPS", "Destiny", "Shared-world shooter", "PS4", 59.99f, new DateOnly(2014, 9, 9) },
                    { 50, "Sports", "FIFA 18", "Popular soccer sim", "PC", 59.99f, new DateOnly(2017, 9, 29) },
                    { 51, "Fighting", "Mortal Kombat", "Gritty fighting classic", "Arcade", 0.25f, new DateOnly(1992, 10, 8) },
                    { 52, "RTS", "StarCraft", "Esports pioneer", "PC", 49.99f, new DateOnly(1998, 3, 31) },
                    { 53, "FPS", "Counter-Strike", "Competitive FPS legend", "PC", 19.99f, new DateOnly(2000, 11, 9) },
                    { 54, "Racing", "Gran Turismo", "Realistic racing sim", "PlayStation", 49.99f, new DateOnly(1997, 12, 23) },
                    { 55, "Action-Adventure", "Shadow of the Colossus", "Artistic masterpiece", "PS2", 49.99f, new DateOnly(2005, 10, 18) },
                    { 56, "Adventure", "Journey", "Emotional indie experience", "PS3", 14.99f, new DateOnly(2012, 3, 13) },
                    { 57, "Action RPG", "Bloodborne", "Intense gothic adventure", "PS4", 59.99f, new DateOnly(2015, 3, 24) },
                    { 58, "Action-Adventure", "Uncharted 2: Among Thieves", "Cinematic action classic", "PS3", 59.99f, new DateOnly(2009, 10, 13) },
                    { 59, "RPG", "Fallout: New Vegas", "Deep role-playing", "PC", 59.99f, new DateOnly(2010, 10, 19) },
                    { 60, "Platformer", "Celeste", "Heartfelt indie platformer", "PC", 19.99f, new DateOnly(2018, 1, 25) },
                    { 61, "Action-Adventure", "The Last of Us", "Emotional narrative masterpiece", "PS3", 59.99f, new DateOnly(2013, 6, 14) },
                    { 62, "Platformer", "Super Mario World", "Classic Mario adventure", "SNES", 49.99f, new DateOnly(1990, 11, 21) },
                    { 63, "RPG", "Pokémon Gold/Silver", "Expanded Pokémon world", "Game Boy Color", 39.99f, new DateOnly(1999, 11, 21) },
                    { 64, "Sports", "Tony Hawk’s Pro Skater 2", "Skateboarding classic", "PlayStation", 49.99f, new DateOnly(2000, 9, 20) },
                    { 65, "FPS", "Battlefield 3", "Epic multiplayer battles", "PC", 59.99f, new DateOnly(2011, 10, 25) },
                    { 66, "Shooter", "Splatoon 2", "Colorful multiplayer fun", "Switch", 59.99f, new DateOnly(2017, 7, 21) },
                    { 67, "Roguelike", "Hades", "Stylish roguelike gem", "PC", 24.99f, new DateOnly(2020, 9, 17) },
                    { 68, "Action-Adventure", "Sekiro: Shadows Die Twice", "Challenging samurai epic", "PC", 59.99f, new DateOnly(2019, 3, 22) },
                    { 69, "Action-Adventure", "Assassin’s Creed II", "Renaissance adventure", "PC", 59.99f, new DateOnly(2009, 11, 17) },
                    { 70, "RPG", "Dragon Quest XI", "Classic JRPG charm", "PC", 59.99f, new DateOnly(2018, 9, 4) },
                    { 71, "Sports", "Rocket League", "Soccer meets cars", "PC", 19.99f, new DateOnly(2015, 7, 7) },
                    { 72, "Strategy", "Civilization V", "Deep strategy classic", "PC", 49.99f, new DateOnly(2010, 9, 21) },
                    { 73, "Platformer", "Mega Man 2", "Iconic platformer", "NES", 49.99f, new DateOnly(1988, 12, 24) },
                    { 74, "Tactical RPG", "Fire Emblem: Three Houses", "Engaging strategy RPG", "Switch", 59.99f, new DateOnly(2019, 7, 26) },
                    { 75, "Action RPG", "Monster Hunter: World", "Epic monster hunts", "PC", 59.99f, new DateOnly(2018, 8, 9) },
                    { 76, "Action-Adventure", "Tomb Raider (2013)", "Gritty reboot success", "PC", 59.99f, new DateOnly(2013, 3, 5) },
                    { 77, "Third-Person Shooter", "Gears of War", "Intense cover-based shooter", "Xbox 360", 59.99f, new DateOnly(2006, 11, 7) },
                    { 78, "RPG", "Persona 5", "Stylish JRPG masterpiece", "PS4", 59.99f, new DateOnly(2017, 4, 4) },
                    { 79, "Puzzle", "Portal 2", "Witty puzzle sequel", "PC", 19.99f, new DateOnly(2011, 4, 19) },
                    { 80, "Platformer", "Super Mario Galaxy", "Stellar 3D platformer", "Wii", 49.99f, new DateOnly(2007, 11, 12) },
                    { 81, "FPS", "Left 4 Dead", "Co-op zombie chaos", "PC", 49.99f, new DateOnly(2008, 11, 17) },
                    { 82, "Action-Adventure", "The Legend of Zelda: A Link to the Past", "Classic Zelda adventure", "SNES", 49.99f, new DateOnly(1991, 11, 21) },
                    { 83, "MMORPG", "Final Fantasy XIV", "Revived MMO success", "PC", 59.99f, new DateOnly(2013, 8, 27) },
                    { 84, "Action RPG", "Horizon Zero Dawn", "Stunning open-world RPG", "PS4", 59.99f, new DateOnly(2017, 2, 28) },
                    { 85, "FPS", "Team Fortress 2", "Fun class-based shooter", "PC", 0f, new DateOnly(2007, 10, 10) },
                    { 86, "Puzzle", "Katamari Damacy", "Quirky rolling fun", "PS2", 29.99f, new DateOnly(2004, 3, 18) },
                    { 87, "Action-Adventure", "Okami", "Artistic masterpiece", "PS2", 39.99f, new DateOnly(2006, 4, 20) },
                    { 88, "RPG", "Xenoblade Chronicles", "Expansive JRPG world", "Wii", 49.99f, new DateOnly(2010, 6, 10) },
                    { 89, "Survival Horror", "Dead Space", "Terrifying sci-fi horror", "PC", 59.99f, new DateOnly(2008, 10, 14) },
                    { 90, "Action", "Bayonetta", "Stylish action classic", "PS3", 59.99f, new DateOnly(2010, 1, 5) },
                    { 91, "MOBA", "Dota 2", "Competitive MOBA leader", "PC", 0f, new DateOnly(2013, 7, 9) },
                    { 92, "Action-Adventure", "Spider-Man (2018)", "Thrilling superhero adventure", "PS4", 59.99f, new DateOnly(2018, 9, 7) },
                    { 93, "Fighting", "Super Street Fighter IV", "Refined fighting classic", "PS3", 39.99f, new DateOnly(2010, 4, 27) },
                    { 94, "Action RPG", "Nier: Automata", "Emotional action RPG", "PC", 59.99f, new DateOnly(2017, 3, 17) },
                    { 95, "Racing", "F-Zero", "Fast-paced futuristic racing", "SNES", 49.99f, new DateOnly(1990, 11, 21) },
                    { 96, "Platformer", "Crash Bandicoot", "Classic 90s platformer", "PlayStation", 49.99f, new DateOnly(1996, 9, 9) },
                    { 97, "Simulation", "SimCity 2000", "City-building classic", "PC", 39.99f, new DateOnly(1993, 1, 1) },
                    { 98, "Tower Defense", "Plants vs. Zombies", "Fun strategy game", "PC", 19.99f, new DateOnly(2009, 5, 5) },
                    { 99, "Third-Person Shooter", "Max Payne", "Noir action classic", "PC", 49.99f, new DateOnly(2001, 7, 23) },
                    { 100, "Action RPG", "Elden Ring", "Open-world masterpiece", "PC", 59.99f, new DateOnly(2022, 2, 25) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Game");
        }
    }
}
