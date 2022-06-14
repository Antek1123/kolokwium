using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium.Services
{
    public interface IMusicService
    {
        public Task<List<Models.DTOs.Musician>> GetMusician(int id);
        public Task<bool> IsMusicianExists(int id);
        public Task DeleteMusician(int id);
        public Task SaveDatabase();
        public Task<bool> IsMusicianHasTracks(int id);
    }
}