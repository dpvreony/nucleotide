﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SingleSimple.cs" company="DHGMS Solutions">
//   2004-2012 DHGMS Solutions. Some Rights Reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NucleotideGenerated.cs" company="DHGMS Solutions">
//   Copyright 2008-2017 DHGMS Solutions
//   
//   bleh
// </copyright>
// <summary>
//   Code Generated by Nucleotide.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TestDhgms.NucleotideMocking.Model
{
        /// <summary>
        /// Represents a class containing properties that are simple
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCode("DHGMS Nucleotide", "0.1504.9.1")]
        public interface ISingleSimple : IUnkeyedSingleSimple
        {
            /// <summary>Gets Unique Id</summary>
            int Id { get; }

        }

        /// <summary>
        /// Un-keyed interface for Represents a class containing properties that are simple
        /// </summary>
        /// <remarks>
        /// Un-keyed interfaces are used in services that allow creation of new objects.
        /// </remarks>
        public interface IUnkeyedSingleSimple
        {
            /// <summary>Gets Name</summary>
            string Name { get; }

        }
}

// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NucleotideGenerated.cs" company="DHGMS Solutions">
//   Copyright 2008-2017 DHGMS Solutions
//   
//   bleh
// </copyright>
// <summary>
//   Code Generated by Nucleotide.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TestDhgms.NucleotideMocking.Model
{
        /// <summary>
        /// Represents a class containing properties that are simple
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCode("DHGMS Nucleotide", "0.1504.9.1")]
        public interface ISingleSimpleDifference : IUnkeyedSingleSimpleDifference
        {
            /// <summary>Gets a value indicating whether there is a difference for Unique Id</summary>
            bool Id { get; }

        }

        /// <summary>
        /// Un-keyed interface for Represents a class containing properties that are simpleDifference
        /// </summary>
        /// <remarks>
        /// Un-keyed interfaces are used in services that allow creation of new objects.
        /// </remarks>
        public interface IUnkeyedSingleSimpleDifference
        {
            /// <summary>Gets a value indicating whether there is a difference for Name</summary>
            bool Name { get; }

        }
}

// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NucleotideGenerated.cs" company="DHGMS Solutions">
//   Copyright 2008-2017 DHGMS Solutions
//   
//   bleh
// </copyright>
// <summary>
//   Code Generated by Nucleotide.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TestDhgms.NucleotideMocking.Model
{

        // ********** WARNING **********
        // This code is automatically generated! Any Changes you make to this file will be lost!
        // To make changes edit the corresponding .tt file!

        /// <summary>
        /// Represents a class containing properties that are simple
        /// </summary>
        [System.Runtime.Serialization.DataContract]
        [System.CodeDom.Compiler.GeneratedCode("DHGMS Nucleotide", "0.1504.9.1")]
        public class SingleSimple
// ReSharper disable RedundantNameQualifier
            : Dhgms.DataManager.Model.Info.InfoBase<SingleSimple>, ISingleSimple
// ReSharper restore RedundantNameQualifier
        {
        #region fields
        #endregion

        // ********** WARNING **********
        // This code is automatically generated! Any Changes you make to this file will be lost!
        // To make changes edit the corresponding .tt file!

        /// <summary>
        /// Initializes a new instance of the <see cref="SingleSimple"/> class.
        /// </summary>
        public SingleSimple()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SingleSimple"/> class.
        /// </summary>
        /// <param name="other">
        /// Object to copy
        /// </param>
        public SingleSimple(SingleSimple other)
        {
            if (other == null)
            {
                throw new System.ArgumentNullException("other");
            }

            this.Id = other.Id;
            this.Name = other.Name;
        }

        // ********** WARNING **********
        // This code is automatically generated! Any Changes you make to this file will be lost!
        // To make changes edit the corresponding .tt file!

        /// <summary>
        /// Initializes a new instance of the <see cref="SingleSimple"/> class.
        /// </summary>
        /// <param name="id">Unique Id</param>
        /// <param name="name">Name</param>
        public SingleSimple(
            int id,
            string name)
            {
            this.Id = id;
            this.Name = name;
        }

        #region properties
        /// <summary>
        /// Gets or sets Unique Id
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1121:UseBuiltInTypeAlias", Justification = "Reviewed. Suppression is OK here.")]
        [System.Runtime.Serialization.DataMember(IsRequired = true, Order = 1)]
        [System.ComponentModel.DataAnnotations.Required]
[System.ComponentModel.DataAnnotations.Range(typeof(int), "", "")]
        public int Id
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets Name
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1121:UseBuiltInTypeAlias", Justification = "Reviewed. Suppression is OK here.")]
        [System.Runtime.Serialization.DataMember(IsRequired = true, Order = 2)]
        [System.ComponentModel.DataAnnotations.Required]
        public string Name
        {
            get;
            set;
        }

        #endregion

        #region IComparable methods

        // ********** WARNING **********
        // This code is automatically generated! Any Changes you make to this file will be lost!
        // To make changes edit the corresponding .tt file!

        /// <summary>
        /// Compares the current instance with another object of the same type.
        /// </summary>
        /// <param name="other">
        /// The instance to compare to
        /// </param>
        /// <returns>
        /// 0 if equal, otherwise non zero
        /// </returns>
        public override int CompareTo(SingleSimple other)
        {
            if (other == null)
            {
                throw new System.ArgumentNullException("other");
            }

            // Id
            var checkResult = this.Id.CompareTo(other.Id);

            if (checkResult != 0)
            {
                return (checkResult > 0) ? 1 : -1;
            }

            // Name
            checkResult = string.CompareOrdinal(this.Name, other.Name);

            if (checkResult != 0)
            {
                return (checkResult > 0) ? 2 : -2;
            }

            return 0;
        }

        #endregion
#region IEquatable methods
            /// <summary>
            /// Checks if the current instance matches another of the same type
            /// </summary>
            /// <param name="other">object to compare</param>
            /// <returns>true if equal, otherwise false</returns>
            public override bool Equals(SingleSimple other)
            {
                return this.CompareTo(other) == 0;
            }

#endregion

    #region our methods

        /// <summary>
        /// Gets the hash code for the object
        /// </summary>
        /// <returns>hash code</returns>
        public override int GetHashCode()
        {
            return
                this.Id.GetHashCode()
                ^ (this.Name != null ? this.Name.GetHashCode() : 0);
        }




        /// <summary>
        /// Checks this instance against another to see where there are differences
        /// </summary>
        /// <param name="other">other instance to compare</param>
        /// <returns>summary of where there are differences</returns>
// ReSharper disable RedundantNameQualifier
        public TestDhgms.NucleotideMocking.Model.SingleSimpleDifference GetDifferences(SingleSimple other)
// ReSharper restore RedundantNameQualifier
        {
            if (other == null)
            {
                throw new System.ArgumentNullException("other");
            }

            // Id
            var checkResult = this.Id.CompareTo(other.Id);

            var idDifferent = checkResult != 0;

            // Name
            checkResult = string.CompareOrdinal(this.Name, other.Name);

            var nameDifferent = checkResult != 0;

// ReSharper disable RedundantNameQualifier
            return new TestDhgms.NucleotideMocking.Model.SingleSimpleDifference(
// ReSharper restore RedundantNameQualifier
                idDifferent,
                nameDifferent);
        }

        #endregion
            /// <summary>
            /// The on disposing event
            /// </summary>
            protected override void OnDisposing()
            {
            }
    }
}

// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NucleotideGenerated.cs" company="DHGMS Solutions">
//   Copyright 2008-2017 DHGMS Solutions
//   
//   bleh
// </copyright>
// <summary>
//   Code Generated by Nucleotide.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TestDhgms.NucleotideMocking.Model
{

        // ********** WARNING **********
        // This code is automatically generated! Any Changes you make to this file will be lost!
        // To make changes edit the corresponding .tt file!

        /// <summary>
        /// Represents a class containing properties that are simple
        /// </summary>
        [System.Runtime.Serialization.DataContract]
        [System.CodeDom.Compiler.GeneratedCode("DHGMS Nucleotide", "0.1504.9.1")]
        public class SingleSimpleDifference
// ReSharper disable RedundantNameQualifier
            : Dhgms.DataManager.Model.Info.DifferenceBase<SingleSimpleDifference>, ISingleSimpleDifference
// ReSharper restore RedundantNameQualifier
        {
        // ********** WARNING **********
        // This code is automatically generated! Any Changes you make to this file will be lost!
        // To make changes edit the corresponding .tt file!

        /// <summary>
        /// Initializes a new instance of the <see cref="SingleSimpleDifference"/> class.
        /// </summary>
        public SingleSimpleDifference()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SingleSimpleDifference"/> class.
        /// </summary>
        /// <param name="other">
        /// Object to copy
        /// </param>
        public SingleSimpleDifference(SingleSimpleDifference other)
        {
            if (other == null)
            {
                throw new System.ArgumentNullException("other");
            }

            this.Id = other.Id;
            this.Name = other.Name;
        }

        // ********** WARNING **********
        // This code is automatically generated! Any Changes you make to this file will be lost!
        // To make changes edit the corresponding .tt file!

        /// <summary>
        /// Initializes a new instance of the <see cref="SingleSimpleDifference"/> class.
        /// </summary>
        /// <param name="id">Unique Id</param>
        /// <param name="name">Name</param>
        public SingleSimpleDifference(
            bool id,
            bool name)
            {
            this.Id = id;
            this.Name = name;
        }

        #region properties
        /// <summary>
        /// Unique Id
        /// </summary>
        public bool Id
        {
            get;
            set;
        }

        /// <summary>
        /// Name
        /// </summary>
        public bool Name
        {
            get;
            set;
        }

            /// <summary>
            /// Gets the number of properties that are different
            /// </summary>
            /// <return>
            /// the number of properties that are different
            /// </return>
            public override int Count
            {
                get
                {
                    return
                    (Id ? 1 : 0)
                    + (Name ? 1 : 0)
                    ;
                }
            }

        #endregion

        #region IComparable methods

        // ********** WARNING **********
        // This code is automatically generated! Any Changes you make to this file will be lost!
        // To make changes edit the corresponding .tt file!

        /// <summary>
        /// Compares the current instance with another object of the same type.
        /// </summary>
        /// <param name="other">
        /// The instance to compare to
        /// </param>
        /// <returns>
        /// 0 if equal, otherwise non zero
        /// </returns>
        public override int CompareTo(SingleSimpleDifference other)
        {
            if (other == null)
            {
                throw new System.ArgumentNullException("other");
            }

            int             checkResult = Id.CompareTo(other.Id);
            if(checkResult != 0)
            {
                return (checkResult > 0) ? 1 : -1;
            }

                        checkResult = Name.CompareTo(other.Name);
            if(checkResult != 0)
            {
                return (checkResult > 0) ? 2 : -2;
            }

            return 0;
        }

        #endregion
#region IEquatable methods
            /// <summary>
            /// Checks if the current instance matches another of the same type
            /// </summary>
            /// <param name="other">object to compare</param>
            /// <returns>true if equal, otherwise false</returns>
            public override bool Equals(SingleSimpleDifference other)
            {
                return this.CompareTo(other) == 0;
            }

#endregion

    #region our methods

        /// <summary>
        /// Gets the hash code for the object
        /// </summary>
        /// <returns>hash code</returns>
        public override int GetHashCode()
        {
            return
                this.Id.GetHashCode()
                ^ this.Name.GetHashCode();
        }




        #endregion
            /// <summary>
            /// The on disposing event
            /// </summary>
            protected override void OnDisposing()
            {
            }
    }
}

