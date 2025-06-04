using ConsoleMvvm.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui;

namespace ConsoleMvvm.Views;

public class HelloView : View
{
    public HelloViewModel ViewModel { get; }

    public HelloView(HelloViewModel viewModel)
    {
        ViewModel = viewModel;
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        Title = "Hello View";
        Width = Dim.Fill();
        Height = Dim.Fill();
        var label = new Label()
        {
            Text= "Hello, World!",
            X = Pos.Center(),
            Y = Pos.Center()
        };
        Add(label);
    }
}
