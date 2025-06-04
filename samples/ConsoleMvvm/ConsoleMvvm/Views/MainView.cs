using ConsoleMvvm.Helper;
using ConsoleMvvm.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui;
using TerminalGuiHelper.Views;

namespace ConsoleMvvm.Views;

public class MainView : Window
{
    readonly RegionManager regionManager;
    private Dictionary<string, View> viewMap = new();
    public MainViewModel ViewModel { get; set; }
    public MainView(
        MainViewModel viewModel
        , HelloView helloView
        , CounterView counterView
        , RegionManager retionManager
    )
    {
        ViewModel = viewModel;
        viewMap.Add("Home", helloView);
        viewMap.Add("Counter", counterView);
        this.regionManager = retionManager;

        InitializeComponent();
    }
    private void InitializeComponent()
    {
        Title = "Console MVVM Example";
        Width = Dim.Fill();
        Height = Dim.Fill();

        {
            var hStack = new HRatioStackView() { Ratio = new double[] { 2, 3 } };
            var leftFrame = GetLeftFrame();
            hStack.Stack(leftFrame);

            var mainRegionFrame = new FrameView() { Width = Dim.Fill(), Height = Dim.Fill() };
            hStack.Stack(mainRegionFrame);
            Add(hStack);
            regionManager.MainRegionFrame.Value = mainRegionFrame;
        }


    }
    private View GetLeftFrame()
    {
        var list = new ListView()
        {
            Width = Dim.Fill(),
            Height = Dim.Fill(),
            CursorVisibility = CursorVisibility.Underline,
            
        };
        list.SelectedItemChanged += (_, _) =>
        {
            var keyString = ViewModel.MenuList[list.SelectedItem].ToString();
            regionManager.MainRegion.Value = viewMap[keyString];
        };
        list.SetSource(ViewModel.MenuList);
        return list;
    }
}
