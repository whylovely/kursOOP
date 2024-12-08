namespace kursOOP.Data.Models
{
    public class Property
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public double Area { get; set; } // Площадь
        public decimal Price { get; set; } // Арендная стоимость
        public PropertyStatus Status { get; set; } = PropertyStatus.Available; // Доступность
        public PropertyType TypeId { get; set; } // Тип недвижимости
        public int OwnerId { get; set; } // ID владельца
        public Owner Owner { get; set; } // Ссылка на владельца

        public void MarkAsRented()
        {
            Status = PropertyStatus.Rented;
        }

        public void MarkAsAvailable()
        {
            Status = PropertyStatus.Available;
        }
    }
}