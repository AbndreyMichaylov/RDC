using RDC.src.Data.DataTypes;

namespace RDC.src.Data.MouseRepository
{
    public interface IMouseRepository
    {
        Task<List<Mouse>> GetAllMousesAsync();

        Task AddMouseAsync(Mouse newMouse);

        Task EditMouseAsync(Mouse mouse);

        Task DeleteMouseAsync(int id);

        Task SaveAsync();
    }
}
