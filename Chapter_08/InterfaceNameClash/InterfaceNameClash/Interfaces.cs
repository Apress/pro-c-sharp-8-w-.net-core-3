using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceNameClash
{
    // Draw image to a form.
    public interface IDrawToForm
    {
        void Draw();
    }

    // Draw to buffer in memory.
    public interface IDrawToMemory
    {
        void Draw();
    }

    // Render to the printer.
    public interface IDrawToPrinter
    {
        void Draw();
    }
}
