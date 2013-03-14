// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SingleSimple.cs" company="DHGMS Solutions">
//   2004-2012 DHGMS Solutions. Some Rights Reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace TestDhgms.NucleotideMocking.Model.Info
{
        using System.Diagnostics.CodeAnalysis;

        // ********** WARNING **********
        // This code is automatically generated! Any Changes you make to this file will be lost!
        // To make changes edit the corresponding .tt file!

        /// <summary>
        /// Represents a class containing properties that are simple
        /// </summary>
        public class SingleSimple
// ReSharper disable RedundantNameQualifier
            : Dhgms.DataManager.Model.Info.Base<SingleSimple>
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

        // ********** WARNING **********
        // This code is automatically generated! Any Changes you make to this file will be lost!
        // To make changes edit the corresponding .tt file!

        /// <summary>
        /// Initializes a new instance of the <see cref="SingleSimple"/> class.
        /// </summary>
        /// <param name="id">Unique Id</param>
        /// <param name="name">Name</param>
        public SingleSimple(
            System.Int32 id,
            string name
                )
            {
            Id = id;
            Name = name;
        }

        #region properties
        /// <summary>
        /// Gets or sets Unique Id
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1121:UseBuiltInTypeAlias", Justification = "Reviewed. Suppression is OK here.")]
        public System.Int32 Id
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets Name
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1121:UseBuiltInTypeAlias", Justification = "Reviewed. Suppression is OK here.")]
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
                Id.GetHashCode()
                ^ Name.GetHashCode()
                ;
        }

        /// <summary>
        /// Get Strongly Typed Object from a data reader
        /// </summary>
        public override SingleSimple GetStronglyTypedObjectFromDataReaderRow(
            System.Data.Common.DbDataReader dataReader
            )
        {
            if(dataReader == null)
            {
                throw new System.ArgumentNullException("dataReader");
            }

            //get ordinals
            int idOrdinal = dataReader.GetOrdinal("Id");
            int nameOrdinal = dataReader.GetOrdinal("Name");

            //get row data
            System.Int32 id = 0;
            if(idOrdinal > -1)
            {
                id = dataReader.GetInt32(idOrdinal);
            }

            string name = null;
            if(nameOrdinal > -1)
            {
                name = dataReader.GetString(nameOrdinal);
            }


            return new SingleSimple(
                id
                ,name
                );
        }

        /// <summary>
        /// Checks a table to ensure it meets the required schema
        /// </summary>
        public override void DoTableValidation(
            )
        {
            //Id

            //Name

        }
            /// <summary>
            /// Gets a header record for use for something like a CSV file
            /// </summary>
            /// <returns>a collection of strings representing the header record</returns>
            public override System.Collections.Generic.IList<System.String> HeaderRecord
            {
                get
                {
                    System.Collections.Generic.List<System.String> result = new System.Collections.Generic.List<System.String>
                    {
                        "Id"
                        ,"Name"
                    };

                    return result;
                }
            }
            /// <summary>
            /// Gets a collection of string data for use for something like a CSV file
            /// </summary>
            /// <returns>a collection of strings representing the data record</returns>
            public override System.Collections.Generic.IList<System.String> ToStringArray()
            {
                System.Collections.Generic.List<System.String> result = new System.Collections.Generic.List<System.String>
                {
                    Id.ToString(System.Globalization.CultureInfo.InvariantCulture)
                    ,Name.ToString(System.Globalization.CultureInfo.InvariantCulture)
                };

                return result;
            }
            /// <summary>
            /// Gets a collection of data columns representing the type
            /// </summary>
            /// <returns>a collection of strings representing the data record</returns>
            public override System.Data.DataColumn[] GetDataColumns()
            {

                System.Collections.Generic.List<System.Data.DataColumn> result =
                    new System.Collections.Generic.List<System.Data.DataColumn>
                {
                    new System.Data.DataColumn("Id", typeof(System.Int32))
                    ,new System.Data.DataColumn("Name", typeof(string))
                };

                return result.ToArray();
            }
        /// <summary>
        /// Checks this instance against another to see where there are differences
        /// </summary>
        /// <param name="other">other instance to compare</param>
        /// <returns>summary of where there are differences</returns>
// ReSharper disable RedundantNameQualifier
        public TestDhgms.NucleotideMocking.Model.Difference.SingleSimple GetDifferences(
// ReSharper restore RedundantNameQualifier
            SingleSimple other
            )
        {
            if (other == null)
            {
                throw new System.ArgumentNullException("other");
            }

            //Id
            var checkResult = this.Id.CompareTo(other.Id);

            var id = checkResult != 0;

            //Name
            checkResult = string.CompareOrdinal(this.Name, other.Name);

            var name = checkResult != 0;

// ReSharper disable RedundantNameQualifier
            return new TestDhgms.NucleotideMocking.Model.Difference.SingleSimple(
// ReSharper restore RedundantNameQualifier
                id
                ,name
                );
        }

        #endregion
    }
}

namespace TestDhgms.NucleotideMocking.Model.SearchFilter
{
        using System.Diagnostics.CodeAnalysis;

        // ********** WARNING **********
        // This code is automatically generated! Any Changes you make to this file will be lost!
        // To make changes edit the corresponding .tt file!

        /// <summary>
        /// Represents a class containing properties that are simple
        /// </summary>
        public class SingleSimple
// ReSharper disable RedundantNameQualifier
            : Dhgms.DataManager.Model.Info.SearchFilter.Base<SingleSimple>
// ReSharper restore RedundantNameQualifier
        {
        // ********** WARNING **********
        // This code is automatically generated! Any Changes you make to this file will be lost!
        // To make changes edit the corresponding .tt file!

        /// <summary>
        /// Initializes a new instance of the <see cref="SingleSimple"/> class.
        /// </summary>
        public SingleSimple()
        {
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
            Dhgms.DataManager.Model.SearchFilterComparison.Base id,
            Dhgms.DataManager.Model.SearchFilterComparison.Base name
                )
            {
            Id = id;
            Name = name;
        }

		#region properties
		/// <summary>
		/// Unique Id
		/// </summary>
		public Dhgms.DataManager.Model.SearchFilterComparison.Base Id
		{
			get;
			set;
		}

		/// <summary>
		/// Name
		/// </summary>
		public Dhgms.DataManager.Model.SearchFilterComparison.Base Name
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

			int 			checkResult = Id.CompareTo(other.Id);
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
                Id.GetHashCode()
                ^ Name.GetHashCode()
                ;
        }

		/// <summary>
		/// Get Strongly Typed Object from a data reader
		/// </summary>
		public override SingleSimple GetStronglyTypedObjectFromDataReaderRow(
			System.Data.Common.DbDataReader dataReader
			)
		{
			throw new System.NotImplementedException();
		}

        /// <summary>
        /// Checks a table to ensure it meets the required schema
        /// </summary>
        public override void DoTableValidation(
            )
        {
            //Id

            //Name

        }
            /// <summary>
            /// Gets a header record for use for something like a CSV file
            /// </summary>
            /// <returns>a collection of strings representing the header record</returns>
            public override System.Collections.Generic.IList<System.String> HeaderRecord
            {
                get
                {
                    System.Collections.Generic.List<System.String> result = new System.Collections.Generic.List<System.String>
                    {
                        "Id"
                        ,"Name"
                    };

                    return result;
                }
            }
			/// <summary>
			/// Gets a collection of string data for use for something like a CSV file
			/// </summary>
			/// <returns>a collection of strings representing the data record</returns>
			public override System.Collections.Generic.IList<System.String> ToStringArray()
			{
				throw new System.NotImplementedException();
			}
			/// <summary>
			/// Gets a collection of data columns representing the type
			/// </summary>
			/// <returns>a collection of strings representing the data record</returns>
			public override System.Data.DataColumn[] GetDataColumns()
			{
				throw new System.NotImplementedException();
			}
        #endregion
    }
}

namespace TestDhgms.NucleotideMocking.Model.ViewFilter
{
        using System.Diagnostics.CodeAnalysis;

        // ********** WARNING **********
        // This code is automatically generated! Any Changes you make to this file will be lost!
        // To make changes edit the corresponding .tt file!

        /// <summary>
        /// Represents a class containing properties that are simple
        /// </summary>
        public class SingleSimple
// ReSharper disable RedundantNameQualifier
            : Dhgms.DataManager.Model.Info.ViewFilter<SingleSimple>
// ReSharper restore RedundantNameQualifier
        {
        // ********** WARNING **********
        // This code is automatically generated! Any Changes you make to this file will be lost!
        // To make changes edit the corresponding .tt file!

		/// <summary>
		/// Constructor
		/// </summary>
		public SingleSimple() : base(1,0)
		{
		}

        // ********** WARNING **********
        // This code is automatically generated! Any Changes you make to this file will be lost!
        // To make changes edit the corresponding .tt file!

		/// <summary>
		/// Constructor
		/// </summary>
        /// <param name="id">Unique Id</param>
        /// <param name="name">Name</param>
		/// <param name="pageNumber">The number of the page being retrieved</param>
		/// <param name="pageSize">The size of pages being retrieved</param>
		public SingleSimple(
            bool id,
            bool name
			,System.Int32 pageNumber
			,System.Int32 pageSize
			) : base(
				pageNumber
				,pageSize
				)
			{
			Id = id;
			Name = name;
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

			int checkResult = Id.CompareTo(other.Id);
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
                Id.GetHashCode()
                ^ Name.GetHashCode()
                ;
        }

		/// <summary>
		/// Get Strongly Typed Object from a data reader
		/// </summary>
		public override SingleSimple GetStronglyTypedObjectFromDataReaderRow(
			System.Data.Common.DbDataReader dataReader
			)
		{
			if(dataReader == null)
			{
				throw new System.ArgumentNullException("dataReader");
			}

			//get ordinals
            int idOrdinal = dataReader.GetOrdinal("Id");
            int nameOrdinal = dataReader.GetOrdinal("Name");
			int pageNumberOrdinal = dataReader.GetOrdinal("pageNumber");
			int pageSizeOrdinal = dataReader.GetOrdinal("pageSize");

			//get row data
			bool id =
				(idOrdinal > -1) && (dataReader.GetBoolean(idOrdinal));

			bool name =
				(nameOrdinal > -1) && (dataReader.GetBoolean(nameOrdinal));

			System.Int32 pageNumber = 0;
			if(pageNumberOrdinal > -1)
			{
				pageNumber = dataReader.GetInt32(pageNumberOrdinal);
			}

			System.Int32 pageSize = 0;
			if(pageSizeOrdinal > -1)
			{
				pageSize = dataReader.GetInt32(pageSizeOrdinal);
			}


			return new SingleSimple(
				id
				,name
				,pageNumber
				,pageSize
				);
		}

        /// <summary>
        /// Checks a table to ensure it meets the required schema
        /// </summary>
        public override void DoTableValidation(
            )
        {
            //Id

            //Name

        }
            /// <summary>
            /// Gets a header record for use for something like a CSV file
            /// </summary>
            /// <returns>a collection of strings representing the header record</returns>
            public override System.Collections.Generic.IList<System.String> HeaderRecord
            {
                get
                {
                    System.Collections.Generic.List<System.String> result = new System.Collections.Generic.List<System.String>
                    {
                        "Id"
                        ,"Name"
                    };

                    return result;
                }
            }
            /// <summary>
            /// Gets a collection of string data for use for something like a CSV file
            /// </summary>
            /// <returns>a collection of strings representing the data record</returns>
            public override System.Collections.Generic.IList<System.String> ToStringArray()
            {
                System.Collections.Generic.List<System.String> result = new System.Collections.Generic.List<System.String>
                {
                    Id? "1" : "0"
                    ,Name? "1" : "0"
                };

                return result;
            }
            /// <summary>
            /// Gets a collection of data columns representing the type
            /// </summary>
            /// <returns>a collection of strings representing the data record</returns>
            public override System.Data.DataColumn[] GetDataColumns()
            {

                System.Collections.Generic.List<System.Data.DataColumn> result =
                    new System.Collections.Generic.List<System.Data.DataColumn>
                {
                    new System.Data.DataColumn("Id", typeof(System.Int32))
                    ,new System.Data.DataColumn("Name", typeof(string))
                };

                return result.ToArray();
            }
		/// <summary>
		/// Gets a comma separated list of column names
		/// </summary>
		/// <returns>a comma separated list of column names</returns>
		public override System.String GetSelectedColumnNames()
		{
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
			System.String comma = null;
			//Id
			if(Id)
			{
				sb.AppendLine("Id");

				comma = ",";
			}
			//Name
			if(Name)
			{
				sb.AppendLine(comma + "Name");

				if(comma == null)
				{
					comma = ",";
				}
			}
			return sb.ToString();
		}

        #endregion
    }
}

namespace TestDhgms.NucleotideMocking.Model.Difference
{
        using System.Diagnostics.CodeAnalysis;

        // ********** WARNING **********
        // This code is automatically generated! Any Changes you make to this file will be lost!
        // To make changes edit the corresponding .tt file!

        /// <summary>
        /// Represents a class containing properties that are simple
        /// </summary>
        public class SingleSimple
// ReSharper disable RedundantNameQualifier
            : Dhgms.DataManager.Model.Info.Difference<SingleSimple>
// ReSharper restore RedundantNameQualifier
        {
        // ********** WARNING **********
        // This code is automatically generated! Any Changes you make to this file will be lost!
        // To make changes edit the corresponding .tt file!

        /// <summary>
        /// Initializes a new instance of the <see cref="SingleSimple"/> class.
        /// </summary>
        public SingleSimple()
        {
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
            bool id,
            bool name
                )
            {
            Id = id;
            Name = name;
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
                    ((Id) ? 1 : 0)
                    + ((Name) ? 1 : 0)
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
        public override int CompareTo(SingleSimple other)
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
                Id.GetHashCode()
                ^ Name.GetHashCode()
                ;
        }

        /// <summary>
        /// Get Strongly Typed Object from a data reader
        /// </summary>
        public override SingleSimple GetStronglyTypedObjectFromDataReaderRow(
            System.Data.Common.DbDataReader dataReader
            )
        {
            if(dataReader == null)
            {
                throw new System.ArgumentNullException("dataReader");
            }

            //get ordinals
            int idOrdinal = dataReader.GetOrdinal("Id");
            int nameOrdinal = dataReader.GetOrdinal("Name");

            //get row data
            bool id = false;
            if(idOrdinal > -1)
            {
                id = dataReader.GetBoolean(idOrdinal);
            }

            bool name = false;
            if(nameOrdinal > -1)
            {
                name = dataReader.GetBoolean(nameOrdinal);
            }


            return new SingleSimple(
                id
                ,name
                );
        }

        /// <summary>
        /// Checks a table to ensure it meets the required schema
        /// </summary>
        public override void DoTableValidation(
            )
        {
            //Id

            //Name

        }
            /// <summary>
            /// Gets a header record for use for something like a CSV file
            /// </summary>
            /// <returns>a collection of strings representing the header record</returns>
            public override System.Collections.Generic.IList<System.String> HeaderRecord
            {
                get
                {
                    System.Collections.Generic.List<System.String> result = new System.Collections.Generic.List<System.String>
                    {
                        "Id"
                        ,"Name"
                    };

                    return result;
                }
            }
            /// <summary>
            /// Gets a collection of string data for use for something like a CSV file
            /// </summary>
            /// <returns>a collection of strings representing the data record</returns>
            public override System.Collections.Generic.IList<System.String> ToStringArray()
            {
                System.Collections.Generic.List<System.String> result = new System.Collections.Generic.List<System.String>
                {
                    Id? "1" : "0"
                    ,Name? "1" : "0"
                };

                return result;
            }
            /// <summary>
            /// Gets a collection of data columns representing the type
            /// </summary>
            /// <returns>a collection of strings representing the data record</returns>
            public override System.Data.DataColumn[] GetDataColumns()
            {

                System.Collections.Generic.List<System.Data.DataColumn> result =
                    new System.Collections.Generic.List<System.Data.DataColumn>
                {
                    new System.Data.DataColumn("Id", typeof(System.Int32))
                    ,new System.Data.DataColumn("Name", typeof(string))
                };

                return result.ToArray();
            }

        /// <summary>
        /// Gets the names of the columns that are different
        /// </summary>
        /// <return>
        /// list of names of the columns that are different
        /// </return>
        public override System.Collections.Generic.IList<System.String> GetColumnNames()
        {
            System.Collections.Generic.List<System.String> columns = new System.Collections.Generic.List<System.String>();
            if(Id)
            {
                columns.Add("Id");
            }

            if(Name)
            {
                columns.Add("Name");
            }

            return columns;
        }

        #endregion
    }
}

