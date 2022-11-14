using System.Collections.Generic;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Media;
using Avalonia.Media.Immutable;

namespace Draw.Shapes;

public class CanvasShape
{
    private readonly Control _control;
    private List<LineShape> _lines = new ();
    private LineShape? _lineShape;

    public CanvasShape(Control control)
    {
        _control = control;
    }
    
    public void Pressed(PointerPressedEventArgs e)
    {
        if (!Equals(e.Pointer.Captured, _control) && _lineShape is null)
        {
            _lineShape = new LineShape
            {
                Pen = new ImmutablePen(Colors.Red.ToUint32(), 2d), Start = e.GetPosition(_control)
            };

            _lineShape.End = _lineShape.Start;

            _lines.Add(_lineShape);

            e.Pointer.Capture(_control);

            _control.InvalidateVisual();
        }
    }

    public void Released(PointerReleasedEventArgs e)
    {
        if (Equals(e.Pointer.Captured, _control) && _lineShape is { })
        {
            _lineShape = null;
            e.Pointer.Capture(null);
        }
    }

    public void Moved(PointerEventArgs e)
    {
        if (Equals(e.Pointer.Captured, _control) && _lineShape is { })
        {
            _lineShape.End = e.GetPosition(_control);
            _control.InvalidateVisual();
        }
    }

    public void Draw(DrawingContext context)
    {
        foreach (var lineShape in _lines)
        {
            lineShape.Draw(context);
        }
    }
}
