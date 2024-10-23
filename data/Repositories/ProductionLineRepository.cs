using Microsoft.EntityFrameworkCore;

namespace data.Repositories;

public class ProductionLineRepository
{
    private readonly Context _dbContext;
    public ProductionLineRepository(Context dbContext)
    {
        _dbContext = dbContext;
    }
    public List<ProductionLine> GetAll()
    {
        return _dbContext.ProductionLines
            .AsNoTracking()
            .Include(p => p.CurrentOrder)
            .ToList();
    }
    public ProductionLine? Get(int Id)
    {
        return _dbContext.ProductionLines
            .AsNoTracking()
            .Include(p => p.CurrentOrder)
            .FirstOrDefault(p => p.Id == Id);
    }
    public bool Create(ProductionLine model)
    {
        if(model.CurrentOrderId != null)
        {
            var order = _dbContext.Orders.FirstOrDefault(o => o.Id == model.CurrentOrderId);
            if (order == null) return false;
        }

        _dbContext.Add(model);
        _dbContext.SaveChanges();
        return true;
    }
    public bool UpdateStaus(int Id,ProductionLineStatus status)
    {
        var model = _dbContext.ProductionLines.FirstOrDefault(p => p.Id == Id);
        if (model == null) return false;

        model.Status = status;
        _dbContext.SaveChanges();
        return true;
    }
    public bool Delete(int Id)
    {
        var model = _dbContext.ProductionLines.FirstOrDefault(p => p.Id == Id);
        if (model == null) return false;

        _dbContext.Remove(model);
        _dbContext.SaveChanges();
        return true;
    }
}
