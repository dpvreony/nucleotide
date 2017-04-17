using System;
using System.Collections.Generic;
using System.Text;
using Dhgms.Nucleotide.Model;
using Dhgms.Nucleotide.PropertyInfo;

namespace Dhgms.Nucleotide.ModelTests
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

    public class ModelGenerationDetails : INucleotideGenerationModel
    {
        public ClassGenerationParameters[] ClassGenerationParameters => new[]
        {
            new UserClassGenerationParameters()
        };
    }
}
