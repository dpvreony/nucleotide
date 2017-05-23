// -----------------------------------------------------------------------
// <copyright file="MessageFilter.cs" company="Microsoft">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace TestDhgms.PhosphateTest
{
    using System.Runtime.InteropServices;

    /// <summary>
    /// Class containing the IOleMessageFilter
    /// thread error-handling functions.
    /// </summary>
    public class MessageFilter : IOleMessageFilter
    {
        /// <summary>
        /// Start the filter.
        /// </summary>
        public static void Register()
        {
            IOleMessageFilter newFilter = new MessageFilter();
            IOleMessageFilter oldFilter = null;
            CoRegisterMessageFilter(newFilter, out oldFilter);
        }

        /// <summary>
        /// Done with the filter, close it.
        /// </summary>
        public static void Revoke()
        {
            IOleMessageFilter oldFilter = null;
            CoRegisterMessageFilter(null, out oldFilter);
        }

        /// <summary>
        /// IOleMessageFilter functions.
        /// Handle incoming thread requests.
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
        int IOleMessageFilter.HandleInComingCall(int dwCallType,
          System.IntPtr hTaskCaller, int dwTickCount, System.IntPtr
          lpInterfaceInfo)
        {
            //Return the flag SERVERCALL_ISHANDLED.
            return 0;
        }

        /// <summary>
        /// Thread call was rejected, so try again.
        /// </summary>
        /// <param name="hTaskCallee">
        /// The h task callee.
        /// </param>
        /// <param name="dwTickCount">
        /// The dw tick count.
        /// </param>
        /// <param name="dwRejectType">
        /// The dw reject type.
        /// </param>
        /// <returns>
        /// </returns>
        int IOleMessageFilter.RetryRejectedCall(System.IntPtr
          hTaskCallee, int dwTickCount, int dwRejectType)
        {

            // flag = SERVERCALL_RETRYLATER.
            if (dwRejectType == 2)
            {
                // Retry the thread call immediately if return >=0 & 
                // <100.
                return 99;
            }

            // Too busy; cancel call.
            return -1;
        }

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
        int IOleMessageFilter.MessagePending(System.IntPtr hTaskCallee,
          int dwTickCount, int dwPendingType)
        {
            //Return the flag PENDINGMSG_WAITDEFPROCESS.
            return 2;
        }

        // Implement the IOleMessageFilter interface.
        [DllImport("Ole32.dll")]
        private static extern int CoRegisterMessageFilter(IOleMessageFilter newFilter, out IOleMessageFilter oldFilter);
    }


}
