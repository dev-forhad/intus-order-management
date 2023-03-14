

using Core.Interfaces;
using Core.Interfaces.Service;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Interfaces.Repository;

namespace Core.Services
{
    public class SubElementService : ISubElementService
    {
        private readonly ISubElementRepository _subElementRepository;
        public SubElementService(ISubElementRepository subElementRepository)
        {
            _subElementRepository= subElementRepository;
        }

        public async Task DeleteSubElement(int id)
        {
            try
            {
                var orderToDelete = await _subElementRepository.GetByIdAsync(id);
                if (orderToDelete != null)
                {
                    await _subElementRepository.DeleteAsync(orderToDelete.Id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting sub-element with ID {id} from database.", ex);
            }
        }
    }
}



