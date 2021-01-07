using AgroPlan.Core.Repositories;
using AgroPlan.Core.RepositoryWrappers;
using AgroPlan.Infrastructure.Data;
using AgroPlan.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgroPlan.Infrastructure.RepositoryWrappers
{
    public class SprayingRepositoryWrapper : ISprayingRepositoryWrapper
    {
        private DatabaseContext _context;
        private ISprayingProductRepository _sprayingProductRepository;
        private IContentUnitRepository _contentUnitRepository;
        private ISprayingComponentRepository _sprayingComponentRepository;
        private ISprayingRepository _sprayingRepository;

        public SprayingRepositoryWrapper(DatabaseContext context)
        {
            _context = context;
        }

        public ISprayingProductRepository SprayingProductRepository
        {
            get
            {
                if (_sprayingProductRepository == null)
                {
                    _sprayingProductRepository = new SprayingProductRepository(_context);
                }
                return _sprayingProductRepository;
            }
        }

        public IContentUnitRepository ContentUnitRepository
        {
            get
            {
                if (_contentUnitRepository == null)
                {
                    _contentUnitRepository = new ContentUnitRepository(_context);
                }
                return _contentUnitRepository;
            }
        }

        public ISprayingComponentRepository SprayingComponentRepository
        {
            get
            {
                if (_sprayingComponentRepository == null)
                {
                    _sprayingComponentRepository = new SprayingComponentRepository(_context);
                }
                return _sprayingComponentRepository;
            }
        }
        public ISprayingRepository SprayingMixtureRepository
        {
            get
            {
                if (_sprayingRepository == null)
                {
                    _sprayingRepository = new SprayingRepository(_context);
                }
                return _sprayingRepository;
            }
        }


    }
}
