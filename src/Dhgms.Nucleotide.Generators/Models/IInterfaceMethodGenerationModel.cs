using System;
using System.Collections.Generic;
using System.Text;

namespace Dhgms.Nucleotide.Generators.Models
{
    public interface IInterfaceMethodGenerationModel : INameable
    {
        string ReturnType { get; }

        IList<IMethodArgumentModel> Arguments { get; }
    }
}
