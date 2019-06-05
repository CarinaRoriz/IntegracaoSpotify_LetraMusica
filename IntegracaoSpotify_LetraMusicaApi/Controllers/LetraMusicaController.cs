using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using IntegracaoSpotify_LetraMusicaApi.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace IntegracaoSpotify_LetraMusicaApi.Controllers
{
    [Route("v1/letrasMusica")]
    [ApiController]
    public class LetraMusicaController : ControllerBase
    {
        private string apiKeyMusixmatch = "c2341671bf5804ae9debaa0d988d4b25";

        [HttpGet]
        public async Task<ActionResult<LetrasMusicaBusca>> GetMusicaLetra(string nomeMusica, string artista)
        {
            HttpClient client = new HttpClient();

            UriBuilder builder = new UriBuilder("https://api.musixmatch.com/ws/1.1/matcher.lyrics.get");
            builder.Query = $"q_track={nomeMusica}&q_artist={artista}&apikey={apiKeyMusixmatch}";

            HttpResponseMessage resp = await client.GetAsync(builder.Uri);
            string msg = await resp.Content.ReadAsStringAsync();

           
            return JsonConvert.DeserializeObject<LetrasMusicaBusca>(msg.Replace("\n", ""));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LetrasMusicaBusca>> GetMusicaLetraPorId(string id)
        {
            HttpClient client = new HttpClient();

            UriBuilder builder = new UriBuilder("https://api.musixmatch.com/ws/1.1/track.lyrics.get");
            builder.Query = $"track_id={id}&apikey={apiKeyMusixmatch}";

            HttpResponseMessage resp = await client.GetAsync(builder.Uri);
            string msg = await resp.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<LetrasMusicaBusca>(msg.Replace("\n", ""));
        }
    }
}