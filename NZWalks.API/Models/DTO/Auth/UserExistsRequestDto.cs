﻿using System.ComponentModel.DataAnnotations;

namespace NZWalks.API.Models.DTO.Auth
{
    public class UserExistsRequestDto
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Username { get; set; }
    }
}