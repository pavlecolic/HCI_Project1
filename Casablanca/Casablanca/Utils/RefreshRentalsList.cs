using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casablanca.Utils
{
    internal class RefreshRentalsList
    {
        public static event Action RefreshRequested;

        public static void RaiseRefreshRequest()
        {
            RefreshRequested?.Invoke();
        }
    }
}
