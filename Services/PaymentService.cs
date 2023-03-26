namespace backend.Services;

using AutoMapper;
using backend.Entities;
using backend.Helpers;
using backend.Models.Payment;


public interface IPaymentService
{

    IEnumerable<Payment> GetAll();
    Payment GetById(int id);
    Payment Create(CreateRequestPayment model);
    void Delete(int id);
}

public class PaymentService : IPaymentService
{
    private DataContext _context;
    private readonly IMapper _mapper;
    public readonly IConfiguration configuration;

    public PaymentService(
        DataContext context,
        IConfiguration Configuration,
        IMapper mapper
        )
    {
        _context = context;
        _mapper = mapper;
        configuration = Configuration;
    }


    public IEnumerable<Payment> GetAll()
    {
        try
        {
            return _context.Payment;
        }
        catch (System.Exception)
        {

            throw;
        }

    }

    public Payment GetById(int id)
    {
        try
        {
            return GetPayment(id);
        }
        catch (System.Exception)
        {

            throw;
        }

    }

    public Payment Create(CreateRequestPayment model)
    {
        try
        {
            // map model to new payment object
            var payment = _mapper.Map<Payment>(model);


            // save payment
            _context.Payment.Add(payment);
            _context.SaveChanges();
            return payment;
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
            var payment = GetPayment(id);
            _context.Payment.Remove(payment);
            _context.SaveChanges();
        }
        catch (System.Exception)
        {

            throw;
        }

    }

    // helper methods

    private Payment GetPayment(int id)
    {
        try
        {
            var payment = _context.Payment.Find(id);
            if (payment == null) throw new KeyNotFoundException("Payment not found");
            return payment;
        }
        catch (System.Exception)
        {

            throw;
        }

    }
}