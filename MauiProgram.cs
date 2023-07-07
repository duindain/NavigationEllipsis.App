using Microsoft.Extensions.Logging;
#if WINDOWS
using Windows.UI.ViewManagement.Core;
#endif

namespace NavigationEllipsis;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

#if WINDOWS
            //From https://github.com/dotnet/maui/issues/12063 work around for WinUI toolbar issue
            Microsoft.Maui.Handlers.ToolbarHandler.Mapper.Add("FixPlacement", (handler, view) =>
            {
                handler.PlatformView.DefaultLabelPosition = Microsoft.UI.Xaml.Controls.CommandBarDefaultLabelPosition.Right;
            });
#endif
        return builder.Build();
	}
}
