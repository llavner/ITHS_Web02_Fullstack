using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services;

public class ContentService
{
    private string selectedContent = "Products";

    public event Action? OnChange;

    private async void NotifyStateChanged()
    {
        if (OnChange != null)
        {
            await Task.Run(() => OnChange.Invoke());
        }
    }
    public string SelectedContent
    {
        get => selectedContent;
        set
        {
            selectedContent = value;
            NotifyStateChanged();
        }
    }

    public void SelectContent(string option)
    {
        SelectedContent = option;
    }
}

