namespace backend.Services;

using AutoMapper;
using backend.Entities;
using backend.Helpers;
using backend.Models.Address;


public interface IAddressService
{

    IEnumerable<Address> GetAll();
    Address GetById(int id);
    Address Create(CreateRequestAddress model);
    void Delete(int id);
}

public class AddressService : IAddressService
{
    private DataContext _context;
    private readonly IMapper _mapper;
    public readonly IConfiguration configuration;

    public AddressService(
        DataContext context,
        IConfiguration Configuration,
        IMapper mapper
        )
    {
        _context = context;
        _mapper = mapper;
        configuration = Configuration;
    }


    public IEnumerable<Address> GetAll()
    {
        try
        {
            return _context.Address;
        }
        catch (System.Exception)
        {

            throw;
        }

    }

    public Address GetById(int id)
    {
        try
        {
            return getAddress(id);
        }
        catch (System.Exception)
        {

            throw;
        }

    }

    public Address Create(CreateRequestAddress model)
    {
        try
        {
            // map model to new address object
            var address = _mapper.Map<Address>(model);


            // save address
            _context.Address.Add(address);
            _context.SaveChanges();
            return address;
        }
        catch (System.Exception)
        {

            throw;
        }


    }


    public void Delete(int id)
    {
        try
        {
            var address = getAddress(id);
            _context.Address.Remove(address);
            _context.SaveChanges();
        }
        catch (System.Exception)
        {

            throw;
        }

    }

    // helper methods

    private Address getAddress(int id)
    {
        try
        {
            var address = _context.Address.Find(id);
            if (address == null) throw new KeyNotFoundException("Address not found");
            return address;
        }
        catch (System.Exception)
        {

            throw;
        }

    }
}