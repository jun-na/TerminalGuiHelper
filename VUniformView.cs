using Terminal.Gui;
namespace TerminalGuiHelper;

public class VUniformView : View
{
    private List<View> views = new();
    public double[] Ratio { get; set; } = { 1, };
    public VUniformView()
    {
        Width = Dim.Fill();
        Height = Dim.Fill();
    }

    public void Stack(View view, bool invalidate = true)
    {
        views.Add(view);
        if (invalidate)
        {
            Invalidate();
        }
    }

    public void Invalidate()
    {
        RemoveAll();

        // 各比率をパーセンテージに変換
        var total = Ratio.Sum();
        var percentages = Ratio
            .Select(r => (r / total) * 100)
            .ToArray();

        var el = views.FirstOrDefault();
        if (el == null)
        {
            return;
        }
        // 最初の要素の高さを設定
        if (percentages.Length > 0)
        {
            el.Height = Dim.Percent((int)(percentages[0]));
        }
        else
        {
            el.Height = Dim.Fill();
        }
        Add(el);

        foreach (var view in views.Skip(1))
        {
            var index = views.IndexOf(view);
            if (index < Ratio.Length)
            {
                view.Height = Dim.Percent((int)(percentages[index]));
            }
            else
            {
                view.Height = Dim.Fill();
            }
            view.Y = Pos.Bottom(el);
            Add(view);
            el = view;
        }
    }
}
