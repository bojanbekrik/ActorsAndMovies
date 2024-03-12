using ActorsAndMovies.Interfaces;
using ActorsAndMovies.Models;
using Microsoft.EntityFrameworkCore;

namespace ActorsAndMovies.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly ApplicationDbContext context;

        public AddressRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Address>> GetAllAddressesAsync()
        {
            return await context.Addresses.OrderBy(a => a.Id).ToListAsync();
        }

        public async Task<Address> GetAddressByIdAsync(int id)
        {
            var address = await context.Addresses.FirstOrDefaultAsync(a => a.Id == id);
            if (address == null)
            {
                throw new ArgumentException("Address with that id can not be found");
            }
            
            return address;
        }

        public async Task<int> AddAddressAsync(Address address)
        {
            context.Addresses.Add(address);
            return await context.SaveChangesAsync();
        }

        public async Task<int> UpdateAddressAsync(Address address)
        {
            context.Addresses.Update(address);
            return await context.SaveChangesAsync();
        }

        public async Task<int> DeleteAddressAsync(int id)
        {
            var addressToDelete = await context.Addresses.FirstOrDefaultAsync(address => address.Id == id);
            if (addressToDelete == null) 
            {
                throw new ArgumentException("Address with that id can not be found");
            }

            context.Remove(addressToDelete);
            return await context.SaveChangesAsync();
        }
    }
}
