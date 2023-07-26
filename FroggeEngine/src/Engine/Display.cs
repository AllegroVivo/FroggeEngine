using System;
using System.Drawing;
using System.Windows.Forms;

namespace Frogge.Engine;

public class Display : Form
{
    private const String WindowTitle = "Frogge Engine";
    private Size _windowSize;

    public Display(Int32 width, Int32 height)
    {
        _windowSize = new Size(width, height);
        
        // Set up the window
        Text = WindowTitle;
        ClientSize = _windowSize;
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        StartPosition = FormStartPosition.CenterScreen;
    }

    public void Clear(Color fill)
    {
        // Clear the screen with the given color
    }

    public void SwapBuffers()
    {
        // Swap the front and back buffers
    }
    
    public void SetSize(Int32 width, Int32 height)
    {
        // Set the size of the window
        _windowSize = new Size(width, height);
        ClientSize = _windowSize;
    }
    
    public void SetFullscreen(Boolean fullscreen)
    {
        // Set the window to fullscreen
        if (fullscreen)
        {
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
        }
        else
        {
            FormBorderStyle = FormBorderStyle.FixedDialog;
            WindowState = FormWindowState.Normal;
        }
    }

    public void SetTitle(String title)
    {
        // Set the title of the window
        Text = title;
    }
    
    public void ShowCursor(Boolean show)
    {
        // Show or hide the cursor
        Cursor.Hide();
    }
}