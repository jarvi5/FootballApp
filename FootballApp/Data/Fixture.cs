﻿using System;

namespace FootballApp.Data
{
    public class Fixture
    {
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public string HomeTeamName { get; set; }
        public string AwayTeamName { get; set; }
        public Result Result { get; set; }
    }
}
