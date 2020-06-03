using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_12
{
    public class Owner
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        // ссылка на машины
        public List<Car> Cars { get; set; }

        public override string ToString() => ID.ToString();
    }
}
