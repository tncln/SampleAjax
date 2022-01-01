using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAjax.Models
{
    public class Kullanici
    {
        public int Id { get; set; }
        public string Ad { get; set; }
    }
    public static class KullaniciIslem
    {
        private static List<Kullanici> kullanicilar = new List<Kullanici>()
        {
            new Kullanici{ Ad="test", Id=1},
            new Kullanici{ Ad="test2", Id=2},
            new Kullanici { Ad = "test3", Id = 3 },
            new Kullanici { Ad = "test4", Id = 4 }
        };
        public static List<Kullanici> GetirHepsi()
        {
            return kullanicilar;
        }
        public static Kullanici GetirId(int id)
        {
            return kullanicilar.FirstOrDefault(x => x.Id == id);
        }
        public static void Ekle(Kullanici kullanici)
        {
            kullanicilar.Add(kullanici);
        }
    }
}
