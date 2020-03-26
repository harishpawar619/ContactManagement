using EmployeeManagement.Repository.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagement.Repository
{
	public interface IContactRepository
	{
		Task<List<Contact>> GetContacts();
		Task<Contact> GetContact(int? contactId);

		Task<int> AddContact(Contact contact);

		Task<int> DeleteContact(int? contactId);

		Task UpdateContact(Contact contact);
	}
}
