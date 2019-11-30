using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace dotnetapi.Models
{
    public class Book : ModelBase
    {
        [BsonElement("Name")]
        [Required]
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Category { get; set; }

        public string Description { get; set; }

        public string Isbn { get; set; }

        public virtual ICollection<Author> Authors { get; set; }
    }
}
