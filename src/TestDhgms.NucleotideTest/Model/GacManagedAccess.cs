// http://blogs.msdn.com/b/junfeng/archive/2004/09/14/229649.aspx

namespace TestDhgms.NucleotideTest.Model
{
    //-------------------------------------------------------------
    // GACWrap.cs
    //
    // This implements managed wrappers to GAC API Interfaces
    //-------------------------------------------------------------

    using System;
    using System.Runtime.InteropServices;
    using System.Text;

    /// <summary>
    /// Interfaces defined by fusion
    /// </summary>
    [ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("e707dcde-d1cd-11d2-bab9-00c04f8eceae")]
    internal interface IAssemblyCache
    {
        /// <summary>
        /// Uninstall the assembly
        /// </summary>
        /// <param name="flags">
        /// The flags.
        /// </param>
        /// <param name="assemblyName">
        /// The assembly name.
        /// </param>
        /// <param name="refData">
        /// The ref data.
        /// </param>
        /// <param name="disposition">
        /// The disposition.
        /// </param>
        /// <returns>
        /// 
        /// </returns>
        [PreserveSig]
        int UninstallAssembly(
                            int flags,
                            [MarshalAs(UnmanagedType.LPWStr)]
                            string assemblyName,
                            InstallReference refData,
                            out AssemblyCacheUninstallDisposition disposition);

        /// <summary>
        /// </summary>
        /// <param name="flags">
        /// The flags.
        /// </param>
        /// <param name="assemblyName">
        /// The assembly name.
        /// </param>
        /// <param name="assemblyInfo">
        /// The assembly info.
        /// </param>
        /// <returns>
        /// </returns>
        [PreserveSig]
        int QueryAssemblyInfo(
                            int flags,
                            [MarshalAs(UnmanagedType.LPWStr)]
                            String assemblyName,
                            ref AssemblyInfo assemblyInfo);

        /// <summary>
        /// </summary>
        /// <param name="flags">
        /// The flags.
        /// </param>
        /// <param name="pvReserved">
        /// The pv reserved.
        /// </param>
        /// <param name="ppAsmItem">
        /// The pp asm item.
        /// </param>
        /// <param name="assemblyName">
        /// The assembly name.
        /// </param>
        /// <returns>
        /// </returns>
        [PreserveSig]
        int Reserved(
                            int flags,
                            IntPtr pvReserved,
                            out Object ppAsmItem,
                            [MarshalAs(UnmanagedType.LPWStr)]
                            String assemblyName);

        /// <summary>
        /// </summary>
        /// <param name="ppAsmScavenger">
        /// The pp asm scavenger.
        /// </param>
        /// <returns>
        /// </returns>
        [PreserveSig]
        int Reserved(out Object ppAsmScavenger);

        /// <summary>
        /// </summary>
        /// <param name="flags">
        /// The flags.
        /// </param>
        /// <param name="assemblyFilePath">
        /// The assembly file path.
        /// </param>
        /// <param name="refData">
        /// The ref data.
        /// </param>
        /// <returns>
        /// </returns>
        [PreserveSig]
        int InstallAssembly(
                            int flags,
                            [MarshalAs(UnmanagedType.LPWStr)]
                            String assemblyFilePath,
                            InstallReference refData);
    }// IAssemblyCache

    /// <summary>
    /// </summary>
    [ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("CD193BC0-B4BC-11d2-9833-00C04FC31D2E")]
    internal interface IAssemblyName
    {
        /// <summary>
        /// </summary>
        /// <param name="propertyId">
        /// The property id.
        /// </param>
        /// <param name="pvProperty">
        /// The pv property.
        /// </param>
        /// <param name="cbProperty">
        /// The cb property.
        /// </param>
        /// <returns>
        /// </returns>
        [PreserveSig]
        int SetProperty(
                int propertyId,
                IntPtr pvProperty,
                int cbProperty);

        /// <summary>
        /// </summary>
        /// <param name="propertyId">
        /// The property id.
        /// </param>
        /// <param name="pvProperty">
        /// The pv property.
        /// </param>
        /// <param name="pcbProperty">
        /// The pcb property.
        /// </param>
        /// <returns>
        /// </returns>
        [PreserveSig]
        int GetProperty(
                int propertyId,
                IntPtr pvProperty,
                ref int pcbProperty);

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        [PreserveSig]
        int Finalize();

        /// <summary>
        /// </summary>
        /// <param name="pDisplayName">
        /// The p display name.
        /// </param>
        /// <param name="pccDisplayName">
        /// The pcc display name.
        /// </param>
        /// <param name="displayFlags">
        /// The display flags.
        /// </param>
        /// <returns>
        /// </returns>
        [PreserveSig]
        int GetDisplayName(
                StringBuilder pDisplayName,
                ref int pccDisplayName,
                int displayFlags);

        /// <summary>
        /// </summary>
        /// <param name="guid">
        /// The guid.
        /// </param>
        /// <param name="obj1">
        /// The obj 1.
        /// </param>
        /// <param name="obj2">
        /// The obj 2.
        /// </param>
        /// <param name="string1">
        /// The string 1.
        /// </param>
        /// <param name="llFlags">
        /// The ll flags.
        /// </param>
        /// <param name="pvReserved">
        /// The pv reserved.
        /// </param>
        /// <param name="cbReserved">
        /// The cb reserved.
        /// </param>
        /// <param name="ppv">
        /// The ppv.
        /// </param>
        /// <returns>
        /// </returns>
        [PreserveSig]
        int Reserved(ref Guid guid,
            Object obj1,
            Object obj2,
            String string1,
            Int64 llFlags,
            IntPtr pvReserved,
            int cbReserved,
            out IntPtr ppv);

        /// <summary>
        /// </summary>
        /// <param name="pccBuffer">
        /// The pcc buffer.
        /// </param>
        /// <param name="pwzName">
        /// The pwz name.
        /// </param>
        /// <returns>
        /// </returns>
        [PreserveSig]
        int GetName(
                ref int pccBuffer,
                StringBuilder pwzName);

        /// <summary>
        /// </summary>
        /// <param name="versionHi">
        /// The version hi.
        /// </param>
        /// <param name="versionLow">
        /// The version low.
        /// </param>
        /// <returns>
        /// </returns>
        [PreserveSig]
        int GetVersion(
                out int versionHi,
                out int versionLow);

        /// <summary>
        /// </summary>
        /// <param name="pAsmName">
        /// The p asm name.
        /// </param>
        /// <param name="cmpFlags">
        /// The cmp flags.
        /// </param>
        /// <returns>
        /// </returns>
        [PreserveSig]
        int IsEqual(
                IAssemblyName pAsmName,
                int cmpFlags);

        /// <summary>
        /// </summary>
        /// <param name="pAsmName">
        /// The p asm name.
        /// </param>
        /// <returns>
        /// </returns>
        [PreserveSig]
        int Clone(out IAssemblyName pAsmName);
    }// IAssemblyName

    [ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("21b8916c-f28e-11d2-a473-00c04f8ef448")]
    internal interface IAssemblyEnum
    {
        [PreserveSig]
        int GetNextAssembly(
                IntPtr pvReserved,
                out IAssemblyName ppName,
                int flags);
        [PreserveSig]
        int Reset();
        [PreserveSig]
        int Clone(out IAssemblyEnum ppEnum);
    }// IAssemblyEnum

    [ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("582dac66-e678-449f-aba6-6faaec8a9394")]
    internal interface IInstallReferenceItem
    {
        // A pointer to a FUSION_INSTALL_REFERENCE structure. 
        // The memory is allocated by the GetReference method and is freed when 
        // IInstallReferenceItem is released. Callers must not hold a reference to this 
        // buffer after the IInstallReferenceItem object is released. 
        // This uses the InstallReferenceOutput object to avoid allocation 
        // issues with the interop layer. 
        // This cannot be marshaled directly - must use IntPtr 
        [PreserveSig]
        int GetReference(
                out IntPtr pRefData,
                int flags,
                IntPtr pvReserced);
    }// IInstallReferenceItem

    [ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("56b1a988-7c0c-4aa2-8639-c3eb5a90226f")]
    internal interface IInstallReferenceEnum
    {
        [PreserveSig]
        int GetNextInstallReferenceItem(
                out IInstallReferenceItem ppRefItem,
                int flags,
                IntPtr pvReserced);
    }// IInstallReferenceEnum

    /// <summary>
    /// 
    /// </summary>
    public enum AssemblyCommitFlags
    {
        /// <summary>
        /// 
        /// </summary>
        Default = 1,
        /// <summary>
        /// 
        /// </summary>
        Force = 2
    }// enum AssemblyCommitFlags

    /// <summary>
    /// 
    /// </summary>
    public enum AssemblyCacheUninstallDisposition
    {
        /// <summary>
        /// 
        /// </summary>
        Unknown = 0,
        /// <summary>
        /// 
        /// </summary>
        Uninstalled = 1,
        /// <summary>
        /// 
        /// </summary>
        StillInUse = 2,
        /// <summary>
        /// 
        /// </summary>
        AlreadyUninstalled = 3,
        /// <summary>
        /// 
        /// </summary>
        DeletePending = 4,
        /// <summary>
        /// 
        /// </summary>
        HasInstallReference = 5,
        /// <summary>
        /// 
        /// </summary>
        ReferenceNotFound = 6
    }

    /// <summary>
    /// </summary>
    [Flags]
    internal enum AssemblyCacheFlags
    {
        Gac = 2,
    }

    internal enum CreateAssemblyNameObjectFlags
    {
        CanofDefault = 0,
        CanofParseDisplayName = 1,
    }

    [Flags]
    internal enum AssemblyNameDisplayFlags
    {
        Version = 0x01,
        Culture = 0x02,
        PublicKeyToken = 0x04,
        Processorarchitecture = 0x20,
        Retargetable = 0x80,
        // This enum will change in the future to include
        // more attributes.
        All = Version
                                    | Culture
                                    | PublicKeyToken
                                    | Processorarchitecture
                                    | Retargetable
    }

    /// <summary>
    /// 
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public class InstallReference
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InstallReference"/> class.
        /// </summary>
        /// <param name="guid">
        /// The guid.
        /// </param>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="data">
        /// The data.
        /// </param>
        public InstallReference(Guid guid, String id, String data)
        {
            flags = 0;
            // quiet compiler warning 
            if (flags == 0) { }
            guidScheme = guid;
            identifier = id;
            description = data;
        }

        /// <summary>
        /// Gets GuidScheme.
        /// </summary>
        public Guid GuidScheme
        {
            get { return guidScheme; }
        }

        /// <summary>
        /// Gets Identifier.
        /// </summary>
        public String Identifier
        {
            get { return identifier; }
        }

        /// <summary>
        /// Gets Description.
        /// </summary>
        public String Description
        {
            get { return description; }
        }

        readonly int flags;

        readonly Guid guidScheme;
        
        [MarshalAs(UnmanagedType.LPWStr)]
        readonly string identifier;
        
        [MarshalAs(UnmanagedType.LPWStr)]
        private readonly string description;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct AssemblyInfo
    {
        public int cbAssemblyInfo; // size of this structure for future expansion
        public int assemblyFlags;
        public long assemblySizeInKB;
        [MarshalAs(UnmanagedType.LPWStr)]
        public String currentAssemblyPath;
        public int cchBuf; // size of path buf.
    }

    /// <summary>
    /// </summary>
    [ComVisible(false)]
    public class InstallReferenceGuid
    {
        /// <summary>
        /// </summary>
        /// <param name="guid">
        /// The guid.
        /// </param>
        /// <returns>
        /// </returns>
        public static bool IsValidGuidScheme(Guid guid)
        {
            return (guid.Equals(UninstallSubkeyGuid) ||
                    guid.Equals(FilePathGuid) ||
                    guid.Equals(OpaqueGuid) ||
                    guid.Equals(Guid.Empty));
        }

        /// <summary>
        /// </summary>
        public readonly static Guid UninstallSubkeyGuid = new Guid("8cedc215-ac4b-488b-93c0-a50a49cb2fb8");

        /// <summary>
        /// </summary>
        public readonly static Guid FilePathGuid = new Guid("b02f9d65-fb77-4f7a-afa5-b391309f11c9");

        /// <summary>
        /// </summary>
        public readonly static Guid OpaqueGuid = new Guid("2ec93463-b0c3-45e1-8364-327e96aea856");
        // these GUID cannot be used for installing into GAC.
        /// <summary>
        /// </summary>
        public readonly static Guid MsiGuid = new Guid("25df0fc1-7f97-4070-add7-4b13bbfd7cb8");

        /// <summary>
        /// </summary>
        public readonly static Guid OsInstallGuid = new Guid("d16d444c-56d8-11d5-882d-0080c847b195");
    }

    /// <summary>
    /// </summary>
    [ComVisible(false)]
    public static class AssemblyCache
    {
        /// <summary>
        /// </summary>
        /// <param name="assemblyPath">
        /// The assembly path.
        /// </param>
        /// <param name="reference">
        /// The reference.
        /// </param>
        /// <param name="flags">
        /// The flags.
        /// </param>
        /// <exception cref="ArgumentException">
        /// </exception>
        public static void InstallAssembly(String assemblyPath, InstallReference reference, AssemblyCommitFlags flags)
        {
            if (reference != null)
            {
                if (!InstallReferenceGuid.IsValidGuidScheme(reference.GuidScheme))
                {
                    throw new ArgumentException("Invalid reference guid.", "reference");
                }
            }

            IAssemblyCache ac;

            int hr = Utils.CreateAssemblyCache(out ac, 0);
            if (hr >= 0)
            {
                hr = ac.InstallAssembly((int)flags, assemblyPath, reference);
            }

            if (hr < 0)
            {
                Marshal.ThrowExceptionForHR(hr);
            }
        }

        // assemblyName has to be fully specified name. 
        // A.k.a, for v1.0/v1.1 assemblies, it should be "name, Version=xx, Culture=xx, PublicKeyToken=xx".
        // For v2.0 assemblies, it should be "name, Version=xx, Culture=xx, PublicKeyToken=xx, ProcessorArchitecture=xx".
        // If assemblyName is not fully specified, a random matching assembly will be uninstalled. 
        /// <summary>
        /// </summary>
        /// <param name="assemblyName">
        /// The assembly name.
        /// </param>
        /// <param name="reference">
        /// The reference.
        /// </param>
        /// <param name="disp">
        /// The disp.
        /// </param>
        /// <exception cref="ArgumentException">
        /// </exception>
        public static void UninstallAssembly(String assemblyName, InstallReference reference, out AssemblyCacheUninstallDisposition disp)
        {
            AssemblyCacheUninstallDisposition dispResult = AssemblyCacheUninstallDisposition.Uninstalled;
            if (reference != null)
            {
                if (!InstallReferenceGuid.IsValidGuidScheme(reference.GuidScheme))
                {
                    throw new ArgumentException("Invalid reference guid.", "reference");
                }
            }

            IAssemblyCache ac;

            int hr = Utils.CreateAssemblyCache(out ac, 0);
            if (hr >= 0)
            {
                hr = ac.UninstallAssembly(0, assemblyName, reference, out dispResult);
            }

            if (hr < 0)
            {
                Marshal.ThrowExceptionForHR(hr);
            }

            disp = dispResult;
        }

        // See comments in UninstallAssembly
        /// <summary>
        /// </summary>
        /// <param name="assemblyName">
        /// The assembly name.
        /// </param>
        /// <returns>
        /// </returns>
        /// <exception cref="ArgumentException">
        /// </exception>
        public static string QueryAssemblyInfo(string assemblyName)
        {
            if (assemblyName == null)
            {
                throw new ArgumentException("Invalid name", "assemblyName");
            }

            AssemblyInfo aInfo = new AssemblyInfo { cchBuf = 1024 };

            // Get a string with the desired length
            aInfo.currentAssemblyPath = new string('\0', aInfo.cchBuf);

            IAssemblyCache ac;
            int hr = Utils.CreateAssemblyCache(out ac, 0);
            if (hr >= 0)
            {
                hr = ac.QueryAssemblyInfo(0, assemblyName, ref aInfo);
            }
            if (hr < 0)
            {
                Marshal.ThrowExceptionForHR(hr);
            }

            return aInfo.currentAssemblyPath;
        }
    }

    /// <summary>
    /// </summary>
    [ComVisible(false)]
    public class AssemblyCacheEnum
    {
        // null means enumerate all the assemblies
        /// <summary>
        /// Initializes a new instance of the <see cref="AssemblyCacheEnum"/> class.
        /// </summary>
        /// <param name="assemblyName">
        /// The assembly name.
        /// </param>
        public AssemblyCacheEnum(String assemblyName)
        {
            IAssemblyName fusionName = null;
            int hr = 0;

            if (assemblyName != null)
            {
                hr = Utils.CreateAssemblyNameObject(
                        out fusionName,
                        assemblyName,
                        CreateAssemblyNameObjectFlags.CanofParseDisplayName,
                        IntPtr.Zero);
            }

            if (hr >= 0)
            {
                hr = Utils.CreateAssemblyEnum(
                        out this.mAssemblyEnum,
                        IntPtr.Zero,
                        fusionName,
                        AssemblyCacheFlags.Gac,
                        IntPtr.Zero);
            }

            if (hr < 0)
            {
                Marshal.ThrowExceptionForHR(hr);
            }
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public String GetNextAssembly()
        {
            IAssemblyName fusionName;

            if (this.done)
            {
                return null;
            }

            // Now get next IAssemblyName from m_AssemblyEnum
            int hr = this.mAssemblyEnum.GetNextAssembly((IntPtr)0, out fusionName, 0);

            if (hr < 0)
            {
                Marshal.ThrowExceptionForHR(hr);
            }

            if (fusionName != null)
            {
                return GetFullName(fusionName);
            }

            this.done = true;
            return null;
        }

        private static String GetFullName(IAssemblyName fusionAsmName)
        {
            StringBuilder sDisplayName = new StringBuilder(1024);
            int iLen = 1024;

            int hr = fusionAsmName.GetDisplayName(sDisplayName, ref iLen, (int)AssemblyNameDisplayFlags.All);
            if (hr < 0)
            {
                Marshal.ThrowExceptionForHR(hr);
            }

            return sDisplayName.ToString();
        }

        /// <summary>
        /// The assembly enum.
        /// </summary>
        private readonly IAssemblyEnum mAssemblyEnum;
        private bool done;
    }// class AssemblyCacheEnum

    /// <summary>
    /// </summary>
    public class AssemblyCacheInstallReferenceEnum
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AssemblyCacheInstallReferenceEnum"/> class.
        /// </summary>
        /// <param name="assemblyName">
        /// The assembly name.
        /// </param>
        public AssemblyCacheInstallReferenceEnum(String assemblyName)
        {
            IAssemblyName fusionName;

            int hr = Utils.CreateAssemblyNameObject(
                        out fusionName,
                        assemblyName,
                        CreateAssemblyNameObjectFlags.CanofParseDisplayName,
                        IntPtr.Zero);

            if (hr >= 0)
            {
                hr = Utils.CreateInstallReferenceEnum(out refEnum, fusionName, 0, IntPtr.Zero);
            }

            if (hr < 0)
            {
                Marshal.ThrowExceptionForHR(hr);
            }
        }

        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>
        public InstallReference GetNextReference()
        {
            IInstallReferenceItem item;
            var hr = this.refEnum.GetNextInstallReferenceItem(out item, 0, IntPtr.Zero);
            if ((uint)hr == 0x80070103)
            {   // ERROR_NO_MORE_ITEMS
                return null;
            }

            if (hr < 0)
            {
                Marshal.ThrowExceptionForHR(hr);
            }

            IntPtr refData;
            InstallReference instRef = new InstallReference(Guid.Empty, String.Empty, String.Empty);

            hr = item.GetReference(out refData, 0, IntPtr.Zero);
            if (hr < 0)
            {
                Marshal.ThrowExceptionForHR(hr);
            }

            Marshal.PtrToStructure(refData, instRef);
            return instRef;
        }

        /// <summary>
        /// The install ref enum.
        /// </summary>
        private readonly IInstallReferenceEnum refEnum;
    }

    internal class Utils
    {
        [DllImport("fusion.dll")]
        internal static extern int CreateAssemblyEnum(
                out IAssemblyEnum ppEnum,
                IntPtr pUnkReserved,
                IAssemblyName pName,
                AssemblyCacheFlags flags,
                IntPtr pvReserved);

        [DllImport("fusion.dll")]
        internal static extern int CreateAssemblyNameObject(
                out IAssemblyName ppAssemblyNameObj,
                [MarshalAs(UnmanagedType.LPWStr)]
                String szAssemblyName,
                CreateAssemblyNameObjectFlags flags,
                IntPtr pvReserved);

        [DllImport("fusion.dll")]
        internal static extern int CreateAssemblyCache(
                out IAssemblyCache ppAsmCache,
                int reserved);

        [DllImport("fusion.dll")]
        internal static extern int CreateInstallReferenceEnum(
                out IInstallReferenceEnum ppRefEnum,
                IAssemblyName pName,
                int dwFlags,
                IntPtr pvReserved);
    }
}
