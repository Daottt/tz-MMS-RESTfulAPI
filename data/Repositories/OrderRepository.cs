using Microsoft.EntityFrameworkCore;

namespace data.Repositories;

public class OrderRepository
{
    private readonly Context _dbContext;
    public OrderRepository(Context dbContext)
    {
        _dbContext = dbContext;
    }
    public List<Order> GetAll()
    {
        return _dbContext.Orders
            .AsNoTracking()
            .Include(o => o.UsedMaterials)
            .ToList();
    }
    public Order? Get(int Id)
    {
        return _dbContext.Orders
            .AsNoTracking()
            .Include(o => o.UsedMaterials)
            .FirstOrDefault(o => o.Id == Id);
    }
    public bool Create(Order model)
    {
        model.CreatedAt = DateTime.UtcNow;
        _dbContext.Add(model);
        _dbContext.SaveChanges();
        return true;
    }
    public bool UpdateStaus(int Id, OrderStatus status)
    {
        var model = _dbContext.Orders.FirstOrDefault(o => o.Id == Id);
        if (model == null) return false;

        model.Status = status;
        _dbContext.SaveChanges();
        return true;
    }
    public bool Delete(int Id)
    {
        var model = _dbContext.Orders.FirstOrDefault(o => o.Id == Id);
        if (model == null) return false;

        _dbContext.Remove(model);
        _dbContext.SaveChanges();
        return true;
    }
    public List<Order> GetByFilter(DateTime? date, OrderStatus? status)
    {
        var query = _dbContext.Orders.AsNoTracking();
        if (date != null)
        {
            query = query.Where(o => o.CreatedAt == date);
        }
        if (status != null)
        {
            query = query.Where(o => o.Status == status);
        }
        return query.ToList();
    }
}