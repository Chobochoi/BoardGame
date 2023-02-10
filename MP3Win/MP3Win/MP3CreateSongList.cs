using MP3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP3Win
{
    abstract class MP3CreateSongList
    {
        List<MP3SongList> songList = new List<MP3SongList>();
        public MP3CreateSongList() { }
        public List<MP3SongList> SongList { get { return songList; } }
        public abstract void CreateSongList();
    }   
}
