﻿namespace Simple_Asp.Net_Core.Model.Models
{
    public class Comment
    {
        public Guid Id { get; set; }

        public string Content { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime UpdateTime { get; set; }

        public Guid UserId { get; set; }

        public User User { get; set; }

        public Guid BlogId { get; set; }
    }
}
