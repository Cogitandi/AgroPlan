using AgroPlan.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgroPlan.Core.RepositoryWrappers
{
    public interface IFertilizerRepositoryWrapper
    {
        IChemicalElementRepository ChemicalElementRepository { get; }
        IFertilizerComponentRepository FertilizerComponentRepository { get; }
        IFertilizerRepository FertilizerRepository { get; }
    }
}
