using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegracaoSpotify_LetraMusicaApi.Modelos
{
    public class Lyrics
    {
        public int lyrics_id { get; set; }
        public int @explicit { get; set; }
        public string lyrics_body { get; set; }
        public string script_tracking_url { get; set; }
        public string pixel_tracking_url { get; set; }
        public string lyrics_copyright { get; set; }
        public DateTime updated_time { get; set; }
    }
}
