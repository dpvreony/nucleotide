// -----------------------------------------------------------------------
// <copyright file="IOleMessageFilter.cs" company="Microsoft">
// Based on code from Microsoft. See http://msdn.microsoft.com/en-us/library/ms228772(VS.80).aspx
// for licensing information
// </copyright>
// -----------------------------------------------------------------------

namespace TestDhgms.PhosphateTest
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Message Filter Interface
    /// </summary>
    /// <remarks>
    /// Taken from http://msdn.microsoft.com/en-us/library/ms228772(VS.80).aspx
    /// </remarks>
    [ComImport, Guid("00000016-0000-0000-C000-000000000046"),
    InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IOleMessageFilter
    {
        /// <summary>
        /// </summary>
        /// <param name="dwCallType">
        /// The dw call type.
        /// </param>
        /// <param name="hTaskCaller">
        /// The h task caller.
        /// </param>
        /// <param name="dwTickCount">
        /// The dw tick count.
        /// </param>
        /// <param name="lpInterfaceInfo">
        /// The lp interface info.
        /// </param>
        /// <returns>
        /// </returns>
        [PreserveSig]
        int HandleInComingCall(
            int dwCallType,
            IntPtr hTaskCaller,
            int dwTickCount,
            IntPtr lpInterfaceInfo);

        /// <summary>
        /// </summary>
        /// <param name="hTaskCallee">
        /// The handle to the task callee.
        /// </param>
        /// <param name="dwTickCount">
        /// The dw tick count.
        /// </param>
        /// <param name="dwRejectType">
        /// The dw reject type.
        /// </param>
        /// <returns>
        /// </returns>
        [PreserveSig]
        int RetryRejectedCall(
            IntPtr hTaskCallee,
            int dwTickCount,
            int dwRejectType);

        /// <summary>
        /// </summary>
        /// <param name="hTaskCallee">
        /// The h task callee.
        /// </param>
        /// <param name="dwTickCount">
        /// The dw tick count.
        /// </param>
        /// <param name="dwPendingType">
        /// The dw pending type.
        /// </param>
        /// <returns>
        /// </returns>
        [PreserveSig]
        int MessagePending(
            IntPtr hTaskCallee,
            int dwTickCount,
            int dwPendingType);
    }
}
