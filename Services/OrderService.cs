namespace backend.Services;

using AutoMapper;
using backend.Entities;
using backend.Helpers;
using backend.Models.Order;


public interface IOrderService
{

    IEnumerable<Order> GetAll();
    Order GetById(int id);
    Order Create(CreateRequestOrder model, string token);
    void Delete(int id);
}

public class OrderService : IOrderService
{
    private DataContext _context;
    private readonly IMapper _mapper;
    public readonly IConfiguration configuration;

    private ICommonService _commonService;

    private ICustomerService _customerService;

    public OrderService(
        DataContext context,
        IConfiguration Configuration,
        ICommonService commonService,
        ICustomerService customerService,
        IMapper mapper
        )
    {
        _context = context;
        _mapper = mapper;
        configuration = Configuration;
        _commonService = commonService;
        _customerService = customerService;
    }


    public IEnumerable<Order> GetAll()
    {
        try
        {
            return _context.Order;
        }
        catch (System.Exception)
        {

            throw;
        }

    }

    public Order GetById(int id)
    {
        try
        {
            return GetOrder(id);
        }
        catch (System.Exception)
        {

            throw;
        }

    }

    public Order Create(CreateRequestOrder model, string token)
    {
        try
        {
            //Decode token and get userId
            int userId = Convert.ToInt32(_commonService.DecodeToken(token));

            Customer customer = _customerService.GetByUserId(userId);

            // map model to new order object
            var order = _mapper.Map<Order>(model);
            order.CustomerID = customer.Id;
            order.ShippingAddressID = customer.Shipping_Address_ID;
            order.BillingAddressID = customer.Billing_Address_ID;

            // save order
            _context.Order.Add(order);
            _context.SaveChanges();
            return order;
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
            var order = GetOrder(id);
            _context.Order.Remove(order);
            _context.SaveChanges();
        }
        catch (System.Exception)
        {

            throw;
        }

    }

    // helper methods

    private Order GetOrder(int id)
    {
        try
        {
            var order = _context.Order.Find(id);
            if (order == null) throw new KeyNotFoundException("Order not found");
            return order;
        }
        catch (System.Exception)
        {

            throw;
        }

    }
}