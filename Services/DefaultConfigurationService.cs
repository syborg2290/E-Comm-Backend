namespace backend.Services;

using AutoMapper;
using backend.Entities;
using backend.Helpers;
using backend.Models.DefaultConfiguration;


public interface IDefaultConfigurationService
{

    IEnumerable<DefaultConfiguration> GetAll();
    DefaultConfiguration GetById(int id);
    DefaultConfiguration Create(CreateRequestDefaultConfiguration model);
    void Delete(int id);
}

public class DefaultConfigurationService : IDefaultConfigurationService
{
    private DataContext _context;
    private readonly IMapper _mapper;
    public readonly IConfiguration configuration;

    public DefaultConfigurationService(
        DataContext context,
        IConfiguration Configuration,
        IMapper mapper
        )
    {
        _context = context;
        _mapper = mapper;
        configuration = Configuration;
    }


    public IEnumerable<DefaultConfiguration> GetAll()
    {
        try
        {
            return _context.DefaultConfiguration;
        }
        catch (System.Exception)
        {

            throw;
        }

    }

    public DefaultConfiguration GetById(int id)
    {
        try
        {
            return GetDefaultConfiguration(id);
        }
        catch (System.Exception)
        {

            throw;
        }

    }

    public DefaultConfiguration Create(CreateRequestDefaultConfiguration model)
    {
        try
        {
            var configuration = _mapper.Map<DefaultConfiguration>(model);


            _context.DefaultConfiguration.Add(configuration);
            _context.SaveChanges();
            return configuration;
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
            var configuration = GetDefaultConfiguration(id);
            _context.DefaultConfiguration.Remove(configuration);
            _context.SaveChanges();
        }
        catch (System.Exception)
        {

            throw;
        }

    }

    // helper methods

    private DefaultConfiguration GetDefaultConfiguration(int id)
    {
        try
        {
            var configuration = _context.DefaultConfiguration.Find(id);
            if (configuration == null) throw new KeyNotFoundException("Config not found");
            return configuration;
        }
        catch (System.Exception)
        {

            throw;
        }

    }
}