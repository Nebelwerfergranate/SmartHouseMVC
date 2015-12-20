using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SmartHouse;
using SmartHouseMVC.Models.DeviceManager;
using SmartHouseWF.Models.DeviceManager;

namespace SmartHouseMVC.Controllers
{
    public class HomeController : Controller
    {
        // Fields
        private DatabaseDeviceManager db = new DatabaseDeviceManager();

        // GET: Home
        public ActionResult Index()
        {
            string[] microwaveNames = db.GetMicrowaveNames();
            string[] ovenNames = db.GetOvenNames();
            string[] fridgeNames = db.GetFridgeNames();

            ViewBag.microwaveNames = microwaveNames;
            ViewBag.ovenNames = ovenNames;
            ViewBag.fridgeNames = fridgeNames;

            return View(db.GetDevices());
        }

        public RedirectResult AddDevice(string device = "", string name = "", string fabricator = "")
        {
            db.AddDevice(device, name, fabricator);
            return Redirect("/Home/Index");
        }

        public RedirectResult RenameDevice(int id = 0, string newName = "")
        {
            if (id != 0)
            {
                Device device = db.GetDeviceById(id);
                if (device != null)
                {
                    device.Name = newName;
                    db.UpdateDeviceById(id, device);
                }
            }
            return Redirect("/Home/Index");
        }

        public RedirectResult RemoveDevice(int id = 0)
        {
            if (id != 0)
            {
                db.RemoveById(id);
            }
            return Redirect("/Home/Index");
        }

        // Device
        public RedirectResult ToogleDevice(int id)
        {
            if (id != 0)
            {
                Device device = db.GetDeviceById(id);
                if (device != null)
                {
                    if (device.IsOn)
                    {
                        device.TurnOff();
                    }
                    else
                    {
                        device.TurnOn();
                    }
                    db.UpdateDeviceById(id, device);
                }
            }
            return Redirect("/Home/Index");
        }
        
        //IClock
        public RedirectResult SetTime(uint? hours, uint? minutes, int id = 0)
        {
            if (id != 0 && hours != null && minutes != null && hours < 24 && minutes < 60)
            {
                Device device = db.GetDeviceById(id);
                if (device != null && device is IClock)
                {
                    ((IClock)device).CurrentTime = new DateTime(1, 1, 1, (int)hours, (int)minutes, 0);
                    db.UpdateDeviceById(id, device);
                }
            }
            return Redirect("/Home/Index");
        }

        // IOpenable
        public RedirectResult ToogleDoor(int id = 0)
        {
            if (id != 0)
            {
                Device device = db.GetDeviceById(id);
                if (device != null && device is IOpenable)
                {
                    IOpenable door = (IOpenable) device;
                    if (door.IsOpen)
                    {
                        door.Close();
                    }
                    else
                    {
                        door.Open();
                    }
                    db.UpdateDeviceById(id, device);
                }
            }
            return Redirect("/Home/Index");
        }
        
        // ITemperature
        public RedirectResult SetTemperature(double? temperature, int id = 0)
        {
            if (id != 0 && temperature != null)
            {
                Device device = db.GetDeviceById(id);
                if (device != null && device is ITemperature)
                {
                    ((ITemperature) device).Temperature = (double)temperature;
                }
                db.UpdateDeviceById(id, device);
            }
            return Redirect("/Home/Index");
        }

        // ITimer
        public RedirectResult TimerSet(uint? hours, uint? minutes, uint? seconds, int id = 0)
        {
            if (hours == null)
            {
                hours = 0;
            }
            if(minutes == null)
            {
                minutes = 0;
            }
            if (seconds == null)
            {
                seconds = 0;
            }
            if (id != 0 && hours < 24 && minutes < 60 && seconds < 60)
            {
                Device device = db.GetDeviceById(id);
                if (device != null && device is ITimer)
                {
                    ((ITimer)device).SetTimer(new TimeSpan((int)hours, (int)minutes, (int)seconds));
                }
                db.UpdateDeviceById(id, device);
            }
            return Redirect("/Home/Index");
        }
        
        public RedirectResult StartTimer(int id = 0)
        {
            if (id != 0)
            {
                Device device = db.GetDeviceById(id);
                if (device != null && device is ITimer)
                {
                    ((ITimer)device).Start();
                }
                db.UpdateDeviceById(id, device);
            }
            return Redirect("/Home/Index");
        }

        public RedirectResult PauseTimer(int id = 0)
        {
            if (id != 0)
            {
                Device device = db.GetDeviceById(id);
                if (device != null && device is ITimer)
                {
                    ((ITimer)device).Pause();
                }
                db.UpdateDeviceById(id, device);
            }
            return Redirect("/Home/Index");
        }

        public RedirectResult StopTimer(int id = 0)
        {
            if (id != 0)
            {
                Device device = db.GetDeviceById(id);
                if (device != null && device is ITimer)
                {
                    ((ITimer)device).Stop();
                }
                db.UpdateDeviceById(id, device);
            }
            return Redirect("/Home/Index");
        }

        // Fridge
        public RedirectResult ToogleColdstoreDoor(int id = 0)
        {
            if (id != 0)
            {
                Device device = db.GetDeviceById(id);
                if (device != null && device is Fridge)
                {
                    Fridge fridge = (Fridge) device;
                    if (fridge.ColdstoreIsOpen)
                    {
                        fridge.CloseColdstore();
                    }
                    else
                    {
                        fridge.OpenColdstore();
                    }
                    db.UpdateDeviceById(id, device);
                }
            }
            return Redirect("/Home/Index");
        }

        public RedirectResult ToogleFreezerDoor(int id = 0)
        {
            if (id != 0)
            {
                Device device = db.GetDeviceById(id);
                if (device != null && device is Fridge)
                {
                    Fridge fridge = (Fridge)device;
                    if (fridge.FreezerIsOpen)
                    {
                        fridge.CloseFreezer();
                    }
                    else
                    {
                        fridge.OpenFreezer();
                    }
                    db.UpdateDeviceById(id, device);
                }
            }
            return Redirect("/Home/Index");
        }

        public RedirectResult SetColdstoreTemperature(double? temperature, int id = 0)
        {
            if (id != 0 && temperature != null)
            {
                Device device = db.GetDeviceById(id);
                if (device != null && device is Fridge)
                {
                    ((Fridge) device).ColdstoreTemperature = (double)temperature;
                }
                db.UpdateDeviceById(id, device);
            }
            return Redirect("/Home/Index");
        }

        public RedirectResult SetFreezerTemperature(double? temperature, int id = 0)
        {
            if (id != 0 && temperature != null)
            {
                Device device = db.GetDeviceById(id);
                if (device != null && device is Fridge)
                {
                    ((Fridge) device).FreezerTemperature = (double) temperature;
                }
                db.UpdateDeviceById(id, device);
            }
            return Redirect("/Home/Index");
        }
    }
}