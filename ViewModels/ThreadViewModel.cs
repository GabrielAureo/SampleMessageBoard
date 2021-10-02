using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SampleMessageBoard.ViewModels
{
    public class ThreadViewModel
    {
        public string Title { get; set; }
        [DataType(DataType.MultilineText)]
        public string FirstPostContent { get; set; }
        public string Username { get; set; }
    }
}
