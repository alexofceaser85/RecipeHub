using System.Runtime.InteropServices;

namespace Desktop_Client.View.Components.General
{
    /// <summary>
    /// A <see cref="TableLayoutPanel"/> that always has its vertical scrollbar visible and its horizontal scrollbar invisible.<br/>
    /// When no content is going off the panel, the vertical scrollbar is disabled.
    /// </summary>
    public class ScrollVisibleTableLayoutPanel : TableLayoutPanel
    {
        private const int WM_NCCALCSIZE = 0x83;
        private const int WS_VSCROLL = 0x00200000;
        private const int WS_HSCROLL = 0x00100000;
        private const int ESB_DISABLE_BOTH = 0x3;
        private const int SB_VERT = 0x1;

        /// <inheritdoc/>
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_NCCALCSIZE && !DesignMode)
            {
                this.ShowScrollbar(this.NeedsScrollbar());
                this.HideHorizontalScrollbar();
            }

            base.WndProc(ref m);
        }

        private bool NeedsScrollbar()
        {
            var totalHeight = this.Controls.Cast<Control>().Sum(c => c.Height + c.Margin.Top + c.Margin.Bottom);

            return totalHeight > this.Height;
        }

        private void ShowScrollbar(bool enableScrollBar)
        {
            var style = NativeMethods.GetWindowLong(this.Handle, NativeMethods.GWL_STYLE);
            style |= WS_VSCROLL;

            if (enableScrollBar)
            {
                NativeMethods.EnableScrollBar(this.Handle, SB_VERT, NativeMethods.ESB_ENABLE_BOTH);
            }
            else
            {
                NativeMethods.EnableScrollBar(this.Handle, SB_VERT, ESB_DISABLE_BOTH);
            }

            NativeMethods.SetWindowLong(this.Handle, NativeMethods.GWL_STYLE, style);
        }

        private void HideHorizontalScrollbar()
        {
            var style = NativeMethods.GetWindowLong(this.Handle, NativeMethods.GWL_STYLE);
            style &= ~WS_HSCROLL;
            NativeMethods.SetWindowLong(this.Handle, NativeMethods.GWL_STYLE, style);
        }

        private static class NativeMethods
        {
            public const int GWL_STYLE = -16;
            public const int ESB_ENABLE_BOTH = 0;

            [DllImport("user32.dll", SetLastError = true)]
            public static extern int GetWindowLong(IntPtr hWnd, int nIndex);

            [DllImport("user32.dll", SetLastError = true)]
            public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

            [DllImport("user32.dll")]
            public static extern bool EnableScrollBar(IntPtr hWnd, int wSBflags, int wArrows);
        }
    }
}
