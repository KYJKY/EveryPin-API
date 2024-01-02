﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.Models
{
    public class Comment
    {
        [Column("CommentId")]
        public Guid Id { get; set; }
        public string? CommentMessage { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;

        public Post Post { get; set; } = null!;
        public Guid PostId { get; set; }
        public User User { get; set; } = null!;
        public Guid UserId { get; set; }
    }
}
