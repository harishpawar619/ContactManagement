﻿using System;

namespace ContactManagement.Model
{
	public class ContactModel
	{
		public int ContactId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string PhoneNumber { get; set; }
		public bool? IsActive { get; set; }
	
	}
}
