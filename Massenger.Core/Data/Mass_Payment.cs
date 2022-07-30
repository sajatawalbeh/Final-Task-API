using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Massenger.Core.Data
{
	public class Mass_Payment
	{
		[Key]
		public int id { get; set; }
		public string cardNumber { get; set; }
		public int amount { get; set; }
	}
}
