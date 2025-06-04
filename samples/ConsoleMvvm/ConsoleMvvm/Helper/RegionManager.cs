using R3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui;

namespace ConsoleMvvm.Helper;

public class RegionManager
{
    public BindableReactiveProperty<View> MainRegionFrame { get; } = new();
    public BindableReactiveProperty<View> MainRegion { get; } = new();

    public RegionManager()
    {
        MainRegion.Subscribe(x =>
        {
            if(x == null) return;

            MainRegionFrame.Value.RemoveAll();
            MainRegionFrame.Value.Add(x);
        });
    }
}
