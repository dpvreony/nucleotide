// Copyright (c) 2020 DHGMS Solutions and Contributors. All rights reserved.
// DHGMS Solutions and Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using Dhgms.Nucleotide.Generators.Features.Database;
using Dhgms.Nucleotide.Generators.Features.EntityFramework;
using Dhgms.Nucleotide.Generators.Features.ReactiveUI.Wpf;
using Dhgms.Nucleotide.Generators.Models;
using Dhgms.Nucleotide.Generators.PropertyInfo;
using Dhgms.Nucleotide.SampleGenerator.InterfaceGenerationModels.Whipstaff.Entities;

namespace Dhgms.Nucleotide.ModelTests
{
    public class AddressEntityGenerationModel : EntityGenerationModel
    {
        public override string ClassName => "Address";

        public override KeyType KeyType => KeyType.Int32;
        public override BaseEntityTypeGenerationModel BaseTypeEntityGenerationModel => null;
        public override InterfaceGenerationModel[] InterfaceGenerationModels => null;

        public override string ClassRemarks => "Represents an Address";

        public override PropertyInfoBase[] Properties => new PropertyInfoBase[]
        {
        };
    }

    public class GenderEntityGenerationModel : EntityGenerationModel
    {
        public override string ClassName => "Gender";

        public override KeyType KeyType => KeyType.Int32;
        public override BaseEntityTypeGenerationModel BaseTypeEntityGenerationModel => null;
        public override InterfaceGenerationModel[] InterfaceGenerationModels => null;

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
        public override BaseEntityTypeGenerationModel BaseTypeEntityGenerationModel => null;
        public override InterfaceGenerationModel[] InterfaceGenerationModels => null;

        public override string ClassRemarks => "Represents a Person";

        public override PropertyInfoBase[] Properties => new PropertyInfoBase[]
        {
        };
    }

    public class SalutationEntityGenerationModel : EntityGenerationModel
    {
        public override string ClassName => "Salutation";

        public override KeyType KeyType => KeyType.Int32;
        public override BaseEntityTypeGenerationModel BaseTypeEntityGenerationModel => null;
        public override InterfaceGenerationModel[] InterfaceGenerationModels => new InterfaceGenerationModel[]
        {
            new NameableInterfaceGenerationModel()
        };

        public override string ClassRemarks => "Represents a Salutation";

        public override PropertyInfoBase[] Properties => Array.Empty<PropertyInfoBase>();
    }

    public class UserEntityGenerationModel : EntityGenerationModel
    {
        public override string ClassName => "User";

        public override KeyType KeyType => KeyType.Int32;
        public override BaseEntityTypeGenerationModel BaseTypeEntityGenerationModel => null;
        public override InterfaceGenerationModel[] InterfaceGenerationModels => null;

        public override string ClassRemarks => "Represents a User";

        public override PropertyInfoBase[] Properties => new PropertyInfoBase[]
        {
            new ClrStringPropertyInfo(CollectionType.None, "Username", "Username for the user", false, 3, 255, false, false, null),
            new ClrStringPropertyInfo(CollectionType.None, "PasswordHash", "Hash of the user password", false, 0, 1024, false, false, null)
        };
    }

    public class IdentityRoleEntityGenerationModel : EntityGenerationModel
    {
        public override string ClassName => "SomeRole";

        public override KeyType KeyType => KeyType.Inherited;
        public override BaseEntityTypeGenerationModel BaseTypeEntityGenerationModel => new ("Microsoft.AspNetCore.Identity.IdentityRole<int>");
        public override InterfaceGenerationModel[] InterfaceGenerationModels => null;

        public override string ClassRemarks => "Represents a Role";

        public override PropertyInfoBase[] Properties => new PropertyInfoBase[]
        {
        };
    }

    public class IdentityUserEntityGenerationModel : EntityGenerationModel
    {
        public override string ClassName => "SomeUser";

        public override KeyType KeyType => KeyType.Inherited;
        public override BaseEntityTypeGenerationModel BaseTypeEntityGenerationModel => new("Microsoft.AspNetCore.Identity.IdentityUser<int>");
        public override InterfaceGenerationModel[] InterfaceGenerationModels => null;

        public override string ClassRemarks => "Represents a User";

        public override PropertyInfoBase[] Properties => new PropertyInfoBase[]
        {
        };
    }

    public class EntityFrameworkGenerationModelDetails : INucleotideGenerationModel<EntityFrameworkDbContextGenerationModel>
    {
        public EntityFrameworkDbContextGenerationModel[] EntityGenerationModel =>
            new EntityFrameworkDbContextGenerationModel[]
            {
                new EntityFrameworkDbContextGenerationModel
                {
                    ClassName = "SomeProduct",
                    DbSetEntities = new EntityGenerationModel[]
                    {
                        new UserEntityGenerationModel(),
                    }
                }
            };

        public string RootNamespace => "Dhgms.Nucleotide.GenerationTests";
    }

    public class MsIdentityEntityFrameworkGenerationModelDetails : INucleotideGenerationModel<EntityFrameworkDbContextGenerationModel>
    {
        public EntityFrameworkDbContextGenerationModel[] EntityGenerationModel =>
            new EntityFrameworkDbContextGenerationModel[]
            {
                new EntityFrameworkDbContextGenerationModel
                {
                    ClassName = "SomeProductWithIdentity",
                    DbSetEntities = Array.Empty<EntityGenerationModel>(),
                    OverrideBaseDbContextType = "Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext<EfModels.SomeUserEfModel, EfModels.SomeRoleEfModel, int>",
                }
            };

        public string RootNamespace => "Dhgms.Nucleotide.GenerationTests";
    }

    public class ModelGenerationDetails : INucleotideGenerationModel<IEntityGenerationModel>
    {
        public IEntityGenerationModel[] EntityGenerationModel =>
        [
            new AddressEntityGenerationModel(),
            new GenderEntityGenerationModel(),
            new PersonEntityGenerationModel(),
            new SalutationEntityGenerationModel(),
            new UserEntityGenerationModel(),
        ];

        public string RootNamespace => "Dhgms.Nucleotide.GenerationTests";
    }

    public class EfModelGenerationDetails : INucleotideGenerationModel<EntityFrameworkModelEntityGenerationModel>
    {
        public EntityFrameworkModelEntityGenerationModel[] EntityGenerationModel =>
            SampleEntityFrameworkModelGenerationModel.EntityFrameworkModelEntityGenerationModels;

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
                ClassPluralName = "Salutations",
                ChildEntityRelationships = new List<ReferencedByEntityGenerationModel>
                {
                    PersonEntityRelationship
                },
            },

            new EntityFrameworkModelEntityGenerationModel
            {
                ClassName = "Person",
                ClassPluralName = "Persons",
                ParentEntityRelationships = new List<ReferencedByEntityGenerationModel>
                {
                    SalutationEntityRelationship,
                    GenderEntityRelationship,
                },
            },

            new EntityFrameworkModelEntityGenerationModel
            {
                ClassName = "Gender",
                ClassPluralName= "Genders",
                ChildEntityRelationships = new List<ReferencedByEntityGenerationModel>
                {
                    PersonEntityRelationship
                },
            },

            new EntityFrameworkModelEntityGenerationModel
            {
                ClassName = "User",
                ClassPluralName = "Users",
            },

            new EntityFrameworkModelEntityGenerationModel
            {
                ClassName = "Address",
                ClassPluralName = "Addresses",
            },
        };
    }

    public class ReactiveUIViewForViewModel : INucleotideGenerationModel<ReactiveWindowGenerationModel>
    {
        public ReactiveWindowGenerationModel[] EntityGenerationModel => new []
        {
            new ReactiveWindowGenerationModel("Address", "global::Dhgms.Nucleotide.SampleApp.ViewModels.IAddressViewModel")
        };

        public string RootNamespace => "Dhgms.Nucleotide.GenerationTests";
    }

}
