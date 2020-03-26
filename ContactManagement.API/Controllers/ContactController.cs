using ContactManagement.BusinessManager;
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
				if (contact == null)
				{
					return NotFound();
				}

				return Ok(contact);
			}
			catch (Exception)
			{
			
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
				var contact = await contactManager.GetContact(contactId);

				if (contact == null)
				{
					return NotFound();
				}

				return Ok(contact);
			}
			catch (Exception)
			{
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
				catch (Exception)
				{

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
				result = await contactManager.DeleteContact(contactId);
				if (result == 0)
				{
					return NotFound();
				}
				return Ok();
			}
			catch (Exception)
			{

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
					await contactManager.UpdateContact(model);

					return Ok();
				}
				catch (Exception ex)
				{
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
