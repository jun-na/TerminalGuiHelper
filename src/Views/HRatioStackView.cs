using Terminal.Gui;
namespace TerminalGuiHelper.Views;

public class HRatioStackView : View
{
    private List<View> views = new();
    public double[] Ratio { get; set; } = { 1, };
    public HRatioStackView()
    {
        CanFocus = true;
        TabStop = TabBehavior.TabGroup;
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
            .Select(r => r / total * 100)
            .ToArray();

        var el = views.FirstOrDefault();
        if (el == null)
        {
            return;
        }
        // 最初の要素の幅を設定
        if (percentages.Length > 0)
        {
            el.Width = Dim.Percent((int)percentages[0]);
        }
        else
        {
            el.Width = Dim.Fill();
        }
        Add(el);

        foreach (var view in views.Skip(1))
        {
            var index = views.IndexOf(view);
            if (index < Ratio.Length)
            {
                view.Width = Dim.Percent((int)percentages[index] );
            }
            else
            {
                view.Width = Dim.Fill();
            }
            view.X = Pos.Right(el);
            Add(view);
            el = view;
        }
    }
}
