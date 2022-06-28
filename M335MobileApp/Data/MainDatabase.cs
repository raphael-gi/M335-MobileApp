using System.Collections.Generic;
using SQLite;
using System.Threading.Tasks;
using M335MobileApp.Model;

namespace M335MobileApp.Data
{
    public class MainDatabase
    {
        private readonly SQLiteAsyncConnection database;

        public MainDatabase(string path)
        {
            database = new SQLiteAsyncConnection(path);
            database.CreateTableAsync<Games>().Wait();
        }
        public Task<List<Games>> SelectGame()
        {
            //Alle Spiele werden abgerufen
            return database.Table<Games>().OrderByDescending(Games => Games.ID).ToListAsync();
        }
        public Task<Games> Select1Game(int id)
        {
            //Ein Spiel wird abgerufen
            return database.Table<Games>().Where(Games => Games.ID == id).FirstOrDefaultAsync();
        }
        public Task<int> NewGame(Games game)
        {
            //Spiel wird in die Datenbank eingefügt
            return database.InsertAsync(game);
        }
        public Task<int> DeleteGame(Games game)
        {
            //Spiel wird gelöscht
            return database.DeleteAsync(game);
        }
        public Task<int> EditGame(Games game)
        {
            //Spiel wird bearbeitet
            return database.UpdateAsync(game);
        }
    }
}
