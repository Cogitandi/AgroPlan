using AgroPlan.Core.Repositories;
using AgroPlan.Core.RepositoryWrappers;
using AgroPlan.Infrastructure.Data;
using AgroPlan.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgroPlan.Infrastructure.RepositoryWrappers
{
    public class FertilizerRepositoryWrapper : IFertilizerRepositoryWrapper
    {
        private DatabaseContext _context;
        private IChemicalElementRepository _chemicalElementRepository;
        private IFertilizerComponentRepository _fertilizerComponentRepository;
        private IFertilizerRepository _fertilizerRepository;

        public FertilizerRepositoryWrapper(DatabaseContext context)
        {
            _context = context;
        }

        public IChemicalElementRepository ChemicalElementRepository
        {
            get
            {
                if (_chemicalElementRepository == null)
                {
                    _chemicalElementRepository = new ChemicalElementRepository(_context);
                }
                return _chemicalElementRepository;
            }
        }

        public IFertilizerComponentRepository FertilizerComponentRepository
        {
            get
            {
                if (_fertilizerComponentRepository == null)
                {
                    _fertilizerComponentRepository = new FertilizerComponentRepository(_context);
                }
                return _fertilizerComponentRepository;
            }
        }

        public IFertilizerRepository FertilizerRepository
        {
            get
            {
                if (_fertilizerRepository == null)
                {
                    _fertilizerRepository = new FertilizerRepository(_context);
                }
                return _fertilizerRepository;
            }
        }

    }
}
