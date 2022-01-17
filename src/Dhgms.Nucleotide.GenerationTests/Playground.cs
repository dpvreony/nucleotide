// Copyright (c) 2020 DHGMS Solutions and Contributors. All rights reserved.
// DHGMS Solutions and Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

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
