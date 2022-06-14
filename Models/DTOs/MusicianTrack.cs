using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium.Models.DTOs
{
    public class MusicianTrack
    {
        public int IdTrack { get; set; }
        public Models.DTOs.Track Track_info { get; set; }       
    }
}