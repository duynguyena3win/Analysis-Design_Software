using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WAO_Player.Class
{
    public class Artist
    {
        public string Name_Artist;
        public List<Song> List_Song_Artist;

        public Artist(string name, IEnumerable<Song> L_S)
        {
            Name_Artist = name;
            List_Song_Artist = new List<Song>();
            foreach (Song x in L_S)
            {
                List_Song_Artist.Add(x);
            }
        }

        public Artist()
        {
            List_Song_Artist = new List<Song>();
        }
    }
}
