﻿using CarRacing.Models.Cars.Contracts;
using CarRacing.Utilities.Messages;
using System;

public abstract class Car : ICar
{
    protected Car(string make, string model, string vin, int horsePower, double fuelAvailable, double fuelConsumptionPerRace)
    {
        Make = make;
        Model = model;
        VIN = vin;
        HorsePower = horsePower;
        FuelAvailable = fuelAvailable;
        FuelConsumptionPerRace = fuelConsumptionPerRace;
    }

    private string make;
    private string vin;
    private int horsePower;
    private string model;
    private double fuelConsumptionPerRace;
    private double fuelAvailable;

    public string Make
    {
        get
        {
            return make;
        }
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(ExceptionMessages.InvalidCarMake);
            }
            make = value;
        }
    }

    public string Model
    {
        get
        {
            return model;
        }
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(ExceptionMessages.InvalidCarModel);
            }
            model = value;
        }
    }

    public string VIN
    {
        get
        {
            return vin;
        }
        private set
        {
            if (value.Length != 17)
            {
                throw new ArgumentException(ExceptionMessages.InvalidCarVIN);
            }
            vin = value;
        }
    }

    public int HorsePower
    {
        get
        {
            return horsePower;
        }
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException(ExceptionMessages.InvalidCarHorsePower);
            }
            horsePower = value;
        }
    }

    public double FuelAvailable
    {
        get
        {
            return fuelAvailable;
        }
        private set
        {
            if (value < 0)
            {
                value = 0;
            }
            fuelAvailable = value;
        }
    }

    public double FuelConsumptionPerRace
    {
        get
        {
            return fuelConsumptionPerRace;
        }
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException(ExceptionMessages.InvalidCarFuelConsumption);
            }
            fuelConsumptionPerRace = value;
        }
    }

    public virtual void Drive()
    {
        FuelAvailable -= FuelConsumptionPerRace;
    }
}
