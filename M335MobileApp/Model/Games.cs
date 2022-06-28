using System;
using SQLite;

namespace M335MobileApp.Model
{
    public class Games
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Game { get; set; }
        public string Creator { get; set; }
        public DateTime Date { get; set; }
    }
}
