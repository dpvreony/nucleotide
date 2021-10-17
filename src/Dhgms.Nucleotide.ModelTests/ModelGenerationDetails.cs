using System;
using System.Collections.Generic;
using System.Text;
using Dhgms.Nucleotide.Generators.Features.Database;
using Dhgms.Nucleotide.Generators.Features.EntityFramework;
using Dhgms.Nucleotide.Generators.Models;
using Dhgms.Nucleotide.Generators.PropertyInfo;

namespace Dhgms.Nucleotide.ModelTests
{
    public class AddressEntityGenerationModel : EntityGenerationModel
    {
        public override string ClassName => "Address";

        public override KeyType KeyType => KeyType.Int32;
        public override IEntityGenerationModel BaseTypeEntityGenerationModel => null;
        public override IInterfaceGenerationModel[] InterfaceGenerationModels => null;

        public override string ClassRemarks => "Represents an Address";

        public override PropertyInfoBase[] Properties => new PropertyInfoBase[]
        {
        };
    }

    public class GenderEntityGenerationModel : EntityGenerationModel
    {
        public override string ClassName => "Gender";

        public override KeyType KeyType => KeyType.Int32;
        public override IEntityGenerationModel BaseTypeEntityGenerationModel => null;
        public override IInterfaceGenerationModel[] InterfaceGenerationModels => null;

        public override string ClassRemarks => "Represents a Gender";

        public override PropertyInfoBase[] Properties => new PropertyInfoBase[]
        {
            new ClrStringPropertyInfo(CollectionType.None, "Name", "Name of the gender", false, 3, 255, false, false, null),
        };
    }

    public class PersonEntityGenerationModel : EntityGenerationModel
    {
        public override string ClassName => "Person";

        public override KeyType KeyType => KeyType.Int32;
        public override IEntityGenerationModel BaseTypeEntityGenerationModel => null;
        public override IInterfaceGenerationModel[] InterfaceGenerationModels => null;

        public override string ClassRemarks => "Represents a Person";

        public override PropertyInfoBase[] Properties => new PropertyInfoBase[]
        {
        };
    }

    public class SalutationEntityGenerationModel : EntityGenerationModel
    {
        public override string ClassName => "Salutation";

        public override KeyType KeyType => KeyType.Int32;
        public override IEntityGenerationModel BaseTypeEntityGenerationModel => null;
        public override IInterfaceGenerationModel[] InterfaceGenerationModels => null;

        public override string ClassRemarks => "Represents a Salutation";

        public override PropertyInfoBase[] Properties => new PropertyInfoBase[]
        {
            new ClrStringPropertyInfo(CollectionType.None, "Name", "Name of the salutation", false, 3, 255, false, false, null),
        };
    }

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
        public IEntityGenerationModel[] EntityGenerationModel => new IEntityGenerationModel[]
        {
            new AddressEntityGenerationModel(),
            new GenderEntityGenerationModel(),
            new PersonEntityGenerationModel(),
            new SalutationEntityGenerationModel(),
            new UserEntityGenerationModel()
        };

        public string RootNamespace => "Dhgms.Nucleotide.GenerationTests";
    }

    public class ReferencedByEntityGenerationModelGenerationDetails : INucleotideGenerationModel<ReferencedByEntityGenerationModel>
    {
        public ReferencedByEntityGenerationModel[] EntityGenerationModel => new ReferencedByEntityGenerationModel[]
        {
            SampleEntityFrameworkModelGenerationModel.GenderEntityRelationship,
            SampleEntityFrameworkModelGenerationModel.PersonEntityRelationship,
            SampleEntityFrameworkModelGenerationModel.SalutationEntityRelationship,
        };

        public string RootNamespace => "Dhgms.Nucleotide.GenerationTests";
    }

    public static class SampleEntityFrameworkModelGenerationModel
    {
        public static string RootNamespace => "Dhgms.Nucleotide.GenerationTests";
        public static string DatabaseRootNamespace => $"{RootNamespace}.Database";

        public static ReferencedByEntityGenerationModel SalutationEntityRelationship =>
            new ReferencedByEntityGenerationModel(
                DatabaseRootNamespace,
                "Salutation",
                "Salutation",
                "Salutation",
                "Salutations",
                "int");

        public static ReferencedByEntityGenerationModel GenderEntityRelationship =>
            new ReferencedByEntityGenerationModel(
                DatabaseRootNamespace,
                "Gender",
                "Gender",
                "Gender",
                "Genders",
                "int");

        public static ReferencedByEntityGenerationModel PersonEntityRelationship =>
            new ReferencedByEntityGenerationModel(
                DatabaseRootNamespace,
                "Person",
                "Person",
                "Person",
                "Persons",
                "int");

        public static EntityFrameworkModelEntityGenerationModel[] EntityFrameworkModelEntityGenerationModels => new[]
        {
            new EntityFrameworkModelEntityGenerationModel
            {
                ClassName = "Salutation",
                ChildEntityRelationships = new List<ReferencedByEntityGenerationModel>
                {
                    PersonEntityRelationship
                },
            },

            new EntityFrameworkModelEntityGenerationModel
            {
                ClassName = "Person",
                ParentEntityRelationships = new List<ReferencedByEntityGenerationModel>
                {
                    SalutationEntityRelationship,
                    GenderEntityRelationship,
                },
            },

            new EntityFrameworkModelEntityGenerationModel
            {
                ClassName = "Gender",
                ChildEntityRelationships = new List<ReferencedByEntityGenerationModel>
                {
                    PersonEntityRelationship
                },
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
