using System.Net.Http.Headers;
using GameStore.Frontend.Models;

namespace GameStore.Frontend.Clients;

public class GamesClient(HttpClient httpClient)
{
    public async Task<GameSummary[]> GetGamesAsync()
                => await httpClient.GetFromJsonAsync<GameSummary[]>("games") ?? [];
    public async Task AddGameAsync(GameDetails game) => await httpClient.PostAsJsonAsync("games", game);
    public async Task DeleteGameAsync(int id)
            => await httpClient.DeleteAsync($"games/{id}");
    public async Task<GameDetails> GetGameAsync(int id)
                => await httpClient.GetFromJsonAsync<GameDetails>($"games{id}") ?? throw new Exception("Could not find game");
    public async Task UpdateGameAsync(GameDetails updatedGame)
            => await httpClient.PutAsJsonAsync($"games/{updatedGame.Id}", updatedGame);
}

// public class GamesClient()
// {
//     private readonly List<GameSummary> games =
//     [
//         new(){
//             Id = 1,
//             Name="Street Fighter II",
//             Genre="Fighting",
//             Price=19.99M,
//             ReleaseDate=new DateOnly(1992, 7, 17)
//         },
//         new(){
//             Id = 2,
//             Name="Final Fantasy II",
//             Genre="Roleplaying",
//             Price=59.99M,
//             ReleaseDate=new DateOnly(2010, 9, 30)
//         },
//         new(){
//             Id = 3,
//             Name="FIFA 23",
//             Genre="Sports",
//             Price=69.99M,
//             ReleaseDate=new DateOnly(2022, 9, 27)
//         }
//     ];

//     private readonly Genre[] genres = new GenresClient().GetGenres();
//     public GameSummary[] GetGames() => [.. games];

//     public void AddGame(GameDetails game)
//     {
//         Genre genre = GetGenreById(game.GenreId);
//         var GameSummary = new GameSummary
//         {
//             Id = games.Count + 1,
//             Name = game.Name,
//             Genre = genre.Name,
//             Price = game.Price,
//             ReleaseDate = game.ReleaseDate
//         };

//         games.Add(GameSummary);
//     }

//     public void DeleteGame(int id)
//     {
//         var game = GetGameSummaryById(id);
//         games.Remove(game);
//     }

//     public GameDetails GetGame(int id)
//     {
//         GameSummary game = GetGameSummaryById(id);

//         var genre = genres.Single(genre => string.Equals(
//                             genre.Name, game.Genre, StringComparison.OrdinalIgnoreCase));
//         return new GameDetails
//         {
//             Id = game.Id,
//             Name = game.Name,
//             GenreId = genre.Id.ToString(),
//             Price = game.Price,
//             ReleaseDate = game.ReleaseDate
//         };
//     }

//     public void UpdateGame(GameDetails updatedGame)
//     {
//         var genre = GetGenreById(updatedGame.GenreId);
//         GameSummary existingGame = GetGameSummaryById(updatedGame.Id);

//         existingGame.Name = updatedGame.Name;
//         existingGame.Genre = genre.Name;
//         existingGame.Price = updatedGame.Price;
//         existingGame.ReleaseDate = updatedGame.ReleaseDate;
//     }
//     private GameSummary GetGameSummaryById(int id)
//     {
//         GameSummary? game = games.Find(game => game.Id == id);
//         ArgumentNullException.ThrowIfNull(game);
//         return game;
//     }

//     private Genre GetGenreById(string? id)
//     {
//         ArgumentException.ThrowIfNullOrWhiteSpace(id);
//         return genres.Single(genre => genre.Id == int.Parse(id));
//     }
// }
