using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace SmartHouseWF.Models
{
    public class Validator
    {
        private readonly Regex timeRegex = new Regex("^[0-9]{1,2}$");
        private readonly Regex temperatureRegex = new Regex("(?:^-[0-9]{1,3}$)|(?:^[0-9]{1,4}$)");

        public bool GetSeconds(string userInput, out int seconds)
        {
            if (!ValidateTimeString(userInput))
            {
                seconds = 0;
                return false;
            }
            seconds = Int32.Parse(userInput);
            if (seconds < 0 || seconds > 59)
            {
                seconds = 0;
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool GetMinutes(string userInput, out int minutes)
        {
            if (!ValidateTimeString(userInput))
            {
                minutes = 0;
                return false;
            }
            minutes = Int32.Parse(userInput);
            if (minutes < 0 || minutes > 59)
            {
                minutes = 0;
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool GetHours(string userInput, out int hours)
        {
            if (!ValidateTimeString(userInput))
            {
                hours = 0;
                return false;
            }
            hours = Int32.Parse(userInput);
            if (hours < 0 || hours > 23)
            {
                hours = 0;
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool GetTemperature(string userInput, out int temperature)
        {
            if (!ValidateTemperatureString(userInput))
            {
                temperature = 0;
                return false;
            }
            temperature = Int32.Parse(userInput);

            // Валидация на основе значений производится не здесь.
            // Каждое устройство проверяет входное значение самостоятельно
            if (temperature < -273 || temperature > 6000)
            {
                temperature = 0;
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool ValidateTimeString(string userInput)
        {
            return (timeRegex.Match(userInput)).Success;
        }

        private bool ValidateTemperatureString(string userInput)
        {
            return (temperatureRegex.Match(userInput)).Success;
        }
    }
}