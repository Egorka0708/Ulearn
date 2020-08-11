using System;

namespace HotelAccounting
{
    //Класс, содержащий модель учёта
    class AccountingModel : ModelBase
    {
        private double price;

        public double Price //Цена за одну ночь
        {
            get { return price; }
            set
            {
                if (value >= 0) price = value;
                else throw new ArgumentException();
                NewTotal();
                Notify(nameof(Price));
            }
        }

        private int nightsCount;

        public int NightsCount //Кол-во ночей
        {
            get { return nightsCount; }
            set
            {
                if (value > 0) nightsCount = value;
                else throw new ArgumentException();
                NewTotal();
                Notify(nameof(NightsCount));
            }
        }

        private double discount;

        public double Discount //Скидка в процентах
        {
            get { return discount; }
            set
            {
                discount = value;
                if (discount != (-Total / (Price * NightsCount) + 1) * 100)
                    NewTotal();
                Notify(nameof(Discount));
            }
        }

        private double total;

        public double Total //Сумма счёта
        {
            get { return total; }
            set
            {
                if (value > 0) total = value;
                else throw new ArgumentException();
                if (total != Price * NightsCount * (1 - Discount / 100))
                    NewDiscount();
                Notify(nameof(Total));
            }
        }

        private void NewTotal() //Перерасчитывает сумму  счёта
        {
            Total = Price * NightsCount * (1 - Discount / 100);
        }

        private void NewDiscount() //Перерасчитывает скидку в процентах
        {
            Discount = (-Total / (Price * NightsCount) + 1) * 100;
        }

        public AccountingModel() //Начальные данные
        {
            price = 0;
            nightsCount = 1;
            discount = 0;
            total = 0;
        }
    }
}