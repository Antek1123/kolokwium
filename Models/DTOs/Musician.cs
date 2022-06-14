using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium.Models.DTOs
{
    public class Musician
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nickname { get; set; }
        public List<Models.DTOs.MusicianTrack> Tracks { get; set; }
    }
}