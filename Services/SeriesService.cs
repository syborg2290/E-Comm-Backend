namespace backend.Services;

using AutoMapper;
using backend.Entities;
using backend.Helpers;
using backend.Models.Series;


public interface ISeriesService
{

    IEnumerable<Series> GetAll();
    Series GetById(int id);
    Series Create(CreateRequestSeries model);
    void Delete(int id);
}

public class SeriesService : ISeriesService
{
    private DataContext _context;
    private readonly IMapper _mapper;
    public readonly IConfiguration configuration;

    public SeriesService(
        DataContext context,
        IConfiguration Configuration,
        IMapper mapper
        )
    {
        _context = context;
        _mapper = mapper;
        configuration = Configuration;
    }


    public IEnumerable<Series> GetAll()
    {
        try
        {
            return _context.Series;
        }
        catch (System.Exception)
        {

            throw;
        }

    }

    public Series GetById(int id)
    {
        try
        {
            return GetSeries(id);
        }
        catch (System.Exception)
        {

            throw;
        }

    }

    public Series Create(CreateRequestSeries model)
    {
        try
        {
            // map model to new series object
            var series = _mapper.Map<Series>(model);


            // save series
            _context.Series.Add(series);
            _context.SaveChanges();
            return series;
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
            var series = GetSeries(id);
            _context.Series.Remove(series);
            _context.SaveChanges();
        }
        catch (System.Exception)
        {

            throw;
        }

    }

    // helper methods

    private Series GetSeries(int id)
    {
        try
        {
            var series = _context.Series.Find(id);
            if (series == null) throw new KeyNotFoundException("Series not found");
            return series;
        }
        catch (System.Exception)
        {

            throw;
        }

    }
}