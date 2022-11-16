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
        if (_lineShape is null)
        {
            _lineShape = new LineShape
            {
                Pen = new ImmutablePen(Colors.Red.ToUint32(), 2d), Start = e.GetPosition(control)
            };

            _lineShape.End = _lineShape.Start;

            canvasShape.Children.Add(_lineShape);

            control.InvalidateVisual();
        }
    }

    public override void Released(CanvasShape canvasShape, Control control, PointerReleasedEventArgs e)
    {
        if (_lineShape is { })
        {
            _lineShape = null;
        }
    }

    public override void Moved(CanvasShape canvasShape, Control control, PointerEventArgs e)
    {
        if (_lineShape is { })
        {
            _lineShape.End = e.GetPosition(control);
            control.InvalidateVisual();
        }
    }
}
