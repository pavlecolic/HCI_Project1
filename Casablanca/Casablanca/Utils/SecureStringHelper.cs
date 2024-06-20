using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Casablanca.Utils
{
    public static class SecureStringHelper
    {

        public static string ConvertToString(SecureString secureString)
        {
            if (secureString == null)
                throw new ArgumentNullException(nameof(secureString));

            IntPtr bstr = IntPtr.Zero;
            try
            {
                bstr = Marshal.SecureStringToBSTR(secureString);
                return Marshal.PtrToStringBSTR(bstr);
            }
            finally
            {
                if (bstr != IntPtr.Zero)
                    Marshal.ZeroFreeBSTR(bstr);
            }
        }

        public static bool SecureStringsEqual(SecureString ss1, SecureString ss2)
        {
            if (ss1 == null || ss2 == null)
                return false;

            if (ss1.Length != ss2.Length)
                return false;

            IntPtr bstr1 = IntPtr.Zero;
            IntPtr bstr2 = IntPtr.Zero;

            try
            {
                bstr1 = Marshal.SecureStringToBSTR(ss1);
                bstr2 = Marshal.SecureStringToBSTR(ss2);

                string str1 = Marshal.PtrToStringBSTR(bstr1);
                string str2 = Marshal.PtrToStringBSTR(bstr2);

                return string.Equals(str1, str2);
            }
            finally
            {
                if (bstr1 != IntPtr.Zero)
                    Marshal.ZeroFreeBSTR(bstr1);

                if (bstr2 != IntPtr.Zero)
                    Marshal.ZeroFreeBSTR(bstr2);
            }
        }
    }
}

