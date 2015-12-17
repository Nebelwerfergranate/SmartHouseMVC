namespace SmartHouse
{
    public abstract class Device
    {
        // Fields
        protected bool isOn;


        // Constructors
        protected Device()
        {
            Name = "";
        }
        protected Device(string name)
        {
            Name = name;
        }

        // Properties
        public int Id { get; set; }
        public string Name {get; set; }
        public bool IsOn
        {
            get { return isOn; }
            set { isOn = value; }
        }

        // Methods
        public virtual void TurnOn()
        {
            isOn = true;
        }
        public virtual void TurnOff()
        {
            isOn = false;
        }
    }
}
