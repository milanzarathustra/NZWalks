﻿namespace NZWalks.API.Models.DTO.Regions.Requests
{
    public class RegionDto
    {
        public Guid Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string? RegionImageUrl { get; set; }
    }
}
