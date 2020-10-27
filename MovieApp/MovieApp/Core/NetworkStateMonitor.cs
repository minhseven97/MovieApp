using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace MovieApp.Core
{
    public static class NetworkStateMonitor
    {
        /// <summary>
        /// Kiểm tra trạng thái mạng có kết nối Internet
        /// </summary>
        /// <returns>true nếu có kết nối Internet</returns>
        public static bool NetworkIsReady()
        {
            var current = Connectivity.NetworkAccess;

            return current == NetworkAccess.Internet;
        }

        public static bool NetworkIsReady(out NetworkAccess networkAccess)
        {
            networkAccess = Connectivity.NetworkAccess;

            return networkAccess == NetworkAccess.Internet;
        }
    }
}
