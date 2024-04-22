﻿using Bodesa.Telephony.Services.Context;
using Bodesa.Telephony.Services.UnitOfWork;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace Bodesa.Telephony.Services.Repository
{
    public class RepositoryBase<T> : ControllerBase, IRepository<T> where T : class
    {
        protected readonly ApplicationdbContext context;
        protected DbSet<T> dbSet;
        private readonly IUnitOfWork unitOfWork;

        public RepositoryBase(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            dbSet = unitOfWork.Context.Set<T>();
        }

        public async Task<ActionResult<IEnumerable<T>>> Get()
        {
            var data = await dbSet.ToListAsync();
            return Ok(data);
        }
    }
}
