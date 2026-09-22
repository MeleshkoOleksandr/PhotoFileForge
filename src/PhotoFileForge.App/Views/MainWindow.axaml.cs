using System.Collections.ObjectModel;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Styling;
using  PhotoFileForge.PhotoFileForge.App.Model;


namespace PhotoFileForge.App.Views;

public partial class MainWindow : Window
{
    //private bool _sidebarVisible = true;
    private GridLength _lastSidebarWidth = new(320);
    
    public MainWindow()
    {
        InitializeComponent();
        LoadSampleData();
    }
    
     // ------------------------------------------------------------------
    // Sample data — mirrors the reference mockups (33_Rigi_Trip / Export
    // Staging). Replace with real filesystem enumeration; keep entries
    // shallow and load incrementally (e.g. virtualization + paging) for
    // directories with hundreds of thousands of items.
    // ------------------------------------------------------------------
    private void LoadSampleData()
    {
        /*var left = new ObservableCollection<FileEntry>
        {
            new() { Name = "_Selects_Final", IsFolder = true, SizeDisplay = "42 items", ModifiedDisplay = "Today 14:10" },
            new() { Name = "RAW_Archive_CR3", IsFolder = true, SizeDisplay = "188 items", ModifiedDisplay = "Yesterday" },
            new() { Name = "IMG_114800.CR3", Extension = "CR3", SizeDisplay = "34.2 MB", ModifiedDisplay = "2026-06-14" },
            new() { Name = "IMG_114801.JPG", Extension = "JPG", SizeDisplay = "8.4 MB", ModifiedDisplay = "Today 11:30", IsSelected = true },
            new() { Name = "DSCF9021.RAF", Extension = "RAF", SizeDisplay = "48.1 MB", ModifiedDisplay = "2026-06-14" },
            new() { Name = "DJI_0482_Aerial.DNG", Extension = "DNG", SizeDisplay = "102.4 MB", ModifiedDisplay = "2026-06-13" },
            new() { Name = "CLIP_0042_LakeSummit.MOV", Extension = "MOV", SizeDisplay = "2.1 GB", ModifiedDisplay = "2026-06-14" },
            new() { Name = "BROLL_019_MountainTrain.MP4", Extension = "MP4", SizeDisplay = "850.0 MB", ModifiedDisplay = "2026-06-14" },
            new() { Name = "IMG_114802.JPG", Extension = "JPG", SizeDisplay = "7.9 MB", ModifiedDisplay = "2026-06-14" },
            new() { Name = "IMG_114803.JPG", Extension = "JPG", SizeDisplay = "8.1 MB", ModifiedDisplay = "2026-06-14" },
            new() { Name = "IMG_114804.JPG", Extension = "JPG", SizeDisplay = "9.2 MB", ModifiedDisplay = "2026-06-14" },
        };

        var right = new ObservableCollection<FileEntry>
        {
            new() { Name = "Deliverables_Clients", IsFolder = true, SizeDisplay = "12 items", ModifiedDisplay = "Sep 21 09:15" },
            new() { Name = "Web_Optimized_1080p", IsFolder = true, SizeDisplay = "84 items", ModifiedDisplay = "Sep 20 18:32" },
            new() { Name = "portfolio_banner_v2.jpg", Extension = "JPG", SizeDisplay = "3.4 MB", ModifiedDisplay = "Sep 18 16:40" },
            new() { Name = "rigi_panorama_stitched.tif", Extension = "TIF", SizeDisplay = "184.2 MB", ModifiedDisplay = "Sep 15 11:20" },
        };

        LeftFileList.ItemsSource = left;
        RightFileList.ItemsSource = right;
        LeftFileList.SelectedIndex = 3; // IMG_114801.JPG, matches the preview sidebar sample*/
    }

    // ------------------------------------------------------------------
    // Sidebar toggle: collapses the Preview & Metadata column by
    // remembering its width and setting it to 0, rather than removing it
    // — keeps the GridSplitter behavior simple.
    // ------------------------------------------------------------------
    private void OnToggleSidebar(object? sender, RoutedEventArgs e)
    {
        /*_sidebarVisible = !_sidebarVisible;

        var sidebarColumn = WorkspaceGrid.ColumnDefinitions[4];
        if (_sidebarVisible)
        {
            sidebarColumn.Width = _lastSidebarWidth;
            SidebarPanel.IsVisible = true;
            SidebarSplitter.IsVisible = true;
            SidebarToggleButton.Classes.Add("active");
        }
        else
        {
            _lastSidebarWidth = sidebarColumn.Width;
            sidebarColumn.Width = new GridLength(0);
            SidebarPanel.IsVisible = false;
            SidebarSplitter.IsVisible = false;
            SidebarToggleButton.Classes.Remove("active");
        }*/
    }

    // ------------------------------------------------------------------
    // Theme toggle: flips Application.RequestedThemeVariant between Light
    // and Dark. Every brush in Styles/Colors.axaml is a DynamicResource
    // pulled from ThemeDictionaries, so the whole window re-skins live.
    // ------------------------------------------------------------------
    private void OnToggleTheme(object? sender, RoutedEventArgs e)
    {
        if (Application.Current is null) return;

        var current = Application.Current.ActualThemeVariant;
        var goingToDark = current != ThemeVariant.Dark;

        Application.Current.RequestedThemeVariant = goingToDark ? ThemeVariant.Dark : ThemeVariant.Light;
        ThemeToggleGlyph.Text = goingToDark ? "\u263D" : "\u2600"; // moon / sun glyph
    }
    
}