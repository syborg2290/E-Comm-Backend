namespace backend.Services;

using AutoMapper;
using backend.Entities;
using backend.Helpers;
using backend.Models.Item;


public interface IItemService
{

    IEnumerable<Item> GetAll();
    Item GetById(int id);
    Item Create(CreateRequestItem model);
    void Delete(int id);
}

public class ItemService : IItemService
{
    private DataContext _context;
    private readonly IMapper _mapper;
    public readonly IConfiguration configuration;

    public ItemService(
        DataContext context,
        IConfiguration Configuration,
        IMapper mapper
        )
    {
        _context = context;
        _mapper = mapper;
        configuration = Configuration;
    }


    public IEnumerable<Item> GetAll()
    {
        try
        {
            return _context.Item;
        }
        catch (System.Exception)
        {

            throw;
        }

    }

    public Item GetById(int id)
    {
        try
        {
            return GetItem(id);
        }
        catch (System.Exception)
        {

            throw;
        }

    }

    public Item Create(CreateRequestItem model)
    {
        try
        {
            // map model to new item object
            var item = _mapper.Map<Item>(model);


            // save item
            _context.Item.Add(item);
            _context.SaveChanges();
            return item;
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
            var item = GetItem(id);
            _context.Item.Remove(item);
            _context.SaveChanges();
        }
        catch (System.Exception)
        {

            throw;
        }

    }

    // helper methods

    private Item GetItem(int id)
    {
        try
        {
            var item = _context.Item.Find(id);
            if (item == null) throw new KeyNotFoundException("Item not found");
            return item;
        }
        catch (System.Exception)
        {

            throw;
        }

    }
}