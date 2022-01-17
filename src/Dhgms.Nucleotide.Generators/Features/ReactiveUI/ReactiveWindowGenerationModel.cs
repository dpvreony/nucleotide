// Copyright (c) 2020 DHGMS Solutions and Contributors. All rights reserved.
// DHGMS Solutions and Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;
using Dhgms.Nucleotide.Generators.GeneratorProcessors;

namespace Dhgms.Nucleotide.Generators.Features.ReactiveUI.Wpf
{
    public sealed class ReactiveWindowGenerationModel : IClassName
    {
        public ReactiveWindowGenerationModel(
            string className,
            string viewModelType)
        {
            if (string.IsNullOrWhiteSpace(className))
            {
                throw new ArgumentNullException(nameof(className));
            }

            if (string.IsNullOrWhiteSpace(viewModelType))
            {
                throw new ArgumentNullException(nameof(viewModelType));
            }

            ClassName = className;
            ViewModelType = viewModelType;
        }

        /// <inheritdoc />
        public string ClassName { get; }

        /// <summary>
        /// Gets the fully qualified type for the view model. Can be a class or interface, should inherit off IReactiveObject.
        /// </summary>
        public string ViewModelType { get; }
    }
}
