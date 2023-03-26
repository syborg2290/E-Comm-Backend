namespace backend.Services;

using AutoMapper;
using backend.Entities;
using backend.Helpers;
using backend.Models.OrderItem;


public interface IOrderItemService
{

    IEnumerable<OrderItem> GetAll();
    OrderItem GetById(int id);
    OrderItem Create(CreateRequestOrderItem model);
    void Delete(int id);
}

public class OrderItemService : IOrderItemService
{
    private DataContext _context;
    private readonly IMapper _mapper;
    public readonly IConfiguration configuration;

    public OrderItemService(
        DataContext context,
        IConfiguration Configuration,
        IMapper mapper
        )
    {
        _context = context;
        _mapper = mapper;
        configuration = Configuration;
    }


    public IEnumerable<OrderItem> GetAll()
    {
        try
        {
            return _context.OrderItem;
        }
        catch (System.Exception)
        {

            throw;
        }

    }

    public OrderItem GetById(int id)
    {
        try
        {
            return GetOrderItem(id);
        }
        catch (System.Exception)
        {

            throw;
        }

    }

    public OrderItem Create(CreateRequestOrderItem model)
    {
        try
        {
            // map model to new order item object
            var orderItem = _mapper.Map<OrderItem>(model);


            // save order item
            _context.OrderItem.Add(orderItem);
            _context.SaveChanges();
            return orderItem;
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
            var orderItem = GetOrderItem(id);
            _context.OrderItem.Remove(orderItem);
            _context.SaveChanges();
        }
        catch (System.Exception)
        {

            throw;
        }

    }

    // helper methods

    private OrderItem GetOrderItem(int id)
    {
        try
        {
            var orderItem = _context.OrderItem.Find(id);
            if (orderItem == null) throw new KeyNotFoundException("Order item not found");
            return orderItem;
        }
        catch (System.Exception)
        {

            throw;
        }

    }
}