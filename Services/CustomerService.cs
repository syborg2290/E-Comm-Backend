namespace backend.Services;

using AutoMapper;
using backend.Entities;
using backend.Helpers;
using backend.Models.Customer;
using backend.Models.Address;


public interface ICustomerService
{

    IEnumerable<Customer> GetAll();
    Customer GetById(int id);
    Customer GetByUserId(int id);
    void Create(CreateRequestCustomer model, string token);
    void Delete(int id);
}

public class CustomerService : ICustomerService
{
    private DataContext _context;
    private readonly IMapper _mapper;
    public readonly IConfiguration configuration;

    private IAddressService _addressService;

    private ICommonService _commonService;

    public CustomerService(
        DataContext context,
        IConfiguration Configuration,
        IMapper mapper,
        IAddressService addressService,
        ICommonService commonService
        )
    {
        _context = context;
        _mapper = mapper;
        configuration = Configuration;
        _addressService = addressService;
        _commonService = commonService;
    }


    public IEnumerable<Customer> GetAll()
    {
        try
        {
            return _context.Customers;
        }
        catch (System.Exception)
        {

            throw;
        }

    }

    public Customer GetById(int id)
    {
        try
        {
            return getCustomer(id);
        }
        catch (System.Exception)
        {

            throw;
        }

    }

    public Customer GetByUserId(int id)
    {
        try
        {
            return getCustomerByUserId(id);
        }
        catch (System.Exception)
        {

            throw;
        }

    }


    public void Create(CreateRequestCustomer model, string token)
    {
        try
        {
            // validate
            if (_context.Customers.Any(x => x.Email == model.Email))
                throw new AppException("Customer with the email '" + model.Email + "' already exists");


            // create billing address record
            CreateRequestAddress billingModel = new CreateRequestAddress();
            billingModel.Street_Address = model.Street_Address_billing;
            billingModel.City = model.City_billing;
            billingModel.State = model.State_billing;
            billingModel.Zip_Code = model.Zip_Code_billing;
            billingModel.Country = model.Country_billing;

            Address _address_billing = _addressService.Create(billingModel);

            // create shipping address record
            CreateRequestAddress shippingModel = new CreateRequestAddress(); ;
            shippingModel.Street_Address = model.Street_Address_shipping;
            shippingModel.City = model.City_shipping;
            shippingModel.State = model.State_shipping;
            shippingModel.Zip_Code = model.Zip_Code_shipping;
            shippingModel.Country = model.Country_shipping;

            Address _address_shipping = _addressService.Create(shippingModel);

            // map model to new customer object
            CreateCustomer customerModel = new CreateCustomer();

            //Decode token and get userId
            string userId = _commonService.DecodeToken(token);

            customerModel.UserId = Convert.ToInt32(userId);
            customerModel.FirstName = model.FirstName;
            customerModel.LastName = model.LastName; // Set LastName instead of FirstName
            customerModel.Email = model.Email;
            customerModel.Phone_Number = model.Phone_Number;
            customerModel.Billing_Address_ID = _address_billing.Id;
            customerModel.Shipping_Address_ID = _address_shipping.Id;

            var customer = _mapper.Map<Customer>(customerModel);


            // save customer
            _context.Customers.Add(customer);
            _context.SaveChanges();
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
            var customer = getCustomer(id);
            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }
        catch (System.Exception)
        {

            throw;
        }

    }

    // helper methods

    private Customer getCustomer(int id)
    {
        try
        {
            var customer = _context.Customers.Find(id);
            if (customer == null) throw new KeyNotFoundException("Customer not found");
            return customer;
        }
        catch (System.Exception)
        {

            throw;
        }

    }

    private Customer getCustomerByUserId(int id)
    {
        try
        {
            var customer = _context.Customers.Where(a => a.UserId == id).ToList()[0];
            if (customer == null) throw new KeyNotFoundException("Customer not found");
            return customer;
        }
        catch (System.Exception)
        {

            throw;
        }

    }
}