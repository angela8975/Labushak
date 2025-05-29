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
        public Song[] Songs { get; set; } = new();

        public void AddSong(Song song) {
            int newindex = Songs.Length;
            Array.Resize(ref Songs, newindex + 1)
                Songs[newindex] = song;
        }

        public bool RemoveSong(string title)
        {
            int index = Array.FindIndex(Songs, s => s.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
            if (index != -1)
            {
                Songs = Songs.Where((_,i)=>i != index).Toarrat();
                return true;
            }
            return false;
        }

        public bool EditSong(string title, Song newSong)
        {
            int index = Array.FindIndex(Songs, s => s.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
            if (index != -1)
            {
                Songs[index] = newSong;
                return true;
            }
            return false;
        }

        public Song[] SearchByPerformer(string performer)
        {
            return Songs.Where(s => s.Performers.Any(p => p.Equals(performer, StringComparison.OrdinalIgnoreCase))).ToArray();
        }

        public Song[] Search(Func<Song, bool> predicate)
        {
            return Songs.Where(predicate).ToArray();
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
                Songs = JsonSerializer.Deserialize<Song[]>(json) ?? new Song[0];
            }
        }
    }
}
