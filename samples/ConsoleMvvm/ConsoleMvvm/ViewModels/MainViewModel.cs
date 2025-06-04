using R3;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui;

namespace ConsoleMvvm.ViewModels;

public class MainViewModel
{
    public BindableReactiveProperty<string> Title { get; } = new();

    public ObservableCollection<string> MenuList { get; } = new ObservableCollection<string>();


    public MainViewModel()
    {
        Title.Value = "Console MVVM Example";
        MenuList.Add("Home");
        MenuList.Add("Counter");
    }

}
