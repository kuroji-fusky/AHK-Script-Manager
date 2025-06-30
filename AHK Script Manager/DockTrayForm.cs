using System.Runtime.InteropServices;
using static AHK_Script_Manager.INativeTaskbar;

namespace AHK_Script_Manager
{
    public partial class DockTrayForm : Form
    {
        internal struct TaskbarComponent
        {
            public int width, height;
            public bool isLeft, isTop, isRight, isBottom;
        }

        private static void PositionDatBitch(Form iEatAss)
        {
            Rectangle primaryBounds = Screen.PrimaryScreen!.Bounds;

            RECT taskbarRekt = new RECT();

            APPBARDATA data = new APPBARDATA();
            data.cbSize = (uint)Marshal.SizeOf(data);
            data.rc = taskbarRekt;

            if (SHAppBarMessage(ABM_GETTASKBARPOS, ref data) != 0)
            {
                taskbarRekt = data.rc;
            }

            var taskbarComponent = new TaskbarComponent()
            {
                height = taskbarRekt.bottom - taskbarRekt.top,
                width = taskbarRekt.right - taskbarRekt.left,

                isBottom = taskbarRekt.top > primaryBounds.Height / 2,
                isTop = taskbarRekt.bottom < primaryBounds.Height / 2,
                isLeft = taskbarRekt.right < primaryBounds.Width / 2,
                isRight = taskbarRekt.left > primaryBounds.Width / 2
            };
        }

        public DockTrayForm()
        {
            InitializeComponent();

            var I_JUST_SHIT_MY_PANTS = ActiveForm!;

            I_JUST_SHIT_MY_PANTS.StartPosition = FormStartPosition.Manual;
        }
    }
}
