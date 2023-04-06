using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;

namespace Demo.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public int CountDays { get; set; }
        public int CityId { get; set; }
        public virtual City City { get; set; }
        [NotMapped]
        public string Logo
        {
            get
            {
                var path = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"..\\..\\.."));
                var eventPath = $"\\Мероприятия\\";
                var types = new List<string>() { "jpg", "jpeg", "png" };
                foreach (var type in types)
                {
                    var file = $"{eventPath}{Id}.{type}";
                    if (File.Exists($"{path}{file}"))
                        return file;
                }
                return string.Empty;
            }
        }
    }
}
