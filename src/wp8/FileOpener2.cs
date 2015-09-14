using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Phone.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using Windows.Storage;
using System.Diagnostics;
using System.IO;

namespace WPCordovaClassLib.Cordova.Commands
{
    public class FileOpener2 : BaseCommand
    {

        public async void open(string options)
        {
            string[] args = JSON.JsonHelper.Deserialize<string[]>(options);
            this.openPath(args[0].Replace("/", "\\"), args[2]);
        }
        
        private async void openPath(string path, string cbid)
        {
            try
            {
                StorageFile file = await Windows.Storage.StorageFile.GetFileFromPathAsync(path);
                await Windows.System.Launcher.LaunchFileAsync(file);
                DispatchCommandResult(new PluginResult(PluginResult.Status.OK), cbid);
            }
            catch (FileNotFoundException)
            {
                this.openInLocalFolder(path, cbid);
            }
            catch (Exception)
            {
                DispatchCommandResult(new PluginResult(PluginResult.Status.ERROR), cbid);
            }
        }
        
        private async void openInLocalFolder(string path, string cbid)
        {
            try
            {
                StorageFile file = await Windows.Storage.StorageFile.GetFileFromPathAsync(
                    Path.Combine(
                        Windows.Storage.ApplicationData.Current.LocalFolder.Path,
                        path.TrimStart('\\')
                    )
                );
                await Windows.System.Launcher.LaunchFileAsync(file);
                DispatchCommandResult(new PluginResult(PluginResult.Status.OK), cbid);
            }
            catch (FileNotFoundException)
            {
                DispatchCommandResult(new PluginResult(PluginResult.Status.IO_EXCEPTION), cbid);
            }
            catch (Exception)
            {
                DispatchCommandResult(new PluginResult(PluginResult.Status.ERROR), cbid);
            }
        }
    }
}
