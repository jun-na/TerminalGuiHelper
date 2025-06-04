
using Terminal.Gui;
namespace TerminalGuiHelper.Views;

public class VStackView : View
{
    private List<View> views = new();
    public VStackView()
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

        var el = views.FirstOrDefault();
        if (el == null)
        {
            return;
        }
        Add(el);

        foreach (var view in views.Skip(1))
        {
            view.Y = Pos.Bottom(el) ;
            Add(view);
            el = view;
        }
    }

}