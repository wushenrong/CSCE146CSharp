namespace Fractal;

public partial class SierpinskiTriangle : Panel {
  public const int MAX_DEPTH = 4;

  public SierpinskiTriangle() {
    InitializeComponent();
    ResizeRedraw = true;
  }

  protected override void OnPaint(PaintEventArgs pe) {
    base.OnPaint(pe);

    Point[] points = [
      new(Width / 2, 0),
      new(0, Height),
      new(Width, Height)
    ];

    pe.Graphics.FillPolygon(Brushes.Black, points);

    DrawTriangles(pe.Graphics, points, 1);
  }

  private static void DrawTriangles(Graphics g, Point[] points, int depth) {
    if (depth > MAX_DEPTH) {
      return;
    }

    Point subLeft = Midpoint(points[0], points[1]);
    Point subRight = Midpoint(points[0], points[2]);
    Point subBottom = Midpoint(points[1], points[2]);

    g.FillPolygon(Brushes.White, [subLeft, subRight, subBottom]);

    DrawTriangles(g, [points[0], subLeft, subRight], depth + 1);
    DrawTriangles(g, [subLeft, points[1], subBottom], depth + 1);
    DrawTriangles(g, [subRight, subBottom, points[2]], depth + 1);
  }

  private static Point Midpoint(Point pointA, Point pointB) {
    return new((pointA.X + pointB.X) / 2, (pointA.Y + pointB.Y) / 2);
  }
}
