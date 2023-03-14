

using Core.Interfaces;
using Core.Interfaces.Service;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class WindowService : IWindowService
    {
        private readonly IWindowRepository _windowRepository;
        public WindowService(IWindowRepository windowRepository)
        {
            _windowRepository = windowRepository;
        }

        public async Task DeleteWindow(int id)
        {
           await _windowRepository.DeleteWindow(id);
        }
    }
}



