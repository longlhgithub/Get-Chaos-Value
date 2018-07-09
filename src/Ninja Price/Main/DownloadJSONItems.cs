﻿using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Ninja_Price.API.PoeNinja;
using Ninja_Price.API.PoeNinja.Classes;

namespace Ninja_Price.Main
{
    public partial class Main
    {
        private const string CurrencyURL = "http://poe.ninja/api/Data/GetCurrencyOverview?league=";
        private const string DivinationCards_URL = "http://poe.ninja/api/Data/GetDivinationCardsOverview?league=";
        private const string Essences_URL = "http://poe.ninja/api/Data/GetEssenceOverview?league=";
        private const string Fragments_URL = "http://poe.ninja/api/Data/GetFragmentOverview?league=";
        private const string Prophecies_URL = "http://poe.ninja/api/Data/GetProphecyOverview?league=";
        private const string UniqueAccessories_URL = "http://poe.ninja/api/Data/GetUniqueAccessoryOverview?league=";
        private const string UniqueArmours_URL = "http://poe.ninja/api/Data/GetUniqueArmourOverview?league=";
        private const string UniqueFlasks_URL = "http://poe.ninja/api/Data/GetUniqueFlaskOverview?league=";
        private const string UniqueJewels_URL = "http://poe.ninja/api/Data/GetUniqueJewelOverview?league=";
        private const string UniqueMaps_URL = "http://poe.ninja/api/Data/GetUniqueMapOverview?league=";
        private const string UniqueWeapons_URL = "http://poe.ninja/api/Data/GetUniqueWeaponOverview?league=";
        private const string WhiteMaps_URL = "http://poe.ninja/api/Data/GetMapOverview?league=";

        private void GetJsonData(string league)
        {
            Task.Run(() =>
            {
                LogMessage("Gathering Data from Poe.Ninja.", 5);
                Api.Json.SaveSettingFile(NinjaDirectory + "Currency.json", JsonConvert.DeserializeObject<Currency.RootObject>(Api.DownloadFromUrl(CurrencyURL + league)));
                Api.Json.SaveSettingFile(NinjaDirectory + "DivinationCards.json", JsonConvert.DeserializeObject<DivinationCards.RootObject>(Api.DownloadFromUrl(DivinationCards_URL + league)));
                Api.Json.SaveSettingFile(NinjaDirectory + "Essences.json", JsonConvert.DeserializeObject<Essences.RootObject>(Api.DownloadFromUrl(Essences_URL + league)));
                Api.Json.SaveSettingFile(NinjaDirectory + "Fragments.json", JsonConvert.DeserializeObject<Fragments.RootObject>(Api.DownloadFromUrl(Fragments_URL + league)));
                Api.Json.SaveSettingFile(NinjaDirectory + "Prophecies.json", JsonConvert.DeserializeObject<Prophecies.RootObject>(Api.DownloadFromUrl(Prophecies_URL + league)));
                Api.Json.SaveSettingFile(NinjaDirectory + "UniqueAccessories.json", JsonConvert.DeserializeObject<UniqueAccessories.RootObject>(Api.DownloadFromUrl(UniqueAccessories_URL + league)));
                Api.Json.SaveSettingFile(NinjaDirectory + "UniqueArmours.json", JsonConvert.DeserializeObject<UniqueArmours.RootObject>(Api.DownloadFromUrl(UniqueArmours_URL + league)));
                Api.Json.SaveSettingFile(NinjaDirectory + "UniqueFlasks.json", JsonConvert.DeserializeObject<UniqueFlasks.RootObject>(Api.DownloadFromUrl(UniqueFlasks_URL + league)));
                Api.Json.SaveSettingFile(NinjaDirectory + "UniqueJewels.json", JsonConvert.DeserializeObject<UniqueJewels.RootObject>(Api.DownloadFromUrl(UniqueJewels_URL + league)));
                Api.Json.SaveSettingFile(NinjaDirectory + "UniqueMaps.json", JsonConvert.DeserializeObject<UniqueMaps.RootObject>(Api.DownloadFromUrl(UniqueMaps_URL + league)));
                Api.Json.SaveSettingFile(NinjaDirectory + "UniqueWeapons.json", JsonConvert.DeserializeObject<UniqueWeapons.RootObject>(Api.DownloadFromUrl(UniqueWeapons_URL + league)));
                Api.Json.SaveSettingFile(NinjaDirectory + "WhiteMaps.json", JsonConvert.DeserializeObject<WhiteMaps.RootObject>(Api.DownloadFromUrl(WhiteMaps_URL + league)));
                LogMessage("Finished Gathering Data from Poe.Ninja.", 5);
                UpdatePoeNinjaData();
            });
        }

        public bool JsonExists(string fileName)
        {
            return File.Exists(NinjaDirectory + fileName);
        }

        private void UpdatePoeNinjaData()
        {
            var newData = new CollectiveApiData();

            if (JsonExists("Currency.json"))
                using (var r = new StreamReader(NinjaDirectory + "Currency.json"))
                {
                    var json = r.ReadToEnd();
                    newData.Currency = JsonConvert.DeserializeObject<Currency.RootObject>(json);
                }

            if (JsonExists("DivinationCards.json"))
                using (var r = new StreamReader(NinjaDirectory + "DivinationCards.json"))
                {
                    var json = r.ReadToEnd();
                    newData.DivinationCards = JsonConvert.DeserializeObject<DivinationCards.RootObject>(json);
                }

            if (JsonExists("Essences.json"))
                using (var r = new StreamReader(NinjaDirectory + "Essences.json"))
                {
                    var json = r.ReadToEnd();
                    newData.Essences = JsonConvert.DeserializeObject<Essences.RootObject>(json);
                }

            if (JsonExists("Fragments.json"))
                using (var r = new StreamReader(NinjaDirectory + "Fragments.json"))
                {
                    var json = r.ReadToEnd();
                    newData.Fragments = JsonConvert.DeserializeObject<Fragments.RootObject>(json);
                }

            if (JsonExists("Prophecies.json"))
                using (var r = new StreamReader(NinjaDirectory + "Prophecies.json"))
                {
                    var json = r.ReadToEnd();
                    newData.Prophecies = JsonConvert.DeserializeObject<Prophecies.RootObject>(json);
                }

            if (JsonExists("UniqueAccessories.json"))
                using (var r = new StreamReader(NinjaDirectory + "UniqueAccessories.json"))
                {
                    var json = r.ReadToEnd();
                    newData.UniqueAccessories = JsonConvert.DeserializeObject<UniqueAccessories.RootObject>(json);
                }

            if (JsonExists("UniqueArmours.json"))
                using (var r = new StreamReader(NinjaDirectory + "UniqueArmours.json"))
                {
                    var json = r.ReadToEnd();
                    newData.UniqueArmours = JsonConvert.DeserializeObject<UniqueArmours.RootObject>(json);
                }

            if (JsonExists("UniqueFlasks.json"))
                using (var r = new StreamReader(NinjaDirectory + "UniqueFlasks.json"))
                {
                    var json = r.ReadToEnd();
                    newData.UniqueFlasks = JsonConvert.DeserializeObject<UniqueFlasks.RootObject>(json);
                }

            if (JsonExists("UniqueJewels.json"))
                using (var r = new StreamReader(NinjaDirectory + "UniqueJewels.json"))
                {
                    var json = r.ReadToEnd();
                    newData.UniqueJewels = JsonConvert.DeserializeObject<UniqueJewels.RootObject>(json);
                }

            if (JsonExists("UniqueMaps.json"))
                using (var r = new StreamReader(NinjaDirectory + "UniqueMaps.json"))
                {
                    var json = r.ReadToEnd();
                    newData.UniqueMaps = JsonConvert.DeserializeObject<UniqueMaps.RootObject>(json);
                }

            if (JsonExists("UniqueWeapons.json"))
                using (var r = new StreamReader(NinjaDirectory + "UniqueWeapons.json"))
                {
                    var json = r.ReadToEnd();
                    newData.UniqueWeapons = JsonConvert.DeserializeObject<UniqueWeapons.RootObject>(json);
                }

            if (JsonExists("WhiteMaps.json"))
                using (var r = new StreamReader(NinjaDirectory + "WhiteMaps.json"))
                {
                    var json = r.ReadToEnd();
                    newData.WhiteMaps = JsonConvert.DeserializeObject<WhiteMaps.RootObject>(json);
                }

            CollectedData = newData;
            LogMessage("Updated CollectedData.", 5);
        }
    }
}