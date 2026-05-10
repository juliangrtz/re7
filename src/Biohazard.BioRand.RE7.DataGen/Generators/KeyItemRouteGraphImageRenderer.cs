using Biohazard.BioRand.RE7.Modifiers;
using SkiaSharp;

namespace Biohazard.BioRand.RE7.DataGen.Generators;

internal static class KeyItemRouteGraphImageRenderer
{
    private const int Margin = 72;
    private const int TopMargin = 128;
    private const int NodeWidth = 430;
    private const int NodeHeight = 76;
    private const int RowGap = 58;
    private const int ColumnGap = 250;

    public static byte[] Render(KeyItemLocationModifier.KeyItemRouteGraphDiagram diagram)
    {
        var maxRow = diagram.Nodes.Max(node => node.Row);
        var maxColumn = diagram.Nodes.Max(node => node.Column);
        var width = (Margin * 2) + ((maxColumn + 1) * NodeWidth) + (maxColumn * ColumnGap);
        var height = TopMargin + ((maxRow + 1) * NodeHeight) + (maxRow * RowGap) + Margin;

        using var bitmap = new SKBitmap(width, height);
        using var canvas = new SKCanvas(bitmap);
        canvas.Clear(new SKColor(248, 250, 252));

        using var titleFont = new SKFont(SKTypeface.FromFamilyName("Segoe UI"), 34);
        using var subtitleFont = new SKFont(SKTypeface.FromFamilyName("Segoe UI"), 18);
        using var nodeFont = new SKFont(SKTypeface.FromFamilyName("Segoe UI"), 21);
        using var edgeFont = new SKFont(SKTypeface.FromFamilyName("Segoe UI"), 18);
        using var titlePaint = new SKPaint { Color = new SKColor(20, 31, 45), IsAntialias = true };
        using var subtitlePaint = new SKPaint { Color = new SKColor(83, 98, 117), IsAntialias = true };
        using var textPaint = new SKPaint { Color = new SKColor(28, 39, 54), IsAntialias = true };
        using var edgePaint = new SKPaint
        {
            Color = new SKColor(87, 103, 124),
            IsAntialias = true,
            StrokeCap = SKStrokeCap.Round,
            StrokeWidth = 3,
            Style = SKPaintStyle.Stroke,
        };
        using var noReturnPaint = edgePaint.Clone();
        noReturnPaint.Color = new SKColor(178, 97, 55);
        noReturnPaint.PathEffect = SKPathEffect.CreateDash([12, 8], 0);

        canvas.DrawText("Key Item Route Graph", width / 2f, 52, SKTextAlign.Center, titleFont, titlePaint);
        canvas.DrawText("Edge labels are required key items; routing places each key before the labeled edge is crossed", width / 2f, 84, SKTextAlign.Center, subtitleFont, subtitlePaint);

        var rectangles = diagram.Nodes.ToDictionary(node => node.Id, GetNodeRectangle);
        foreach (var edge in diagram.Edges)
        {
            DrawEdge(canvas, edge, rectangles, edgePaint, noReturnPaint, edgeFont, textPaint);
        }

        foreach (var node in diagram.Nodes)
        {
            DrawNode(canvas, node, rectangles[node.Id], nodeFont, textPaint);
        }

        using var image = SKImage.FromBitmap(bitmap);
        using var data = image.Encode(SKEncodedImageFormat.Png, 95);
        return data.ToArray();
    }

    private static SKRect GetNodeRectangle(KeyItemLocationModifier.KeyItemRouteGraphNode node)
    {
        var x = Margin + (node.Column * (NodeWidth + ColumnGap));
        var y = TopMargin + (node.Row * (NodeHeight + RowGap));
        return new SKRect(x, y, x + NodeWidth, y + NodeHeight);
    }

    private static void DrawNode(
        SKCanvas canvas,
        KeyItemLocationModifier.KeyItemRouteGraphNode node,
        SKRect rectangle,
        SKFont font,
        SKPaint textPaint)
    {
        using var fillPaint = new SKPaint
        {
            Color = GetNodeFill(node),
            IsAntialias = true,
            Style = SKPaintStyle.Fill,
        };
        using var strokePaint = new SKPaint
        {
            Color = new SKColor(101, 116, 137),
            IsAntialias = true,
            StrokeWidth = 2,
            Style = SKPaintStyle.Stroke,
        };

        canvas.DrawRoundRect(rectangle, 8, 8, fillPaint);
        canvas.DrawRoundRect(rectangle, 8, 8, strokePaint);

        var lines = WrapText(node.Label, 34).ToArray();
        var lineHeight = 24;
        var firstBaseline = rectangle.MidY - ((lines.Length - 1) * lineHeight / 2f) + 8;
        for (var i = 0; i < lines.Length; i++)
        {
            canvas.DrawText(lines[i], rectangle.MidX, firstBaseline + (i * lineHeight), SKTextAlign.Center, font, textPaint);
        }
    }

    private static void DrawEdge(
        SKCanvas canvas,
        KeyItemLocationModifier.KeyItemRouteGraphEdge edge,
        IReadOnlyDictionary<string, SKRect> rectangles,
        SKPaint edgePaint,
        SKPaint noReturnPaint,
        SKFont font,
        SKPaint textPaint)
    {
        var source = rectangles[edge.SourceId];
        var target = rectangles[edge.TargetId];
        var paint = edge.IsNoReturn ? noReturnPaint : edgePaint;
        var isHorizontal = Math.Abs(source.MidY - target.MidY) < 1;
        var start = isHorizontal
            ? new SKPoint(source.Right, source.MidY)
            : new SKPoint(source.MidX, source.Bottom);
        var end = isHorizontal
            ? new SKPoint(target.Left, target.MidY)
            : new SKPoint(target.MidX, target.Top);

        canvas.DrawLine(start, end, paint);
        DrawArrowHead(canvas, start, end, paint);
        if (!edge.IsNoReturn)
        {
            DrawArrowHead(canvas, end, start, paint);
        }

        if (edge.Requirements.Length == 0)
            return;

        var label = string.Join(" + ", edge.Requirements);
        var labelPoint = isHorizontal
            ? new SKPoint((start.X + end.X) / 2f, start.Y - 18)
            : new SKPoint(source.Right + 210, (start.Y + end.Y) / 2f + 7);
        DrawEdgeLabel(canvas, label, labelPoint, font, textPaint);
    }

    private static void DrawArrowHead(SKCanvas canvas, SKPoint start, SKPoint end, SKPaint paint)
    {
        var dx = end.X - start.X;
        var dy = end.Y - start.Y;
        var length = MathF.Sqrt((dx * dx) + (dy * dy));
        if (length == 0)
            return;

        var ux = dx / length;
        var uy = dy / length;
        var px = -uy;
        var py = ux;
        const float arrowLength = 15;
        const float arrowWidth = 8;

        using var path = new SKPath();
        path.MoveTo(end);
        path.LineTo(
            end.X - (ux * arrowLength) + (px * arrowWidth),
            end.Y - (uy * arrowLength) + (py * arrowWidth));
        path.LineTo(
            end.X - (ux * arrowLength) - (px * arrowWidth),
            end.Y - (uy * arrowLength) - (py * arrowWidth));
        path.Close();

        using var fill = paint.Clone();
        fill.Style = SKPaintStyle.Fill;
        fill.PathEffect = null;
        canvas.DrawPath(path, fill);
    }

    private static void DrawEdgeLabel(SKCanvas canvas, string label, SKPoint point, SKFont font, SKPaint textPaint)
    {
        var lines = WrapText(label, 28).ToArray();
        var lineHeight = 22;
        var width = lines.Max(line => font.MeasureText(line)) + 24;
        var height = (lines.Length * lineHeight) + 12;
        var background = new SKRect(
            point.X - (width / 2),
            point.Y - height + 10,
            point.X + (width / 2),
            point.Y + 10);

        using var fillPaint = new SKPaint
        {
            Color = new SKColor(248, 250, 252, 235),
            IsAntialias = true,
            Style = SKPaintStyle.Fill,
        };
        using var strokePaint = new SKPaint
        {
            Color = new SKColor(202, 213, 226),
            IsAntialias = true,
            StrokeWidth = 1,
            Style = SKPaintStyle.Stroke,
        };
        canvas.DrawRoundRect(background, 6, 6, fillPaint);
        canvas.DrawRoundRect(background, 6, 6, strokePaint);

        var firstBaseline = background.Top + 24;
        for (var i = 0; i < lines.Length; i++)
        {
            canvas.DrawText(lines[i], point.X, firstBaseline + (i * lineHeight), SKTextAlign.Center, font, textPaint);
        }
    }

    private static IEnumerable<string> WrapText(string text, int maxLength)
    {
        var current = "";
        foreach (var word in text.Split(' ', StringSplitOptions.RemoveEmptyEntries))
        {
            if (current.Length == 0)
            {
                current = word;
            }
            else if (current.Length + word.Length + 1 <= maxLength)
            {
                current += " " + word;
            }
            else
            {
                yield return current;
                current = word;
            }
        }

        if (current.Length != 0)
        {
            yield return current;
        }
    }

    private static SKColor GetNodeFill(KeyItemLocationModifier.KeyItemRouteGraphNode node)
    {
        if (node.Label.Contains("Ship", StringComparison.OrdinalIgnoreCase))
            return new SKColor(232, 244, 248);
        if (node.Label.Contains("Salt", StringComparison.OrdinalIgnoreCase)
            || node.Label.Contains("Final", StringComparison.OrdinalIgnoreCase))
            return new SKColor(238, 245, 231);
        if (node.Column != 0)
            return new SKColor(255, 248, 225);

        return new SKColor(242, 246, 251);
    }
}
