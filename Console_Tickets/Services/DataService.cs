
using Console_Tickets.Contexts;
using Console_Tickets.Models;
using Console_Tickets.Models.Entitites;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace Console_Tickets.Services;

internal class DataService
{
    private static DataContext _context = new DataContext();

    public static async Task CreateAsync(Errand entity)
    {

        var _ticketEntity = new TicketEntity()
        {
            Title= entity.Title,
            Description= entity.Description,
            Status= entity.Status,
            Created= entity.Created
        };

        var _customerEntity = await _context.Customers.FirstOrDefaultAsync(x => x.FirstName == entity.FirstName && x.LastName == entity.LastName && x.PhoneNumber == entity.PhoneNumber);
        if (_customerEntity != null)
            _ticketEntity.CustomerId = _customerEntity.CustomerId;
        else
            _ticketEntity.Customer = new CustomerEntity()
            {
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Email = entity.Email,
                PhoneNumber = entity.PhoneNumber,
            };
        _context.Add(_ticketEntity);
        await _context.SaveChangesAsync();
    }
    
    
    public static async Task<IEnumerable<Errand>> GetAllAsync()
    {
        var _errands = new List<Errand>();

        foreach (var _errand in await _context.Tickets.Include(x => x.Customer).ToListAsync())
            _errands.Add(new Errand
            {
                CustomerId = _errand.CustomerId,
                FirstName = _errand.Customer.FirstName,
                LastName = _errand.Customer.LastName,
                Email = _errand.Customer.Email,
                PhoneNumber = _errand.Customer.PhoneNumber,
                Title = _errand.Title,
                Description = _errand.Description,
                Created = _errand.Created,
                Status = _errand.Status
            });
            return _errands;      
    }
    
    
    
    public static async Task<Errand> GetOneAsync(int id)
    {
        var _errand = await _context.Tickets.Include(x => x.Customer).FirstOrDefaultAsync(x => x.CustomerId == id);
        if (_errand != null)
            return new Errand
            {
                CustomerId = _errand.CustomerId,
                FirstName = _errand.Customer.FirstName,
                LastName = _errand.Customer.LastName,
                Email = _errand.Customer.Email,
                PhoneNumber = _errand.Customer.PhoneNumber,
                Title = _errand.Title,
                Description = _errand.Description,
                Created = _errand.Created,
                Status = _errand.Status

            };
        else
            return null!;
    }

    public static async Task UpdateAsync(Errand errand)
    {
        var _ticketEntity = await _context.Tickets.Include(x => x.Customer).FirstOrDefaultAsync(x => x.CustomerId == errand.CustomerId);
        if(_ticketEntity != null)
        {
            if(!string.IsNullOrEmpty(_ticketEntity.Title))
                _ticketEntity.Title = errand.Title;

            if (!string.IsNullOrEmpty(_ticketEntity.Description))
                _ticketEntity.Description = errand.Description;

            if (!string.IsNullOrEmpty(_ticketEntity.Status))
                _ticketEntity.Status = errand.Status;

            if (!string.IsNullOrEmpty(errand.FirstName) || !string.IsNullOrEmpty(errand.LastName) || !string.IsNullOrEmpty(errand.Email))
            {
                var _customerEntity = await _context.Customers.FirstOrDefaultAsync(x => x.FirstName == errand.FirstName &&  x.LastName == errand.LastName && x.Email == errand.Email);
                if (_customerEntity != null)
                    _ticketEntity.CustomerId = _customerEntity.CustomerId;
                else
                    _ticketEntity.Customer = new CustomerEntity
                    {
                        FirstName = errand.FirstName,
                        LastName = errand.LastName,
                        Email = errand.Email,
                        PhoneNumber = errand.PhoneNumber
                    };
            }
            _context.Update(_ticketEntity);
            await _context.SaveChangesAsync();
        }
    }

    public static async Task DeleteAsync(int id)
    {
        var _errand = await _context.Tickets.Include(x => x.Customer).FirstOrDefaultAsync(x => x.CustomerId == id);
        if (_errand != null)
        {
            _context.Remove(_errand);
            await _context.SaveChangesAsync();
        }
    }
}
