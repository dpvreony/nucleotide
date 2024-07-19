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
    public class EntityFrameworkGenerationModelDetails : INucleotideGenerationModel<EntityFrameworkDbContextGenerationModel>
    {
        public EntityFrameworkDbContextGenerationModel[] EntityGenerationModel =>
        [
            new EntityFrameworkDbContextGenerationModel
            {
                ClassName = "SomeProduct",
                DbSetEntities =
                [
                    SampleEntityFrameworkModelGenerationModel.UserEntityFrameworkModelEntityGenerationModel
                ]
            }
        ];

        public string RootNamespace => "Dhgms.Nucleotide.GenerationTests";
    }

    public class MsIdentityEntityFrameworkGenerationModelDetails : INucleotideGenerationModel<EntityFrameworkDbContextGenerationModel>
    {
        public EntityFrameworkDbContextGenerationModel[] EntityGenerationModel =>
        [
            new EntityFrameworkDbContextGenerationModel
            {
                ClassName = "SomeProductWithIdentity",
                DbSetEntities = Array.Empty<EntityGenerationModel>(),
                OverrideBaseDbContextType =
                    "Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext<EfModels.SomeUserEfModel, EfModels.SomeRoleEfModel, int>",
            }
        ];

        public string RootNamespace => "Dhgms.Nucleotide.GenerationTests";
    }

    public class ModelGenerationDetails : INucleotideGenerationModel<IEntityGenerationModel>
    {
        public IEntityGenerationModel[] EntityGenerationModel =>
        [
            SampleEntityFrameworkModelGenerationModel.AddressEntityFrameworkModelEntityGenerationModel,
            SampleEntityFrameworkModelGenerationModel.GenderEntityFrameworkModelEntityGenerationModel,
            SampleEntityFrameworkModelGenerationModel.PersonEntityFrameworkModelEntityGenerationModel,
            SampleEntityFrameworkModelGenerationModel.SalutationEntityFrameworkModelEntityGenerationModel,
            SampleEntityFrameworkModelGenerationModel.UserEntityFrameworkModelEntityGenerationModel
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
        public ReferencedByEntityGenerationModel[] EntityGenerationModel =>
        [
            SampleEntityFrameworkModelGenerationModel.GenderEntityRelationship,
            SampleEntityFrameworkModelGenerationModel.PersonEntityRelationship,
            SampleEntityFrameworkModelGenerationModel.SalutationEntityRelationship,
        ];

        public string RootNamespace => "Dhgms.Nucleotide.GenerationTests";
    }

    public static class SampleEntityFrameworkModelGenerationModel
    {
        public static string RootNamespace => "Dhgms.Nucleotide.GenerationTests";
        public static string DatabaseRootNamespace => $"{RootNamespace}.Database";

        public static ReferencedByEntityGenerationModel SalutationEntityRelationship => new (
                DatabaseRootNamespace,
                "Salutation",
                "Salutation",
                "Salutation",
                "Salutations",
                "int");

        public static ReferencedByEntityGenerationModel GenderEntityRelationship => new (
                DatabaseRootNamespace,
                "Gender",
                "Gender",
                "Gender",
                "Genders",
                "int");

        public static ReferencedByEntityGenerationModel PersonEntityRelationship => new (
                DatabaseRootNamespace,
                "Person",
                "Person",
                "Person",
                "Persons",
                "int");

        public static EntityFrameworkModelEntityGenerationModel SalutationEntityFrameworkModelEntityGenerationModel => new()
        {
            ClassName = "Salutation",
            ClassPluralName = "Salutations",
            KeyType = KeyType.Int32,
            ChildEntityRelationships = new List<ReferencedByEntityGenerationModel>
            {
                PersonEntityRelationship
            },
            InterfaceGenerationModels =
            [
                new NameableInterfaceGenerationModel()
            ]
        };

        public static EntityFrameworkModelEntityGenerationModel PersonEntityFrameworkModelEntityGenerationModel => new()
        {
            ClassName = "Person",
            ClassPluralName = "Persons",
            KeyType = KeyType.Int32,
            ParentEntityRelationships = new List<ReferencedByEntityGenerationModel>
            {
                SalutationEntityRelationship,
                GenderEntityRelationship,
            },
        };

        public static EntityFrameworkModelEntityGenerationModel GenderEntityFrameworkModelEntityGenerationModel => new()
        {
            ClassName = "Gender",
            ClassPluralName = "Genders",
            KeyType = KeyType.Int32,
            ChildEntityRelationships = new List<ReferencedByEntityGenerationModel>
            {
                PersonEntityRelationship
            },
            InterfaceGenerationModels =
            [
                new NameableInterfaceGenerationModel()
            ]
        };

        public static EntityFrameworkModelEntityGenerationModel UserEntityFrameworkModelEntityGenerationModel => new()
        {
            ClassName = "User",
            ClassPluralName = "Users",
            KeyType = KeyType.Int32,
            BaseTypeEntityGenerationModel = null,
            InterfaceGenerationModels = null,
            ClassRemarks = "Represents a User",
            Properties = [
                new ClrStringPropertyInfo(CollectionType.None, "Username", "Username for the user", false, 3, 255, false, false, null),
                new ClrStringPropertyInfo(CollectionType.None, "PasswordHash", "Hash of the user password", true, 0, 1024, false, false, null)
            ]
        };

        public static EntityFrameworkModelEntityGenerationModel AddressEntityFrameworkModelEntityGenerationModel => new()
        {
            KeyType = KeyType.Int32,
            ClassName = "Address",
            ClassPluralName = "Addresses",
        };

        public static EntityFrameworkModelEntityGenerationModel SomeRoleEntityFrameworkModelEntityGenerationModel => new()
        {
            ClassName = "SomeRole",
            ClassPluralName = "SomeRoles",
            KeyType = KeyType.Inherited,
            BaseTypeEntityGenerationModel = new("Microsoft.AspNetCore.Identity.IdentityRole<int>"),
            InterfaceGenerationModels = null,
            ClassRemarks = "Represents a Role",
            Properties = [],
            GenerateRowVersionColumn = false,
            GenerateCreatedAndModifiedColumns = GenerateCreatedAndModifiedColumns.None,
        };

        public static EntityFrameworkModelEntityGenerationModel SomeUserEntityFrameworkModelEntityGenerationModel => new()
        {
            ClassName = "SomeUser",
            ClassPluralName = "SomeUsers",
            KeyType = KeyType.Inherited,
            BaseTypeEntityGenerationModel = new("Microsoft.AspNetCore.Identity.IdentityUser<int>"),
            InterfaceGenerationModels = null,
            ClassRemarks = "Represents a User",
            Properties = [],
            GenerateRowVersionColumn = false,
            GenerateCreatedAndModifiedColumns = GenerateCreatedAndModifiedColumns.None,
        };

        public static EntityFrameworkModelEntityGenerationModel[] EntityFrameworkModelEntityGenerationModels =>
        [
            SalutationEntityFrameworkModelEntityGenerationModel,
            PersonEntityFrameworkModelEntityGenerationModel,
            GenderEntityFrameworkModelEntityGenerationModel,
            UserEntityFrameworkModelEntityGenerationModel,
            AddressEntityFrameworkModelEntityGenerationModel,
            SomeRoleEntityFrameworkModelEntityGenerationModel,
            SomeUserEntityFrameworkModelEntityGenerationModel,
        ];
    }

    public class ReactiveUIViewForViewModel : INucleotideGenerationModel<ReactiveWindowGenerationModel>
    {
        public ReactiveWindowGenerationModel[] EntityGenerationModel => [
            new ReactiveWindowGenerationModel("Address", "global::Dhgms.Nucleotide.SampleApp.ViewModels.IAddressViewModel")
        ];

        public string RootNamespace => "Dhgms.Nucleotide.GenerationTests";
    }

}
