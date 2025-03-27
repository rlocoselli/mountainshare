using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Controls.Handlers.Items;


#if ANDROID
using Android.Graphics;
#endif

namespace OutdoorShareMauiApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            // ✅ Supprimer l'underline et le fond gris sur Android pour plusieurs champs
#if ANDROID
            void RemoveAndroidUnderline(Android.Views.View view)
            {
                view.Background = null;
                //view.SetBackgroundColor(Color.Transparent);
            }

            EditorHandler.Mapper.AppendToMapping("NoUnderline", (handler, view) =>
            {
                RemoveAndroidUnderline(handler.PlatformView);
            });

            EntryHandler.Mapper.AppendToMapping("NoUnderline", (handler, view) =>
            {
                RemoveAndroidUnderline(handler.PlatformView);
            });

            PickerHandler.Mapper.AppendToMapping("NoUnderline", (handler, view) =>
            {
                RemoveAndroidUnderline(handler.PlatformView);
            });

            DatePickerHandler.Mapper.AppendToMapping("NoUnderline", (handler, view) =>
            {
                RemoveAndroidUnderline(handler.PlatformView);
            });

            TimePickerHandler.Mapper.AppendToMapping("NoUnderline", (handler, view) =>
            {
                RemoveAndroidUnderline(handler.PlatformView);
            });
            ScrollViewHandler.Mapper.AppendToMapping("NoScrollBar", (handler, view) =>
            {
                handler.PlatformView.VerticalScrollBarEnabled = false;
                handler.PlatformView.HorizontalScrollBarEnabled = false;
            });
            

#endif

            return builder.Build();
        }
    }
}
