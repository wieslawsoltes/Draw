using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Media;
using Avalonia.Media.Immutable;

namespace Draw.Shapes;

public class LineTool : Tool
{
    private LineShape? _lineShape;

    public override void Pressed(CanvasShape canvasShape, Control control, PointerPressedEventArgs e)
    {
        if (!Equals(e.Pointer.Captured, control) && _lineShape is null)
        {
            _lineShape = new LineShape
            {
                Pen = new ImmutablePen(Colors.Red.ToUint32(), 2d), Start = e.GetPosition(control)
            };

            _lineShape.End = _lineShape.Start;

            canvasShape.Children.Add(_lineShape);

            e.Pointer.Capture(control);

            control.InvalidateVisual();
        }
    }

    public override void Released(CanvasShape canvasShape, Control control, PointerReleasedEventArgs e)
    {
        if (Equals(e.Pointer.Captured, control) && _lineShape is { })
        {
            _lineShape = null;
            e.Pointer.Capture(null);
        }
    }

    public override void Moved(CanvasShape canvasShape, Control control, PointerEventArgs e)
    {
        if (Equals(e.Pointer.Captured, control) && _lineShape is { })
        {
            _lineShape.End = e.GetPosition(control);
            control.InvalidateVisual();
        }
    }
}
