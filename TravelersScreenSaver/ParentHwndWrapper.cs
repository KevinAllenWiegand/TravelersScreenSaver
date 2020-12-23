using System;
using System.Windows.Forms;

namespace Travelers
{
    internal class ParentHwndWrapper : IWin32Window
    {
        public IntPtr Handle { get; }

        public ParentHwndWrapper(IntPtr handle)
        {
            Handle = handle;
        }
    }
}
