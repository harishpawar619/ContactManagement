using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Repository
{
	public class ContactRepository : IContactRepository
	{
		ContactDBContext db;
		public ContactRepository(ContactDBContext _db)
		{
			db = _db;
		}
		public async Task<int> AddContact(Contact contact)
		{
			if (db != null)
			{
				await db.Contact.AddAsync(contact);
				await db.SaveChangesAsync();

				return contact.ContactId;
			}

			return 0;
		}

		public async Task<int> DeleteContact(int? contactId)
		{
			int result = 0;

			if (db != null)
			{
				//Find the post for specific post id
				var post = await db.Contact.FirstOrDefaultAsync(x => x.ContactId == contactId);

				if (post != null)
				{
					//Delete that post
					db.Contact.Remove(post);

					//Commit the transaction
					result = await db.SaveChangesAsync();
				}
				return result;
			}

			return result;
		}

		public async Task<Contact> GetContact(int? contactId)
		{
			if (db != null)
			{
				return await  db.Contact.FirstOrDefaultAsync(x => x.ContactId == contactId);
			}

			return null;
		}

		public async Task<List<Contact>> GetContacts()
		{
			if (db != null)
			{
				return await db.Contact.ToListAsync();
			}

			return null;
		}

		public async Task UpdateContact(Contact contact)
		{
			if (db != null)
			{
				//Delete that post
				db.Contact.Update(contact);

				//Commit the transaction
				await db.SaveChangesAsync();
			}
		}
	}
}
