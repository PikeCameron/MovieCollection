﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCollection.Models
{
    public class Category
    {
        [Key]
        [Required (ErrorMessage = "Please select a valid Category")]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
