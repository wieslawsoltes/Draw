using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Draw.Shapes;

namespace Draw.Views;

public partial class MainView : UserControl
{
    private readonly CanvasShape _canvasShape;

    public MainView()
    {
        InitializeComponent();

        Background = Brushes.Transparent;

        _canvasShape = new CanvasShape(this);
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    protected override void OnPointerPressed(PointerPressedEventArgs e)
    {
        base.OnPointerPressed(e);

        _canvasShape.Pressed(e);
    }

    protected override void OnPointerReleased(PointerReleasedEventArgs e)
    {
        base.OnPointerReleased(e);

        _canvasShape.Released(e);
    }

    protected override void OnPointerMoved(PointerEventArgs e)
    {
        base.OnPointerMoved(e);

        _canvasShape.Moved(e);
    }

    public override void Render(DrawingContext context)
    {
        base.Render(context);

        _canvasShape.Draw(context);
    }
}
