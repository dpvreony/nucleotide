using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dhgms.Nucleotide.Attributes;

namespace Dhgms.Nucleotide.Mocking
{
    [GenerateEntityFrameworkDbSet]
    [GenerateModels]
    [GenerateQueryableRepositoryInterface]
    [GenerateWcfService]
    [GenerateWebApiService]
    public sealed class Nucleotide
    {
    }

    public sealed class TestOfGeneration
    {
        public TestOfGeneration()
        {
            //var x = new NucleotideA();
        }
    }
}
