﻿namespace NZWalks.API.Models.Shared
{
    public class Filter
    {
        public string? FilterOn { get; set; } = null;
        public string? FilterQuery { get; set; } = null;
        public string? SortBy { get; set; } = null;
        public bool IsAscending { get; set; } = true;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
