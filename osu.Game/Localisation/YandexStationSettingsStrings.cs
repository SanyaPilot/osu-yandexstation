// Copyright (c) SanyaPilot 2026

using osu.Framework.Localisation;

namespace osu.Game.Localisation
{
    public static class YandexStationSettingsStrings
    {
        private const string prefix = @"osu.Game.Resources.Localisation.YandexStationSettings";

        /// <summary>
        /// "Yandex Station"
        /// </summary>
        public static LocalisableString YandexStation => new TranslatableString(getKey(@"yandex_station"), @"Yandex Station");

        /// <summary>
        /// "Hostname / IP address"
        /// </summary>
        public static LocalisableString Hostname => new TranslatableString(getKey(@"hostname"), @"Hostname / IP address");

        /// <summary>
        /// "Port"
        /// </summary>
        public static LocalisableString Port => new TranslatableString(getKey(@"port"), @"Port");

        private static string getKey(string key) => $@"{prefix}:{key}";
    }
}
