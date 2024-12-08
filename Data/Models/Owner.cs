using System.Collections.Generic;
using System.Linq;

namespace kursOOP.Data.Models
{
    public class Owner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContactInfo { get; set; } // Телефон или e-mail
        public ICollection<Property> Properties { get; set; } = new List<Property>(); // Список объектов недвижимости

        public void AddProperty(Property property)
        {
            Properties.Add(property);
        }

        public void RemoveProperty(int propertyId)
        {
            var property = Properties.FirstOrDefault(p => p.Id == propertyId);
            if (property != null)
            {
                Properties.Remove(property);
            }
        }
    }
}
