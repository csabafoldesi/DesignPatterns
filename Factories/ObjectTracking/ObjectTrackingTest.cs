using System.Text;

namespace Factories.ObjectTracking
{
    public interface ITheme
    {
        string TextColor { get; }
        string BrgColor { get; }
    }

    class LightTheme : ITheme
    {
        public string TextColor => "black";

        public string BrgColor => "white";
    }

    class DarkTheme : ITheme
    {
        public string TextColor => "white";

        public string BrgColor => "dark gray";
    }

    public class TrackingThemeFactory
    {
        private readonly List<WeakReference<ITheme>> themes = new();

        public ITheme CreateTheme(bool dark)
        {
            ITheme theme = dark ? new DarkTheme() : new LightTheme();
            themes.Add(new WeakReference<ITheme>(theme));
            return theme;
        }

        public string Info
        {
            get
            {
                var sb = new StringBuilder();
                themes.ForEach(t =>
                {
                    if (t.TryGetTarget(out var theme))
                    {
                        sb.Append(theme is DarkTheme ? "Dark" : "Light")
                          .AppendLine(" theme");
                    }
                });
                return sb.ToString();
            }
        }
    }

    public class Ref<T> where T : class
    {
        public T Value;

        public Ref(T value)
        {
            Value = value;
        }
    }

    public class ReplacableThemeFactors
    {
        private readonly List<WeakReference<Ref<ITheme>>> themes = new();

        private ITheme createThemeImpl(bool dark)
        {
            return dark ? new DarkTheme() : new LightTheme();
        }

        public Ref<ITheme> CreateTheme(bool dark)
        {
            var r = new Ref<ITheme>(createThemeImpl(dark));
            themes.Add(new WeakReference<Ref<ITheme>>(r));
            return r;
        }

        public void replaceTheme(bool dark)
        {
            foreach(var wr in themes)
            {
                if(wr.TryGetTarget(out var reference))
                {
                    reference.Value = createThemeImpl(dark);
                }
            }
        }
        public string Info
        {
            get
            {
                var sb = new StringBuilder();
                themes.ForEach(t =>
                {
                    if (t.TryGetTarget(out var reference))
                    {
                        sb.Append(reference.Value is DarkTheme ? "Dark" : "Light")
                          .AppendLine(" theme");
                    }
                });
                return sb.ToString();
            }
        }

    }

    public class ObjectTrackingTest
    {
        public static void Run()
        {
            var factory = new TrackingThemeFactory();
            var theme1 = factory.CreateTheme(false);
            var theme2 = factory.CreateTheme(true);
            var theme3 = factory.CreateTheme(false);
            Console.WriteLine(factory.Info);

            var factory2 = new ReplacableThemeFactors();
            var magicTheme = factory2.CreateTheme(true);
            var magicTheme1 = factory2.CreateTheme(true);
            var magicTheme2 = factory2.CreateTheme(false);
            Console.WriteLine(factory2.Info);
            factory2.replaceTheme(true);
            Console.WriteLine(factory2.Info);
        }
    }
}
