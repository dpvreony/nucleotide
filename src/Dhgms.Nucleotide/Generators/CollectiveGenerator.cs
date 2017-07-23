//namespace Dhgms.Nucleotide.Generators
//{
//    using System;
//    using System.Collections.Generic;
//    using System.Text;

//    using Dhgms.Nucleotide.Model;

//    /// <summary>
//    /// Generator class
//    /// </summary>
//    public class CollectiveGenerator
//    {
//        /// <summary>
//        /// Generates the code for the template.
//        /// </summary>
//        /// <param name="classes">
//        /// The collection of classes to generate code for
//        /// </param>
//        /// <param name="generationFlags">
//        /// The generation flags for which code to generate.
//        /// </param>
//        /// <returns>
//        /// </returns>
//        public string Generate(IList<IEntityGenerationModel> classes, GenerationFlags generationFlags)
//        {
//            if (classes == null)
//            {
//                throw new ArgumentNullException("classes");
//            }

//            if (classes.Count < 1)
//            {
//                throw new ArgumentException("classes must have at least one item", "classes");
//            }

//            if (generationFlags == GenerationFlags.None)
//            {
//                throw new ArgumentOutOfRangeException("generationFlags");
//            }

//            var output = new StringBuilder();

//            var rules = new List<Tuple<GenerationFlags, Func<IList<IEntityGenerationModel>, string>>>
//                            {
//                                // information interface rule
//                                new Tuple<GenerationFlags, Func<IList<IEntityGenerationModel>, string>>(
//                                    generationFlags & GenerationFlags.InformationInterface,
//                                    list => new InformationInterfaceGenerator().Generate(list, false)),

//                                // information class rule
//                                new Tuple<GenerationFlags, Func<IList<IEntityGenerationModel>, string>>(
//                                    generationFlags & GenerationFlags.InformationClass,
//                                    list => new InformationClassGenerator().Generate(list, false)),

//                                // difference interface rule
//                                new Tuple<GenerationFlags, Func<IList<IEntityGenerationModel>, string>>(
//                                    generationFlags & GenerationFlags.DifferenceInterface,
//                                    list => new DifferenceInterfaceGenerator().Generate(list, false)),

//                                // difference class rule
//                                new Tuple<GenerationFlags, Func<IList<IEntityGenerationModel>, string>>(
//                                    generationFlags & GenerationFlags.DifferenceClass,
//                                    list => new DifferenceClassGenerator().Generate(list, false)),

//                                    /*
//                                // delta interface rule
//                                new Tuple<GenerationFlags, Func<IList<IEntityGenerationModel>, string>>(
//                                    generationFlags & GenerationFlags.DeltaInterface,
//                                    list => new DeltaInterfaceGenerator().Generate(list)),

//                                // delta class rule
//                                new Tuple<GenerationFlags, Func<IList<IEntityGenerationModel>, string>>(
//                                    generationFlags & GenerationFlags.DeltaClass,
//                                    list => new DeltaClassGenerator().Generate(list)),
//                                     * */

//                                // search filter interface rule
//                                /*
//                                new Tuple<GenerationFlags, Func<IList<IEntityGenerationModel>, string>>(
//                                    generationFlags & GenerationFlags.SearchFilterInterface,
//                                    list => new SearchFilter().Generate(list)),

//                                // search filter class rule
//                                new Tuple<GenerationFlags, Func<IList<IEntityGenerationModel>, string>>(
//                                    generationFlags & GenerationFlags.SearchFilterClass,
//                                    list => new InformationInterfaceGenerator().Generate(list)),
//                                 * */

//                                // ADO.NET
//                                new Tuple<GenerationFlags, Func<IList<IEntityGenerationModel>, string>>(
//                                    generationFlags & GenerationFlags.AdoNetClass,
//                                    list => new AdoNetGenerator().Generate(list, false)),

//                                // Entity Framework
//                                //new Tuple<GenerationFlags, Func<IList<IEntityGenerationModel>, string>>(
//                                //    generationFlags & GenerationFlags.AdoNetClass,
//                                //    list => new EntityFrameworkHelpers().Generate(list)),
//                            };

//            foreach (var tuple in rules)
//            {
//                if (tuple.Item1 != GenerationFlags.None)
//                {
//                    output.Append(tuple.Item2(classes));
//                }
//            }


//            if ((generationFlags & GenerationFlags.InformationInterface) != GenerationFlags.None)
//            {
//                ;                
//            }

//            if ((generationFlags & GenerationFlags.DifferenceInterface) != GenerationFlags.None)
//            {
//                output.Append(new DifferenceInterfaceGenerator().Generate(classes));
//            }


//            output.Append(new InformationClassGenerator().Generate(classes));

//            output.Append(new DifferenceClassGenerator().Generate(classes));

//            return output.ToString();
//        }
//    }
//}
