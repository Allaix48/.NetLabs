﻿using System;
using System.Collections.Generic;
using System.Text;
/*Прокат автомобилей
1. Автомобили (марка, стоимость, стоимость проката, тип).*/
namespace ClassLibraryRentService
{
    /// <summary>
    /// Автомобиль
    /// </summary>
    public class Car
    {
        /// <summary>
        ///Номер
        /// <summary>
        public int Number { get; set; } = 0;
        /// <summary>
        ///Марка
        /// <summary>
        public string Mark { get; set; } = "";
        /// <summary>
        ///Стоимость
         /// <summary>
        public decimal Price { get; set; } = 0;
        /// <summary>
        ///Стоимость проката
        /// </summary>

        public decimal PriceRent { get; set; } = 0;
        public CarType Type { get; set; } = CarType.PassengerСar;

        public bool IsValid
        {
            get
            {
                if
                (string.IsNullOrWhiteSpace(Mark)) return false;
                if
                (Number== 0) return false;
                if
                (Price ==0) return false;
                if
                (PriceRent == 0) return false;
               
                return true;
            }
        }


        public Car()
        {
        }
        public Car(string mark, decimal price, int number, decimal priceRent, CarType type)
        {
            Mark = mark;
            Number = number;
            Price = price;
            PriceRent = priceRent;
            Type = type;

        }
        public override string ToString()
        {
            return $" Марка:{Mark}\r\n Номер:{Number}\r\n Стоимость:{Price}\r\nСтоимость аренды: { PriceRent}\r\n Тип: {Type}\r\n";
        }
    }
}
