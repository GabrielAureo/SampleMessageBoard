using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SampleMessageBoard.Models
{
    public class Post
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }
        public DateTime PublishDate { get; set; }
        public string AuthorUsername { get; set; }
        //public User Author { get; set; }
        public Thread Thread { get; set; }
        public int ThreadId { get; set; }
    }
}
 