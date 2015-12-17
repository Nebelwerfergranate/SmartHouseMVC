using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using SmartHouse;
using SmartHouseMVC.Models.Contexts;
using SmartHouseWF.Models.DeviceManager;

namespace SmartHouseMVC.Models.DeviceManager
{
    public class DatabaseDeviceManager
    {

        private DeviceContext _deviceContext = new DeviceContext();

        private Dictionary<string, MicrowaveInfo> microwaveInfo = new Dictionary<string, MicrowaveInfo>();
        private Dictionary<string, OvenInfo> ovenInfo = new Dictionary<string, OvenInfo>();
        private Dictionary<string, FridgeInfo> fridgeInfo = new Dictionary<string, FridgeInfo>();

        public DatabaseDeviceManager()
        {
            InitMicrowaveInfo();
            InitOvenInfo();
            InitFridgeInfo();
        }

        public Device GetDeviceById(int id)
        {
            int deviceTypeId = id / 10000;
            int deviceId = id % 10000;
            Device device = null;

            switch (deviceTypeId)
            {
                case 1:
                    device = _deviceContext.Clocks.Find(deviceId);
                    break;
            }
            return device;
        }

        public SortedDictionary<int, Device> GetDevices()
        {
            SortedDictionary<int, Device> devicesToReturn = new SortedDictionary<int, Device>();
            var deviceTable = _deviceContext.DeviceTableRows;
            foreach (DeviceTableRow deviceTableRow in deviceTable)
            {
                Device device = null;
                switch (deviceTableRow.DeviceTypeId)
                {
                    case 1:
                        device = deviceTableRow.Clock;
                        break;
                    case 2:
                        device = deviceTableRow.Microwave;
                        break;
                    case 3:
                        device = deviceTableRow.Oven;
                        break;
                    case 4:
                        device = deviceTableRow.Fridge;
                        break;
                }

                devicesToReturn.Add(deviceTableRow.Id, device);
            }
            return devicesToReturn;
        }

        public void AddDevice(string device = "", string name = "", string fabricator = "")
        {
            DeviceTableRow deviceTableRow = null;
            switch (device)
            {
                case "clock":
                    Clock clock = new Clock(name);
                    _deviceContext.Clocks.Add(clock);
                    deviceTableRow = new DeviceTableRow{DeviceTypeId = 1, Clock = clock};
                    break;
                default: return;
                case "microwave":
                    MicrowaveInfo mi = microwaveInfo[fabricator];
                    Microwave microwave = new Microwave(name, mi.Volume, mi.Lamp);
                    _deviceContext.Microwaves.Add(microwave);
                    deviceTableRow = new DeviceTableRow{DeviceTypeId = 2, Microwave = microwave};
                    break;
                case "oven":
                    OvenInfo oi = ovenInfo[fabricator];
                    Oven oven = new Oven(name, oi.Volume, oi.Lamp);
                    _deviceContext.Ovens.Add(oven);
                    deviceTableRow = new DeviceTableRow{DeviceTypeId = 3, Oven = oven};
                    break;
                case "fridge":
                    FridgeInfo fi = fridgeInfo[fabricator];
                    Fridge fridge = new Fridge(name, fi.Coldstore, fi.Freezer);
                    _deviceContext.Fridges.Add(fridge);
                    deviceTableRow = new DeviceTableRow{DeviceTypeId = 4, Fridge = fridge};
                    break;
            }
            _deviceContext.DeviceTableRows.Add(deviceTableRow);
            _deviceContext.SaveChanges();
        }

        public void RemoveById(int id)
        {
            DeviceTableRow row = _deviceContext.DeviceTableRows.Find(id);
            _deviceContext.DeviceTableRows.Remove(row);
            _deviceContext.SaveChanges();
        }

        public void UdpateDevice(Device device)
        {

        }

        public string[] GetMicrowaveNames()
        {
            return microwaveInfo.Keys.ToArray();
        }

        public string[] GetOvenNames()
        {
            return ovenInfo.Keys.ToArray();
        }

        public string[] GetFridgeNames()
        {
            return fridgeInfo.Keys.ToArray();
        }


        private void InitMicrowaveInfo()
        {
            microwaveInfo["Whirlpool"] = new MicrowaveInfo(20, new Lamp(25));
            microwaveInfo["Panasonic"] = new MicrowaveInfo(19, new Lamp(20));
            microwaveInfo["Lg"] = new MicrowaveInfo(23, new Lamp(25));
        }

        private void InitOvenInfo()
        {
            ovenInfo["Siemens"] = new OvenInfo(67, new Lamp(25));
            ovenInfo["Electrolux"] = new OvenInfo(74, new Lamp(25));
            ovenInfo["Pyramida"] = new OvenInfo(56, new Lamp(15));
        }

        private void InitFridgeInfo()
        {
            fridgeInfo["Samsung"] = new FridgeInfo(new Coldstore(254, new Lamp(15)), new Freezer(92));
            fridgeInfo["Indesit"] = new FridgeInfo(new Coldstore(233, new Lamp(15)), new Freezer(85));
            fridgeInfo["Atlant"] = new FridgeInfo(new Coldstore(202, new Lamp(15)), new Freezer(70));
        }
    }
}