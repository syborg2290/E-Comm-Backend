namespace backend.Services;

using AutoMapper;
using backend.Entities;
using backend.Helpers;
using backend.Models.ComputerModel;


public interface IComputerModelService
{

    IEnumerable<ComputerModel> GetAll();
    ComputerModel GetById(int id);
    ComputerModel Create(CreateRequestComputerModel model);
    void Delete(int id);
}

public class ComputerModelService : IComputerModelService
{
    private DataContext _context;
    private readonly IMapper _mapper;
    public readonly IConfiguration configuration;

    public ComputerModelService(
        DataContext context,
        IConfiguration Configuration,
        IMapper mapper
        )
    {
        _context = context;
        _mapper = mapper;
        configuration = Configuration;
    }


    public IEnumerable<ComputerModel> GetAll()
    {
        try
        {
            return _context.ComputerModel;
        }
        catch (System.Exception)
        {

            throw;
        }

    }

    public ComputerModel GetById(int id)
    {
        try
        {
            return GetComputerModel(id);
        }
        catch (System.Exception)
        {

            throw;
        }

    }

    public ComputerModel Create(CreateRequestComputerModel model)
    {
        try
        {
            // map model to new category object
            var computermodel = _mapper.Map<ComputerModel>(model);


            // save category
            _context.ComputerModel.Add(computermodel);
            _context.SaveChanges();
            return computermodel;
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
            var model = GetComputerModel(id);
            _context.ComputerModel.Remove(model);
            _context.SaveChanges();
        }
        catch (System.Exception)
        {

            throw;
        }

    }

    // helper methods

    private ComputerModel GetComputerModel(int id)
    {
        try
        {
            var model = _context.ComputerModel.Find(id);
            if (model == null) throw new KeyNotFoundException("Model not found");
            return model;
        }
        catch (System.Exception)
        {

            throw;
        }

    }
}