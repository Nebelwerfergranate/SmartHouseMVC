﻿using System.ComponentModel.DataAnnotations.Schema;

namespace SmartHouse
{
    public class Fridge : Device
    {
        // Fields

        // Constructors
        public Fridge()
        { }
        public Fridge(string name, Coldstore coldstore, Freezer freezer)
            : base(name)
        {
            this.Coldstore = new Coldstore();
            this.Freezer = new Freezer();
        }


        // Properties
        public int ColdstoreId { get; set; }
        public virtual Coldstore Coldstore { get; set; }

        public int FreezerId { get; set; }
        public virtual Freezer Freezer { get; set; }
     
        [NotMapped]
        public bool ColdstoreIsOpen
        {
            get { return Coldstore.IsOpen; }
            set { Coldstore.IsOpen = value; }
        }
        [NotMapped]
        public double ColdstoreTemperature
        {
            get { return Coldstore.Temperature; }
            set { Coldstore.Temperature = value; }
        }
        [NotMapped]
        public double ColdstoreMinTemperature
        {
            get { return Coldstore.MinTemperature; }
        }
        [NotMapped]
        public double ColdstoreMaxTemperature
        {
            get { return Coldstore.MaxTemperature; }
        }
        [NotMapped]
        public bool ColdstoreIsHighlighted
        {
            get { return Coldstore.IsHighlighted; }
            set { Coldstore.IsHighlighted = value; }
        }
        [NotMapped]
        public double ColdstoreLampPower
        {
            get { return Coldstore.LampPower; }
            set { Coldstore.LampPower = value; }
        }
        [NotMapped]
        public double ColdstoreVolume
        {
            get { return Coldstore.Volume; }
            set { Coldstore.Volume = value; }
        }
        [NotMapped]
        public bool FreezerIsOpen
        {
            get { return Freezer.IsOpen; }
            set { Freezer.IsOpen = value; }
        }
        [NotMapped]
        public double FreezerTemperature
        {
            get { return Freezer.Temperature; }
            set { Freezer.Temperature = value; }
        }
        [NotMapped]
        public double FreezerMinTemperature
        {
            get { return Freezer.MinTemperature; }
        }
        [NotMapped]
        public double FreezerMaxTemperature
        {
            get { return Freezer.MaxTemperature; }
        }
        [NotMapped]
        public double FreezerVolume
        {
            get { return Freezer.Volume; }
            set { Freezer.Volume = value; }
        }


        // Methods
        public override void TurnOn()
        {
            base.TurnOn();
            Coldstore.TurnOn();
            Freezer.TurnOn();
        }
        public override void TurnOff()
        {
            base.TurnOff();
            Coldstore.TurnOff();
            Freezer.TurnOff();
        }

        public void OpenColdstore()
        {
            Coldstore.Open();
        }
        public void CloseColdstore()
        {
            Coldstore.Close();
        }
        public void OpenFreezer()
        {
            Freezer.Open();
        }
        public void CloseFreezer()
        {
            Freezer.Close();
        }
    }
}
