using ManagedCommon;
using Wox.Plugin;

namespace Community.PowerToys.Run.Plugin.BoilerplateText
{
    public class Main : IPlugin, IPluginI18n
    {
        public static string PluginID => "6c631b4e-3d6d-4ff3-91df-7a33f94a4ef1";

        public string Name => "BoilerPlateText";

        public string Description => "Offers boilerplate snippets (text files) from %localappdata%\\Boilerplate and copies them to clipboard.";

        private string? IconPath { get; set; }

        private PluginInitContext? Context { get; set; }

        public string GetTranslatedPluginDescription()
        {
            // TODO: localization
            return Description;
        }

        public string GetTranslatedPluginTitle()
        {
            // TODO: localization
            return Name;
        }

        public void Init(PluginInitContext context)
        {
            Context = context;
            Context.API.ThemeChanged += OnThemeChanged;
            UpdateIconPath(context.API.GetCurrentTheme());
        }

        public List<Result> Query(Query query)
        {
            var list = new List<Result>();

            foreach (var file in System.IO.Directory.GetFiles(System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), "Boilerplate")))
            {
                var basename = System.IO.Path.GetFileNameWithoutExtension(file);
                if (query.Search.Length > 0 && !basename.Contains(query.Search, StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                list.Add(new Result
                {
                    Title = basename,
                    SubTitle = $"{file} - Copy to clipboard", // TODO: localization
                    IcoPath = IconPath,
                    Action = _ =>
                    {
                        System.Windows.Clipboard.SetText(System.IO.File.ReadAllText(file));
                        return true;
                    },
                });
            }

            return list;
        }

        private void OnThemeChanged(Theme currentTheme, Theme newTheme)
        {
            UpdateIconPath(newTheme);
        }

        private void UpdateIconPath(Theme theme)
        {
            var t = theme == Theme.Light || theme == Theme.HighContrastWhite ? "Light" : "Dark";
            IconPath = $@"Images\BoilerPlate{t}.png";
        }
    }
}
