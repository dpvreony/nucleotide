// Copyright (c) 2020 DHGMS Solutions and Contributors. All rights reserved.
// DHGMS Solutions and Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using Dhgms.Nucleotide.Generators.GeneratorProcessors;

namespace Dhgms.Nucleotide.Generators.Generators
{
    /// <summary>
    /// Base class for a code generator that generates code based on the Interface Level of Generation Metadata.
    /// </summary>
    public abstract class BaseInterfaceLevelCodeGenerator<TFeatureFlags, TGeneratorProcessor, TGenerationModel> : BaseGenerator<TFeatureFlags, TGeneratorProcessor, TGenerationModel>
        where TFeatureFlags : class
        where TGeneratorProcessor : BaseInterfaceLevelCodeGeneratorProcessor<TGenerationModel>, new()
        where TGenerationModel : IClassName
    {
    }
}
