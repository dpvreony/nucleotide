using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dhgms.Nucleotide.Attributes;
using Dhgms.Nucleotide.Model;
using Dhgms.Nucleotide.PropertyInfo;

namespace Dhgms.Nucleotide.Mocking
{
    public class UserClassGenerationParameters : ClassGenerationParameters
    {
        public override string BaseClassName => null;

        public override PropertyInfoBase[] BaseClassProperties => null;

        public override string ClassName => "User";

        public override string ClassRemarks => "Represents a User";

        public override string CompanyName => "DHGMS Solutions";

        public override string[] CopyrightBanner => new[] { "DHGMS Solutions" };

        public override int CopyrightStartYear => 2005;

        public override string MainNamespaceName => null;

        public override PropertyInfoBase[] Properties => null;

        public override string SubNamespace => null;
    }

    public sealed class Nucleotide : INucleotideGenerationModel
    {
        public ClassGenerationParameters[] ClassGenerationParameters => new[]
        {
            new UserClassGenerationParameters()
        };
    }
}
