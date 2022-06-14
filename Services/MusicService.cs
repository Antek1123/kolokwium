using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kolokwium.Models;
using Microsoft.EntityFrameworkCore;

namespace kolokwium.Services
{
    public class MusicService : IMusicService
    {
        private readonly MusicDbContext _context;
        public MusicService(MusicDbContext context) 
        {
            _context = context;
        }

        public async Task DeleteMusician(int id)
        {
            var musician = new Musician {
                IdMusician = id
            };

            var entry = _context.Entry(musician);
            entry.State  = EntityState.Deleted;
            await SaveDatabase();
        }

        public async Task<List<Models.DTOs.Musician>> GetMusician(int id)
        {
            return await _context.Musicians.Where(e => e.IdMusician == id).Select(e => new Models.DTOs.Musician {
                FirstName = e.FirstName,
                LastName = e.LastName,
                Nickname = e.Nickname,
                Tracks = _context.Musician_Tracks.Where(f => f.IdMusician == id).Select(f => new Models.DTOs.MusicianTrack {
                    IdTrack = f.IdTrack,
                    Track_info = _context.Tracks.Where(g => g.IdTrack == f.IdTrack).Select(g => new Models.DTOs.Track{
                        TrackName = g.TrackName,
                        Duration = g.Duration,
                        IdMusicAlbum = g.IdMusicAlbum
                    }).FirstOrDefault()
                }).ToList()
            }).ToListAsync();
        }

        public async Task<bool> IsMusicianExists(int id)
        {
            return await _context.Musicians.AnyAsync(e => e.IdMusician == id);
        }

        public Task<bool> IsMusicianHasTracks(int id)
        {
            return _context.Musician_Tracks.AnyAsync(e => e.IdMusician == id);
        }

        public Task SaveDatabase()
        {
            return _context.SaveChangesAsync();
        }
    }
}