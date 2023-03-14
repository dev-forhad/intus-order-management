
using Core.Entities;
using Core.Interfaces;
using Core.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repository
{
    public class SubElementRepository : Repository<SubElement>, ISubElementRepository
    {
        public SubElementRepository(ApplicationDbContext context) : base(context) { }

     
    }
}
