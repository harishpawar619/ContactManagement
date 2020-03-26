using EmployeeManagement.Repository;
using EmployeeManagement.Repository.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContactManagement.BusinessManager
{
	public class ContactManager : IContactManager
	{
		// GET api/values
		IContactRepository contactRepository;
		//IMapper _iMapper;
		public ContactManager(IContactRepository _contactRepository)
		{
			contactRepository = _contactRepository;
		}
		public async Task<int> AddContact(Contact contactModel)
		{
			
			return  await contactRepository.AddContact(contactModel);
		}

		public async Task<int> DeleteContact(int? contactId)
		{
			return await contactRepository.DeleteContact(contactId);
		}

		public async Task<Contact> GetContact(int? contactId)
		{
			return await contactRepository.GetContact(contactId);
		}

		public async Task<List<Contact>> GetContacts()
		{
			return await contactRepository.GetContacts();
		}

		public async Task UpdateContact(Contact contact)
		{
			 await contactRepository.UpdateContact(contact);
		}
	}
}
