using Dhgms.Nucleotide.Generators.PropertyInfo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dhgms.Nucleotide.Generators.Models
{
    public sealed record IndexGenerationModel(string[] Names, bool IsUnique);
}
