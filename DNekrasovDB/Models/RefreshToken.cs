﻿
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;


namespace DNekrasovDB.Models
{
    
    public class RefreshToken
    {

        [Key]
        [JsonIgnore]
        public Guid Id { get; set; }

        public string Token { get; set; }

        public DateTime Expires { get; set; }

        public bool IsExpired => DateTime.UtcNow >= Expires;

        public DateTime Created { get; set; }

        public DateTime Revoked { get; set; }

        public string ReplacedByToken { get; set; }

        public bool IsActive => Revoked == null && !IsExpired;

        public Guid UserId { get; set; }

        public User User { get; set; }

        //добавить в базу
    }
}
