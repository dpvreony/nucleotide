// Copyright (c) 2020 DHGMS Solutions and Contributors. All rights reserved.
// DHGMS Solutions and Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.Collections.Generic;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Dhgms.Nucleotide.Generators.Features.ReactiveUI.Wpf
{
    public sealed class ReactiveMetroWindowClassGeneratorProcessor : AbstractReactiveWindowClassGeneratorProcessor
    {
        protected override string[] GetClassLevelCommentSummary(string entityName)
        {
            return new[]
            {
                $"Reactive Metro Window wrapper for {entityName}. This is done to remove a build and compile time issue with using generic base classes in WPF controls.",
                "While support has improved you can end up with build chain failures which are vague and actually because the resolution of generics in XAML and the binary code are blocking each other",
                "from building. You can reduce the risks of this by removing EVERYTHING but the direct xaml code and codebehind logic. But you can end up with an extra library",
                "project in your build chain. Alternatively you can use these wrappers to remove the generics from the xaml file."
            };
        }

        protected override IReadOnlyCollection<FieldDeclarationSyntax> GetFieldDeclarations(ReactiveWindowGenerationModel entityGenerationModel)
        {
            return null;
        }

        protected override string GetBaseClass(ReactiveWindowGenerationModel entityGenerationModel)
        {
            return $"global::Whipstaff.Wpf.Mahapps.ReactiveMetroWindow<{entityGenerationModel.ViewModelType}>";
        }

        ///<inheritdoc />
        protected override string GetClassSuffix()
        {
            return "ReactiveMetroWindow";
        }
    }
}
