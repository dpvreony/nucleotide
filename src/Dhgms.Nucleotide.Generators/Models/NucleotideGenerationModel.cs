// Copyright (c) 2020 DHGMS Solutions and Contributors. All rights reserved.
// DHGMS Solutions and Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

namespace Dhgms.Nucleotide.Generators.Models
{
    public sealed class NucleotideGenerationModel<TGenerationModel> : INucleotideGenerationModel<TGenerationModel>
    {
        public NucleotideGenerationModel(string rootNamespace, TGenerationModel[] entityGenerationModel)
        {
            RootNamespace = rootNamespace;
            EntityGenerationModel = entityGenerationModel;
        }

        /// <summary>
        /// Gets a collection of Class Generation Parameters.
        /// </summary>
        public TGenerationModel[] EntityGenerationModel { get; }

        public string RootNamespace { get; }
    }
}
