using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casablanca.Utils
{
    public class RefreshSupplierList
    {
        public static event Action RefreshRequested;

        public static void RaiseRefreshRequest()
        {
            RefreshRequested?.Invoke();
        }
    }
}
