using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dhgms.EfCoreContrib
{
    public static class PropertyBuilderExtensions
    {
        public static PropertyBuilder<T> HasDescriptionSql<T>(this PropertyBuilder<T> propertyBuilder, string description)
        {
            propertyBuilder.HasAnnotation("Description", description);

            return propertyBuilder;
        }
    }
}
