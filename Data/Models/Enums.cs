namespace kursOOP.Data.Models
{
    public enum PropertyStatus
    {
        Available, // Доступна
        Rented     // Сдана
    }

    public enum PropertyType
    {
        Apartment, // Квартира
        House,     // Дом
        Office,    // Офис
        Garage,    // Гараж
        Warehouse  // Склад
    }

    public enum AgreementStatus
    {
        Active,     // Активный
        Terminated  // Завершённый
    }

    public enum PaymentMethod
    {
        Cash,      // Наличные
        Card,      // Карта
        Transfer   // Перевод
    }
}
