﻿using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfMenuDal : EfEntityRepositoryBase<Menu>, IMenuDal
    {
        private readonly WebProjectDbContext _context;

        public EfMenuDal(WebProjectDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
