using System;
using System.Collections.Generic;
using System.Text;
using Dhgms.Nucleotide.Generators.Features.EntityFramework;
using Dhgms.Nucleotide.Generators.Models;
using Dhgms.Nucleotide.Generators.PropertyInfo;

namespace Dhgms.Nucleotide.ModelTests
{
    public class UserEntityGenerationModel : EntityGenerationModel
    {
        public override string ClassName => "User";

        public override KeyType KeyType => KeyType.Int32;
        public override IEntityGenerationModel BaseTypeEntityGenerationModel => null;
        public override IInterfaceGenerationModel[] InterfaceGenerationModels => null;

        public override string ClassRemarks => "Represents a User";

        public override PropertyInfoBase[] Properties => new PropertyInfoBase[]
        {
            new ClrStringPropertyInfo(CollectionType.None, "Username", "Username for the user", false, 3, 255, false, false, null),
            new ClrStringPropertyInfo(CollectionType.None, "PasswordHash", "Hash of the user password", false, 0, 1024, false, false, null)
        };
    }

    public class ModelGenerationDetails : INucleotideGenerationModel<IEntityGenerationModel>
    {
        public IEntityGenerationModel[] EntityGenerationModel => new[]
        {
            new UserEntityGenerationModel()
        };

        public string RootNamespace => "Dhgms.Nucleotide.GenerationTests";
    }

    public static class SampleEntityFrameworkModelGenerationModel
    {
        public static EntityFrameworkModelEntityGenerationModel[] EntityFrameworkModelEntityGenerationModels => new[]
        {
            new EntityFrameworkModelEntityGenerationModel
            {
                ClassName = "Salutation",
            },

            new EntityFrameworkModelEntityGenerationModel
            {
                ClassName = "Person",
            },

            new EntityFrameworkModelEntityGenerationModel
            {
                ClassName = "Gender",
            },

            new EntityFrameworkModelEntityGenerationModel
            {
                ClassName = "User",
            },

            new EntityFrameworkModelEntityGenerationModel
            {
                ClassName = "Address",
            },
        };
    }
}
