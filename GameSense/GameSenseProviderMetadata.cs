﻿using Common;

namespace GameSense
{
    public class GameSenseProviderMetadata : ProviderMetadata
    {
        public override string ProviderName => "GameSense";

        public override string ProviderShortDescription => "SteelSeries GameSense";

        public override string ProviderFullDescription => ProviderShortDescription;

        public override string ProviderIconAssetPath => "/Assets/Logos/SteelSeriesLogo.png";
        public override string ProviderUrl => "https://steelseries.com/developer";
    }
}