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
    public class DatabaseDeviceManager : IDisposable
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
            DeviceTableRow row = _deviceContext.DeviceTableRows.Find(id);
            if (row == null)
            {
                return null;
            }
            Device device = null;
            switch (row.DeviceTypeId)
            {
                case 1:
                    device = row.Clock;
                    break;
                case 2:
                    device = row.Microwave;
                    ((ITimer)device).CheckIsReady();
                    break;
                case 3:
                    device = row.Oven;
                    ((ITimer)device).CheckIsReady();
                    break;
                case 4:
                    device = row.Fridge;
                    break;
            }
            return device;
        }

        public void UpdateDeviceById(int id, Device device)
        {
            DeviceTableRow row = _deviceContext.DeviceTableRows.Find(id);
            if (row == null)
            {
                return;
            }
            switch (row.DeviceTypeId)
            {
                case 1:
                    if (device is Clock)
                    {
                        _deviceContext.Entry((Clock)device).State = EntityState.Modified;
                        _deviceContext.SaveChanges();
                    }
                    break;
                case 2:
                    if (device is Microwave)
                    {
                        _deviceContext.Entry((Microwave)device).State = EntityState.Modified;
                        _deviceContext.SaveChanges();
                    }
                    break;
                case 3:
                    if (device is Oven)
                    {
                        _deviceContext.Entry((Oven)device).State = EntityState.Modified;
                        _deviceContext.SaveChanges();
                    }
                    break;
                case 4:
                    if (device is Fridge)
                    {
                        _deviceContext.Entry((Fridge)device).State = EntityState.Modified;
                        _deviceContext.SaveChanges();
                    }
                    break;
            }
        }

        public SortedDictionary<int, Device> GetDevices()
        {
            SortedDictionary<int, Device> devicesToReturn = new SortedDictionary<int, Device>();
            var deviceTable = _deviceContext.DeviceTableRows;
            foreach (DeviceTableRow deviceTableRow in deviceTable)
            {
                Device device = GetDeviceById(deviceTableRow.Id);
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
                    deviceTableRow = new DeviceTableRow { DeviceTypeId = 1, Clock = clock };
                    break;
                case "microwave":
                    MicrowaveInfo mi = microwaveInfo[fabricator];
                    Microwave microwave = new Microwave(name, mi.Volume, mi.Lamp);
                    _deviceContext.Microwaves.Add(microwave);
                    deviceTableRow = new DeviceTableRow { DeviceTypeId = 2, Microwave = microwave };
                    break;
                case "oven":
                    OvenInfo oi = ovenInfo[fabricator];
                    Oven oven = new Oven(name, oi.Volume, oi.Lamp);
                    _deviceContext.Ovens.Add(oven);
                    deviceTableRow = new DeviceTableRow { DeviceTypeId = 3, Oven = oven };
                    break;
                case "fridge":
                    FridgeInfo fi = fridgeInfo[fabricator];
                    Fridge fridge = new Fridge(name, fi.Coldstore, fi.Freezer);
                    _deviceContext.Fridges.Add(fridge);
                    deviceTableRow = new DeviceTableRow { DeviceTypeId = 4, Fridge = fridge };
                    break;
                default: return;
            }
            _deviceContext.DeviceTableRows.Add(deviceTableRow);
            _deviceContext.SaveChanges();
        }

        public void RemoveById(int id)
        {
            DeviceTableRow row = _deviceContext.DeviceTableRows.Find(id);
            if (row == null)
            {
                return;
            }

            Device device = GetDeviceById(id);

            if (device is Clock)
            {
                _deviceContext.Clocks.Remove((Clock)device);
            }
            else if (device is Microwave)
            {
                _deviceContext.Microwaves.Remove((Microwave)device);
            }
            else if (device is Oven)
            {
                _deviceContext.Ovens.Remove((Oven)device);
            }
            else if (device is Fridge)
            {
                _deviceContext.Fridges.Remove((Fridge)device);
            }
            _deviceContext.DeviceTableRows.Remove(row);
            _deviceContext.SaveChanges();
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


        void IDisposable.Dispose()
        {
            _deviceContext.Dispose();
        }
    }
}