using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace lab9._3
{
    public class SongCollection
    {
        public List<Song> Songs { get; set; } = new();

        public void AddSong(Song song) => Songs.Add(song);

        public bool RemoveSong(string title)
        {
            var song = Songs.FirstOrDefault(s => s.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
            if (song != null)
            {
                Songs.Remove(song);
                return true;
            }
            return false;
        }

        public bool EditSong(string title, Song newSong)
        {
            var index = Songs.FindIndex(s => s.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
            if (index != -1)
            {
                Songs[index] = newSong;
                return true;
            }
            return false;
        }

        public List<Song> SearchByPerformer(string performer)
        {
            return Songs.Where(s => s.Performers.Any(p => p.Equals(performer, StringComparison.OrdinalIgnoreCase))).ToList();
        }

        public List<Song> Search(Func<Song, bool> predicate)
        {
            return Songs.Where(predicate).ToList();
        }

        public void SaveToFile(string filePath)
        {
            var json = JsonSerializer.Serialize(Songs, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }

        public void LoadFromFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                var json = File.ReadAllText(filePath);
                Songs = JsonSerializer.Deserialize<List<Song>>(json) ?? new();
            }
        }
    }
}
