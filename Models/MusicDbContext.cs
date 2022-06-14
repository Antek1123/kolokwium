using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace kolokwium.Models
{
    public class MusicDbContext : DbContext
    {
        public DbSet<Musician> Musicians { get; set; }
        public DbSet<Musician_Track> Musician_Tracks { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<Album> Albums  { get; set; }
        public DbSet<MusicLabel> MusicLabels { get; set; }
        public MusicDbContext(DbContextOptions options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            var musicians = new List<Musician> {
                new Musician {
                    IdMusician = 1,
                    FirstName = "slawek",
                    LastName = "toronto",
                    Nickname = "gruby"
                },

                new Musician {
                    IdMusician = 2,
                    FirstName = "tomek",
                    LastName = "monako",
                    Nickname = "chudy"
                }
            };

            var tracks = new List<Track> {
                new Track {
                    IdTrack = 1,
                    TrackName = "lala",
                    Duration = 1.43f,
                    IdMusicAlbum = 1
                },

                new Track {
                    IdTrack = 2,
                    TrackName = "lulu",
                    Duration = 1.23f,
                    IdMusicAlbum = 2
                }
            };

            var muscian_tracs = new List<Musician_Track> {
                new Musician_Track {
                    IdMusician = 1,
                    IdTrack = 1,
                },

                new Musician_Track {
                    IdMusician = 2,
                    IdTrack = 2,
                }
            };

            var albums = new List<Album> {
                new Album {
                    IdAlbum = 1,
                    AlbumName = "alhija0",
                    PublishDate = DateTime.Now,
                    IdMusicLabel = 1
                },

                new Album {
                    IdAlbum = 2,
                    AlbumName = "akjrepgiE",
                    PublishDate = DateTime.Now,
                    IdMusicLabel = 2
                }
            };

            var musiclabels = new List<MusicLabel> {
                new MusicLabel {
                    IdMusicLabel = 1,
                    Name = "lubisie"
                },

                new MusicLabel {
                    IdMusicLabel = 2,
                    Name = "pierniczki"
                }
            };


            modelBuilder.Entity<Musician>(e => {
                e.HasKey(e => e.IdMusician);
                e.Property(e => e.FirstName).HasMaxLength(30).IsRequired();
                e.Property(e => e.LastName).HasMaxLength(50).IsRequired();
                e.Property(e => e.Nickname).HasMaxLength(20).IsRequired();

                e.HasData(musicians);

                e.ToTable("Musician");
            });

            modelBuilder.Entity<Track>(e => {
                e.HasKey(e => e.IdTrack);
                e.Property(e => e.TrackName).HasMaxLength(20).IsRequired();
                e.Property(e => e.Duration).IsRequired();

                e.HasOne(e => e.Album)
                .WithMany(e => e.Tracks)
                .HasForeignKey(e => e.IdMusicAlbum)
                .OnDelete(DeleteBehavior.Cascade);

                e.HasData(tracks);

                e.ToTable("Track");
            });

            modelBuilder.Entity<Musician_Track>(e => {
                e.HasKey(e => new {
                    e.IdTrack,
                    e.IdMusician
                });

                e.HasOne(e => e.Track)
                .WithMany(e => e.Musician_Tracks)
                .HasForeignKey(e => e.IdTrack)
                .OnDelete(DeleteBehavior.Cascade);

                e.HasOne(e => e.Musician)
                .WithMany(e => e.Musician_Tracks)
                .HasForeignKey(e => e.IdMusician)
                .OnDelete(DeleteBehavior.Cascade);

                e.HasData(muscian_tracs);

                e.ToTable("Musician_Track");
            });

            modelBuilder.Entity<Album>(e => {
                e.HasKey(e => e.IdAlbum);
                e.Property(e => e.AlbumName).HasMaxLength(30).IsRequired();
                e.Property(e => e.PublishDate).IsRequired();

                e.HasOne(e => e.MusicLabel)
                .WithMany(e => e.Albums)
                .HasForeignKey(e => e.IdMusicLabel)
                .OnDelete(DeleteBehavior.Cascade);

                e.HasData(albums);
                
                e.ToTable("Album");
            });

            modelBuilder.Entity<MusicLabel>(e => {
                e.HasKey(e => e.IdMusicLabel);
                e.Property(e => e.Name).HasMaxLength(50).IsRequired();

                e.HasData(musiclabels);

                e.ToTable("MusicLabel");
            });
        
        }

    }
}