using System.Collections.Generic;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Media;

namespace Draw.Shapes;

public class CanvasShape : BaseShape
{
    private readonly Control _control;

    public List<BaseShape> Children { get; set; }

    public Tool? CurrentTool { get; set; }

    public List<Tool> Tools { get; set; }

    public CanvasShape(Control control)
    {
        _control = control;

        Children = new List<BaseShape>();

        Tools = new List<Tool>
        {
            new LineTool()
        };

        CurrentTool = Tools[0];
    }

    public void Pressed(PointerPressedEventArgs e)
    {
        CurrentTool?.Pressed(this, _control, e);
    }

    public void Released(PointerReleasedEventArgs e)
    {
        CurrentTool?.Released(this, _control, e);
    }

    public void Moved(PointerEventArgs e)
    {
        CurrentTool?.Moved(this, _control, e);
    }

    public override void Draw(DrawingContext context)
    {
        foreach (var child in Children)
        {
            child.Draw(context);
        }
    }
}
