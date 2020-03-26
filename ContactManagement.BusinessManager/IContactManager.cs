using EmployeeManagement.Repository.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContactManagement.BusinessManager
{
	public interface IContactManager
	{
		Task<List<Contact>> GetContacts();
		Task<Contact> GetContact(int? contactId);

		Task<int> AddContact(Contact contactModel);

		Task<int> DeleteContact(int? contactId);

		Task  UpdateContact(Contact contact);
	}
}
