﻿using System.ComponentModel.DataAnnotations;

namespace App.API.Models
{
    public class ConfirmModel
    {
        [Required]
        public int OnsiteID { get; set; }
        public int Status { get; set; }
        public string Detail { get; set; } = string.Empty;
        public string Reason { get; set; } = string.Empty;
    }
}
