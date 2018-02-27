using System;
namespace FootballApp.Data
{
    public class Player
    {
        public string name { get; set; }
        public string position { get; set; }
        public int jerseyNumber { get; set; }
        public Nullable<DateTime> dateOfBirth { get; set; }
        public string nationality { get; set; }
        public Nullable<DateTime> contractUntil { get; set; }
    }
}
