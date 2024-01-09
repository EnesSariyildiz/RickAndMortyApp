using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace RickAndMortyApp.Data.Entities
{
    public class Episode
    {
        [Key] 
        public int Id { get; set; }
        public string Name { get; set; }
        public string EpisodeCode { get; set; }

    }
}
