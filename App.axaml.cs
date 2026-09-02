using System;
using System.Diagnostics;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text.Json;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Taskeasy_Manager.Source.Models.Controller;
using Taskeasy_Manager.Source.ViewModels;

namespace Taskeasy_Manager;

public partial class App : Application
{
    [DllImport("user32.dll", CharSet = CharSet.Unicode)]
    private static extern int MessageBox(
        IntPtr hWnd,
        string txt,
        string caption,
        uint type
    );

    private Process? startInfo;
    
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
            {
                DataContext = new MainViewModel(),
            };
            
            desktop.Exit += (_, _) => 
            {
                if (startInfo is not null && !startInfo.HasExited)
                {
                    startInfo.Kill(true);
                    startInfo.Dispose();
                }
            };
        }

        base.OnFrameworkInitializationCompleted();
        jsContact();
    }

    private async void jsContact()
    {
        
        startInfo = Process.Start(new ProcessStartInfo
        {
            FileName = "node",
            Arguments = "CheckVersion.js",
            WorkingDirectory = @"Source\Service",
            RedirectStandardOutput = true,
            UseShellExecute = false,
            CreateNoWindow = true
        });


        using HttpClient client = new();
        string result = await client.GetStringAsync("http://localhost:3000/version");
        JsonDocument document = JsonDocument.Parse(result);


        string? actualVersion = document.RootElement.GetProperty("actual version").GetString();
        string? thisVersion = document.RootElement.GetProperty("this version").GetString();


        if (actualVersion.Replace("actual version:", "").Trim() != thisVersion.Replace("this version:", "").Trim())
        {
            int choose = MessageBox(IntPtr.Zero, $"Este software está desatualizado (Versão instalada: {thisVersion} Versão atual: {actualVersion})\nDeseja atualizar?", "Taskeasy Manager", 0x04 | 0x20);


            if (choose == 6)
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = "https://github.com/Willian-Thdr/Taskeasy_Manager/releases/latest",
                    UseShellExecute = true
                });
            }
        }
    }
}