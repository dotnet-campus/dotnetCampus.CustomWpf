// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Resources;
using System.Runtime.CompilerServices;

[assembly:InternalsVisibleTo("dotnetCampus.WPF, PublicKey=0024000004800000940000000602000000240000525341310004000001000100256f5cb79140dbc25623807d6823ca4b5b602209eaaf71f064e5926a7039c24351c1e2ad3130e194631307ed36a76ad4b832e237a467fefbd693428c7ecc5d4cc26796f6f8b705311948e00f2be5fa2db52ddff50a5b3eb0acc715b45618c1a92532ae2326529fb9e0f58a44abf31e9b5701994464186d3b9f52169b6e0f80b9")]

#if WINDOWS_BASE
namespace MS.Internal.WindowsBase
#elif PRESENTATION_CORE
namespace MS.Internal.PresentationCore
#elif PBTCOMPILER
namespace MS.Utility
#elif AUTOMATION
namespace MS.Internal.Automation
#elif REACHFRAMEWORK
namespace System.Windows.Xps
#elif PRESENTATIONFRAMEWORK
namespace System.Windows
#elif PRESENTATIONUI
namespace System.Windows.TrustUI
#elif WINDOWSFORMSINTEGRATION
namespace System.Windows
#elif RIBBON_IN_FRAMEWORK
namespace Microsoft.Windows.Controls
#else
namespace System
#endif
{
    internal partial class SR
    {
        private static ResourceManager ResourceManager => SRID.ResourceManager;

        // This method is used to decide if we need to append the exception message parameters to the message when calling SR.Format.
        // by default it returns false.
        [MethodImpl(MethodImplOptions.NoInlining)]
        private static bool UsingResourceKeys()
        {
            return false;
        }

        internal static string GetResourceString(string resourceKey, string defaultString)
        {
            string resourceString = null;
            try { resourceString = ResourceManager.GetString(resourceKey); }
            catch (MissingManifestResourceException) { }

            if (defaultString != null && resourceKey.Equals(resourceString, StringComparison.Ordinal))
            {
                return defaultString;
            }

            return resourceString;
        }

        internal static string Format(string resourceFormat, params object[] args)
        {
            if (args != null)
            {
                if (UsingResourceKeys())
                {
                    return resourceFormat + string.Join(", ", args);
                }

                return string.Format(resourceFormat, args);
            }

            return resourceFormat;
        }

        internal static string Format(string resourceFormat, object p1)
        {
            if (UsingResourceKeys())
            {
                return string.Join(", ", resourceFormat, p1);
            }

            return string.Format(resourceFormat, p1);
        }

        internal static string Format(string resourceFormat, object p1, object p2)
        {
            if (UsingResourceKeys())
            {
                return string.Join(", ", resourceFormat, p1, p2);
            }

            return string.Format(resourceFormat, p1, p2);
        }

        internal static string Format(string resourceFormat, object p1, object p2, object p3)
        {
            if (UsingResourceKeys())
            {
                return string.Join(", ", resourceFormat, p1, p2, p3);
            }

            return string.Format(resourceFormat, p1, p2, p3);
        }
    }
}
