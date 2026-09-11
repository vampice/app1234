using System.Text.Json;

namespace app
{
    public sealed record PaletteHistoryEntry(string[] Colors);

    public sealed class PaletteHistory
    {
        public static PaletteHistory Current { get; } = new();

        private const string StorageKey = "palette-history";
        private readonly List<PaletteHistoryEntry> entries = new();

        private PaletteHistory()
        {
            Load();
        }

        public IReadOnlyList<PaletteHistoryEntry> Entries => entries;

        public event EventHandler? Changed;

        public void Add(IEnumerable<string> colors)
        {
            entries.Insert(0, new PaletteHistoryEntry(colors.ToArray()));
            Persist();
            Changed?.Invoke(this, EventArgs.Empty);
        }

        public void Clear()
        {
            entries.Clear();
            Persist();
            Changed?.Invoke(this, EventArgs.Empty);
        }

        private void Load()
        {
            var json = Preferences.Default.Get(StorageKey, string.Empty);
            if (string.IsNullOrWhiteSpace(json))
                return;

            try
            {
                var savedEntries = JsonSerializer.Deserialize<List<PaletteHistoryEntry>>(json);
                if (savedEntries is not null)
                    entries.AddRange(savedEntries);
            }
            catch (JsonException)
            {
                Preferences.Default.Remove(StorageKey);
            }
        }

        private void Persist()
        {
            var json = JsonSerializer.Serialize(entries);
            Preferences.Default.Set(StorageKey, json);
        }
    }
}
