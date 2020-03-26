using ContactManagement.BusinessManager;
using ContactMangement.Logger;
using EmployeeManagement.Repository.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace EmployeeManagement.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ContactController : ControllerBase
	{
		// GET api/values
		IContactManager contactManager;
		public ContactController(IContactManager _contactManager)
		{
			contactManager = _contactManager;
		}

		[HttpGet]
		[Route("GetContacts")]
		public async Task<IActionResult> GetContacts()
		{
			try
			{
				var contact = await contactManager.GetContacts();
				SerilogManager.Information("getting all contact details");
				if (contact == null)
				{
					return NotFound();
				}

				return Ok(contact);
			}
			catch (Exception ex)
			{
				SerilogManager.Error("Getting error in fetching contact: " + ex.Message);
				return BadRequest();
			}

		}

		

		[HttpGet]
		[Route("GetContact")]
		public async Task<IActionResult> GetContact(int? contactId)
		{
			if (contactId == null)
			{
				return BadRequest();
			}

			try
			{
				SerilogManager.Information("getting contact details for contact id" + contactId);
				var contact = await contactManager.GetContact(contactId);

				if (contact == null)
				{
					return NotFound();
				}

				return Ok(contact);
			}
			catch (Exception ex)
			{
				SerilogManager.Error("Getting error in fetching contact: " + ex.Message);
				return BadRequest();
			}
		}

		[HttpPost]
		[Route("AddContact")]
		public async Task<IActionResult> AddContact([FromBody] Contact model)
		{
			if (ModelState.IsValid)
			{
				try
				{
					SerilogManager.Information("Adding contact details for contact name" + model.FirstName);
					var contactId = await contactManager.AddContact(model);
					if (contactId > 0)
					{
						return Ok(contactId);
					}
					else
					{
						return NotFound();
					}
				}
				catch (Exception ex)
				{
					SerilogManager.Error("Getting error in adding contact: " + ex.Message);
					return BadRequest();
				}

			}

			return BadRequest();
		}

		[HttpDelete]
		[Route("DeleteContact")]
		public async Task<IActionResult> DeleteContact(int? contactId)
		{
			int result = 0;

			if (contactId == null)
			{
				return BadRequest();
			}

			try
			{
				SerilogManager.Information("deleting contact details for contact id" + contactId);
				result = await contactManager.DeleteContact(contactId);
				if (result == 0)
				{
					return NotFound();
				}
				return Ok();
			}
			catch (Exception ex)
			{
				SerilogManager.Error("Getting error in deleting contact: " + ex.Message);

				return BadRequest();
			}
		}


		[HttpPut]
		[Route("UpdateContact")]
		public async Task<IActionResult> UpdateContact([FromBody]Contact model)
		{
			if (ModelState.IsValid)
			{
				try
				{
					SerilogManager.Information("Updating contact details for contact id" + model.ContactId);
					await contactManager.UpdateContact(model);

					return Ok(model);
				}
				catch (Exception ex)
				{
					SerilogManager.Error("Getting error in updating contact: " + ex.Message);
					if (ex.GetType().FullName == "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
					{
						return NotFound();
					}

					return BadRequest();
				}
			}

			return BadRequest();
		}

	}
}
