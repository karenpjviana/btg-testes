using btg_testes_auto;
using btg_testes_auto.Order;
using btg_testes_auto.PlaylistSongs;
using FluentAssertions;
using NSubstitute;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btg_test.PaylistsSongsTest
{
    public class PlaylistServiceTest
    {
        private readonly IPlaylistValidationService _mockPlaylistValidationService;
        private PlaylistService _service;

        public PlaylistServiceTest()
        {
            _mockPlaylistValidationService = Substitute.For<IPlaylistValidationService>();
            _service = new(_mockPlaylistValidationService);
        }

        [Fact]
        public void AddSongToPlaylist_MusicaValida_RetornaTrue()
        {
            // Arrange
            Playlist playlist = new Playlist { Songs = new List<Song>(), MaxSongs = 5 };

            _mockPlaylistValidationService.CanAddSongToPlaylist(playlist, Arg.Any<Song>())
                .Returns(true);

            // Act
            bool resultado = _service.AddSongToPlaylist(playlist, new Song { Title = "Fur Elise", Artist = "Beethoven" });

            // Assert
            Assert.True(resultado);
        }

        [Fact]
        public void AddSongToPlaylist_MusicaInvalida_RetornaFalse()
        {
            // Arrange
            Playlist playlist = new() { Songs = new List<Song>(), MaxSongs = 5 };

            _mockPlaylistValidationService.CanAddSongToPlaylist(playlist, Arg.Any<Song>()).Returns(false);

            // Act
            bool resultado = _service.AddSongToPlaylist(playlist, new Song { Title = "Fur Elise", Artist = "Beethoven" });

            // Assert
            Assert.False(resultado);
        }

        [Fact]
        public void AddSongsToPlaylist_MusicasValidas_AdicionaNaPlaylist()
        {
            // Arrange
            Playlist playlist = new Playlist { Songs = new List<Song>(), MaxSongs = 5 };
            // Arrange
            List<Song> songs = new List<Song>()
            {
               new Song { Title = "Fur Elise", Artist = "Beethoven" },
               new Song { Title = "Moonlight", Artist = "Beethoven" },
            };

            _mockPlaylistValidationService.CanAddSongToPlaylist(playlist, Arg.Any<Song>()).Returns(true);

            // Act
            _service.AddSongsToPlaylist(playlist, songs);

            // Assert
            Assert.Equal(2, playlist.Songs.Count);
        }
    }
}
