using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;

namespace dotnetapi.Models
{
    public class Author : ModelBase
    {
        [BsonElement("Name")]
        [Required]
        public string Name { get; set; }

        public string Bio { get; set; }

        public string ImgUrl { get; set; }

        public string ProfileUrl { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
