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
