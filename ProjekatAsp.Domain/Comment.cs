﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatAsp.Domain
{
    public class Comment : Entity
    {

        public string Title { get; set; }
        public string Comments { get; set; }
        public int? Parent_comment_id { get; set; }

        public int Product_id { get; set; }
        public int User_id { get; set; }
        public User User { get; set; }
        public Comment Parent_comment { get; set; }
        public ICollection<Comment> Child_comments { get; set; } = new List<Comment>();
        public Product Product { get; set; }

    }
}
