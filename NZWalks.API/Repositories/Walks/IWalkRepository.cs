﻿using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories.Walks
{
    public interface IWalkRepository
    {
        Task<List<Walk>> GetAllAsync(string? filterOn = null, string? filterQuery = null, string? sortBy = null, bool isAscending = true, int pageNumber = 1, int pageSize = 1000);
        Task<Walk?> GetByIdAsync(Guid id);
        Task<Walk> CreateAsync(Walk region);
        Task<Walk?> UpdateAsync(Guid id, Walk region);
        Task<Walk?> DeleteAsync(Guid id);
    }
}
