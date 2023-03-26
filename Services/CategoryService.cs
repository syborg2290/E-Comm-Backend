namespace backend.Services;

using AutoMapper;
using backend.Entities;
using backend.Helpers;
using backend.Models.Category;


public interface ICategoryService
{

    IEnumerable<Category> GetAll();
    Category GetById(int id);
    Category Create(CreateRequestCategory model);
    void Delete(int id);
}

public class CategoryService : ICategoryService
{
    private DataContext _context;
    private readonly IMapper _mapper;
    public readonly IConfiguration configuration;

    public CategoryService(
        DataContext context,
        IConfiguration Configuration,
        IMapper mapper
        )
    {
        _context = context;
        _mapper = mapper;
        configuration = Configuration;
    }


    public IEnumerable<Category> GetAll()
    {
        try
        {
            return _context.Category;
        }
        catch (System.Exception)
        {

            throw;
        }

    }

    public Category GetById(int id)
    {
        try
        {
            return getCategory(id);
        }
        catch (System.Exception)
        {

            throw;
        }

    }

    public Category Create(CreateRequestCategory model)
    {
        try
        {
            // map model to new category object
            var category = _mapper.Map<Category>(model);


            // save category
            _context.Category.Add(category);
            _context.SaveChanges();
            return category;
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
            var category = getCategory(id);
            _context.Category.Remove(category);
            _context.SaveChanges();
        }
        catch (System.Exception)
        {

            throw;
        }

    }

    // helper methods

    private Category getCategory(int id)
    {
        try
        {
            var category = _context.Category.Find(id);
            if (category == null) throw new KeyNotFoundException("Category not found");
            return category;
        }
        catch (System.Exception)
        {

            throw;
        }

    }
}