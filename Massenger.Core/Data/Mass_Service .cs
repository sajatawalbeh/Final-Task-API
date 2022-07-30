using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Massenger.Core.Data
{
    public class Mass_Service
    {
        [Key]
        public int serviceid { get; set; }
        public string serviceName { get; set; }
        public decimal price { get; set; }
        public int categoryid { get; set; }
        [ForeignKey("categoryid")]
        public virtual Mass_category category { get; set; }

    }
}
