// Copyright (c) SanyaPilot 2026

#nullable disable

using osu.Framework.Allocation;
using osu.Framework.Bindables;
using osu.Framework.Input.Handlers.YandexStation;
using osu.Framework.Localisation;
using osu.Game.Graphics.UserInterfaceV2;
using osu.Game.Localisation;

namespace osu.Game.Overlays.Settings.Sections.Input
{
    public partial class YandexStationSettings : InputSubsection
    {
        protected override LocalisableString Header => YandexStationSettingsStrings.YandexStation;

        private readonly YandexStationHandler stationHandler;

        private Bindable<string> hostname;

        private BindableInt port;

        private Bindable<string> portString;

        public YandexStationSettings(YandexStationHandler stationHandler)
            : base(stationHandler)
        {
            this.stationHandler = stationHandler;
        }

        [BackgroundDependencyLoader]
        private void load()
        {
            // use local bindable to avoid changing enabled state of game host's bindable.
            hostname = stationHandler.Hostname.GetBoundCopy();
            port = (BindableInt)stationHandler.Port.GetBoundCopy();
            portString = new(port.Value.ToString());

            FormNumberBox portBox;
            AddRange(
            [
                new SettingsItemV2(new FormTextBox
                {
                    Caption = YandexStationSettingsStrings.Hostname,
                    Current = hostname
                }),
                new SettingsItemV2(portBox = new FormNumberBox
                {
                    Caption = YandexStationSettingsStrings.Port,
                    Current = portString
                })
            ]);
            portBox.OnCommit += (_, _) =>
            {
                if (int.TryParse(portBox.Current.Value, out int parsed))
                    if (parsed > 0 && parsed < 65536)
                    {
                        port.Value = parsed;
                    }
                    else
                    {
                        portBox.Current.Value = port.Value.ToString();
                    }
            };
        }
    }
}
