﻿using Dhgms.Nucleotide.Generators.Generators;
using Dhgms.Nucleotide.Generators.Models;

namespace Dhgms.Nucleotide.Generators.Features.Logging
{
    public abstract class CrudControllerLoggerMessageActionGenerator : BaseClassLevelCodeGenerator<CrudControllerLoggerMessageActionFeatureFlags, CrudControllerLoggerMessageActionGeneratorProcessor, IEntityGenerationModel>
    {
        /// <inheritdoc />
        protected override string GetNamespace()
        {
            return "LoggerMessageActions";
        }
    }
}
