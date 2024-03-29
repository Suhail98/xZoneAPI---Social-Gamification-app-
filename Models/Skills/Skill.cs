﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using xZoneAPI.Models.Accounts;

namespace xZoneAPI.Models.Skills
{
    public class Skill
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public ICollection<AccountSkill> AccountsSkill { get; set; }
    }
}
