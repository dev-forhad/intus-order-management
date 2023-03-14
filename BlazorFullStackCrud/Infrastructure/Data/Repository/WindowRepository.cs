
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repository
{
    public class WindowRepository : Repository<Window>, IWindowRepository
    {
        public WindowRepository(ApplicationDbContext context) : base(context) { }

        public async Task DeleteWindow(int id)
        {
            await using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                // Delet the window
                var dbWindow = await _context.Windows
                    .Include(sh => sh.SubElements)
                    .FirstOrDefaultAsync(sh => sh.Id == id);

                if (dbWindow == null)
                {
                    Console.WriteLine("Sorry, but no window found.");
                    await transaction.RollbackAsync();
                }
                else
                {
                    _context.Windows.Remove(dbWindow);
                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                // Handle any exceptions
                Console.WriteLine(ex.Message);

            }
        }
    }
}
