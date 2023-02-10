using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP3
{
    class MP3SongList : MP3Song
    {
        public void Ballad()
        {
            title = "발라드";
            name = "슬픈노래";
            year = 2012;
            style = "엉엉";

            Console.WriteLine($"장르 : {0} 제목 : {1} 스타일 : {2} 출시연도 : {3} ", title, name, style, year);
        }

        public void Rap()
        {
            title = "랩";
            name = "빠른노래";
            year = 2010;
            style = "욥욥";

            Console.WriteLine($"장르 : {0} 제목 : {1} 스타일 : {2} 출시연도 : {3} ", title, name, style, year);
        }
        
        public void New()
        {
            title = "신곡";
            name = "인기노래";
            year = 2023;
            style = "통통";

            Console.WriteLine($"장르 : {0} 제목 : {1} 스타일 : {2} 출시연도 : {3} ", title, name, style, year);
        }
    }
}
