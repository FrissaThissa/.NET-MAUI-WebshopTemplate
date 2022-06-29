using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebshopTemplate.Models
{
    public class Image
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public string OriginalFileName { get; set; }
        [JsonIgnore]
        public string FullPath { get; set; }
    }
}
