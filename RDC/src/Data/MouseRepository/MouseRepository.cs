using Microsoft.EntityFrameworkCore;
using RDC.src.Data.Database;
using RDC.src.Data.DataTypes;

namespace RDC.src.Data.MouseRepository
{
    public class MouseRepository : IMouseRepository
    {
        private readonly AppDb _context;

        public MouseRepository(AppDb context) 
        {
            _context = context;
        }
        public async Task AddMouseAsync(Mouse newMouse)
        {
            await _context.Mouses.AddAsync(newMouse);
        }

        public async Task DeleteMouseAsync(int id)
        {
            var toRemove = await _context.Mouses.FindAsync(id);
            if (toRemove is null) return;
            _context.Mouses.Remove(toRemove); 
        }

        public async Task EditMouseAsync(Mouse mouseToEdit)
        {
            var toEdit = await _context.Mouses.FindAsync(mouseToEdit.ID);
            if (toEdit is null) return;
            toEdit.Name = mouseToEdit.Name;
        }

        public async Task<List<Mouse>> GetAllMousesAsync()
        {
            return await _context.Mouses.ToListAsync();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
