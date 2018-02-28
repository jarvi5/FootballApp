using System;
namespace FootballApp.Data
{
    public class Player
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public int JerseyNumber { get; set; }
        public Nullable<DateTime> DateOfBirth { get; set; }
        public string Nationality { get; set; }
        public Nullable<DateTime> ContractUntil { get; set; }
    }
}
