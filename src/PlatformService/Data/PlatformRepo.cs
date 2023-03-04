using PlatformService.Models;

namespace PlatformService.Data;

public class PlatformRepo : IPlatformRepo
{
    private readonly AppDbContext _context;

    public PlatformRepo(AppDbContext context)
    {
        _context = context;
    }

    public bool SaveChanges()
    {
        return (_context.SaveChanges() >= 0); // returns true if 1 or more rows were affected
    }

    public IEnumerable<Platform> GetAllPlatforms()
    {
        return _context.Platforms.ToList();
    }

    public Platform? GetPlatformById(int id)
    {
        return _context.Platforms.FirstOrDefault(p => p.Id == id);
    }

    public void CreatePlatform(Platform plat)
    {
        if (plat == null) // this is not necessary, but it's a good practice
        {
            ArgumentNullException.ThrowIfNull(plat, nameof(plat));
        }

        _context.Platforms.Add(plat);
    }
}