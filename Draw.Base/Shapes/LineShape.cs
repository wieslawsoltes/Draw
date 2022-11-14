using Avalonia;
using Avalonia.Media;

namespace Draw.Shapes;

public class LineShape : BaseShape
{
    public IPen? Pen { get; set; }
    
    public Point Start { get; set; }
    
    public Point End { get; set; }

    public override void Draw(DrawingContext context)
    {
        if (Pen is { })
        {
            context.DrawLine(Pen, Start, End);
        }
    }
}
