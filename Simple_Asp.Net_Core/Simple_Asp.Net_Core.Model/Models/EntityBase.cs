﻿namespace Simple_Asp.Net_Core.Models
{
    public class EntityBase
    {
        public Guid Id { get; set; }

        public string? Inputter { get; set; }

        public DateTime InputDate { get; set; }

        public string? Modifier { get; set; }

        public DateTime ModifyDate { get; set; }

        public DeleteTag DeleteTag { get; set; }

        public string? Deleter { get; set; }

        public DateTime DeleteDate { get; set; }

    }

    public enum DeleteTag
    {
        None = 0,
        NotDeleted = 1,
        Deleted = 2,
    }
}