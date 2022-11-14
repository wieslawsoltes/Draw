using Avalonia.Controls;
using Avalonia.Input;

namespace Draw.Shapes;

public abstract class Tool
{
    public abstract void Pressed(CanvasShape canvasShape, Control control, PointerPressedEventArgs e);

    public abstract void Released(CanvasShape canvasShape, Control control, PointerReleasedEventArgs e);

    public abstract void Moved(CanvasShape canvasShape, Control control, PointerEventArgs e);
}
