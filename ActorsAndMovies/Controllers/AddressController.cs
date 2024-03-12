using ActorsAndMovies.Interfaces;
using ActorsAndMovies.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ActorsAndMovies.Controllers
{

    [ApiController]
    [Route("/addresses")]
    public class AddressController : ControllerBase
    {
        private readonly IAddressRepository addressRepository;

        public AddressController(IAddressRepository addressRepository)
        {
            this.addressRepository = addressRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var allAddresses = await addressRepository.GetAllAddressesAsync();
            return new JsonResult(allAddresses);
        }

        [HttpGet("{id}/details")]
        public async Task<IActionResult> Details(int id)
        {
            var address = await addressRepository.GetAddressByIdAsync(id);
            return new JsonResult(address);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Address address)
        {
            if (address == null)
            {
                return NotFound();
            }
            
            await addressRepository.AddAddressAsync(address);
            return Ok(address);
        }

        [HttpPut("{id}/update")]
        public async Task<IActionResult> Update(Address address)
        {
            var addressToUpdate = await addressRepository.GetAddressByIdAsync(address.Id);
            if (addressToUpdate == null)
            {
                return NotFound();
            }

            await addressRepository.UpdateAddressAsync(addressToUpdate);
            return Ok(addressToUpdate);
        }

        [HttpDelete("{id}/delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var addressToDelete = await addressRepository.GetAddressByIdAsync(id);
            if (addressToDelete == null)
            {
                return NotFound();
            }

            await addressRepository.DeleteAddressAsync(id);
            return Ok(addressToDelete);
        }
    }
}
