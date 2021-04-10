using System.Collections.Generic;

namespace Dhgms.Nucleotide.Generators.Models
{
    public interface IInterfaceGenerationModel : IObjectGenerationModel
    {
        IList<IPropertyGenerationModel> Properties { get; }

        IList<IInterfaceMethodGenerationModel> Methods { get; }

        IList<IInterfaceGenerationModel> BaseInterfaces { get; }
    }
}