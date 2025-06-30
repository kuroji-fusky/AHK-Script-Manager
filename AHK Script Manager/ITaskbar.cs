using System.Runtime.InteropServices;

namespace AHK_Script_Manager
{
    internal interface INativeTaskbar
    {
        const int ABM_GETTASKBARPOS = 5;

        [DllImport("shell32.dll", SetLastError = true)]
        public static extern uint SHAppBarMessage(uint dwMessage, ref APPBARDATA pData);

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int left, top, right, bottom;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct APPBARDATA
        {
            public uint cbSize, uCallbackMessage, uEdge;
            public nint hWnd;
            public RECT rc;
            public int lParam;
        }
    }
}