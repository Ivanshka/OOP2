using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Laba_1
{
    [Serializable]
    public abstract class Prototype<T>
    {
        /// <summary>
        /// Поверхностное копирование объекта
        /// </summary>
        public virtual T Clone() => (T)MemberwiseClone();

        /// <summary>
        /// Глубокое копирование объекта
        /// </summary>
        public virtual T DeepCopy()
        {
            using (var stream = new MemoryStream())
            {
                var context = new StreamingContext(StreamingContextStates.Clone);
                var formatter = new BinaryFormatter { Context = context };
                formatter.Serialize(stream, this);
                stream.Position = 0;
                return (T)formatter.Deserialize(stream);
            }
        }
    }

    [Serializable]
    class SuperMegaCoolString : Prototype<SuperMegaCoolString> { public string Text; }
}