using Microsoft.EntityFrameworkCore;

namespace data.Repositories;

public class MaterialRepository
{
    private readonly Context _dbContext;
    public MaterialRepository(Context dbContext)
    {
        _dbContext = dbContext;
    }
    public List<Material> GetAll()
    {
        return _dbContext.Materials
            .AsNoTracking()
            .ToList();
    }
    public Material? Get(int Id)
    {
        return _dbContext.Materials
            .AsNoTracking()
            .FirstOrDefault(m => m.Id == Id);
    }
    public bool Create(Material model)
    {
        _dbContext.Add(model);
        _dbContext.SaveChanges();
        return true;
    }
    public bool UpdateQuantity(int Id, int Quantity)
    {
        var model = _dbContext.Materials.FirstOrDefault(m => m.Id == Id);
        if (model == null) return false;

        model.QuantityAvailable = Quantity;
        _dbContext.SaveChanges();
        return true;
    }
    public bool Delete(int Id)
    {
        var model = _dbContext.Materials.FirstOrDefault(m => m.Id == Id);
        if (model == null) return false;

        _dbContext.Remove(model);
        _dbContext.SaveChanges();
        return true;
    }
}