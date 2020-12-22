using System;
using System.Windows.Forms;

namespace Travelers
{
    public class ParentHwndWrapper : IWin32Window
    {
        private IntPtr _Handle;

        public IntPtr Handle => _Handle;

        public ParentHwndWrapper(IntPtr handle)
        {
            _Handle = handle;
        }
    }
}
