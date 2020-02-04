using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SecretSanta.Business;
using SecretSanta.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SecretSanta.Api.Controllers
{
    [Route("api/Gift")]
    [ApiController]
    public class GiftController : ControllerBase
    {
        private IGiftService GiftService { get; }

        public GiftController(IGiftService giftService)
        {
            GiftService = giftService ?? throw new ArgumentNullException(nameof(giftService));
        }

        [HttpGet]
        public async Task<IEnumerable<Gift>> Get()
        {
            return await GiftService.FetchAllAsync();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Gift>> Get(int id)
        {
            if (await GiftService.FetchByIdAsync(id) is Gift gift)
            {
                return Ok(gift);
            } else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<Gift> Post(Gift gift)
        {
            return await GiftService.InsertAsync(gift);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Gift>> Put(int id, Gift gift)
        {
            if (await GiftService.UpdateAsync(id, gift) is Gift g)
            {
                return Ok(g);
            } else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(int id)
        {
            if (await GiftService.DeleteAsync(id) == true)
            {
                return Ok();
            } else
            {
                return NotFound();
            }
        }
    }
}