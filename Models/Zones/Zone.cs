﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using xZoneAPI.Models.Posts;

namespace xZoneAPI.Models.Zones
{
    public class Zone
    {
        [Key]
        public int Id{get; set;}

        public string Name { get; set; }
        public string Description {get; set;}
        public ICollection<Post> Posts {get; set;}
        public ICollection<ZoneMember> ZoneMembers { get; set; }
        public enum PrivacyType{ Private, Public }
        public PrivacyType Privacy { get; set; } 
        public ICollection<ZoneSkill> ZoneSkills { get; set; }
        public string JoinCode { get; set; } = "";
}
}