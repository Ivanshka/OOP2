using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Laba_7
{
    /// <summary>
    /// Приоритет задачи.
    /// </summary>
    public enum TaskPriority { High, Middle, Low }
    /// <summary>
    /// Статус задачи: завершена, выполняется, перенесена.
    /// </summary>
    //public enum TaskStatus { Completed, Executing, Rescheduled }
    /// <summary>
    /// Периодичность задачи: однократная, ежедневная, еженедельная, ежемесячная или годовая.
    /// </summary>
    public enum Periodicity { Single, Daily, Weekly, Monthly, Annual }
    
    [DataContract]
    public class Task
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public DateTime? Start { get; set; }
        [DataMember]
        public DateTime? End { get; set; }
        /// <summary>
        /// Index for diffenrent localizations support
        /// </summary>
        [DataMember]
        public Periodicity PeriodicityIndex { get; set; }
        /// <summary>
        /// Index for diffenrent localizations support
        /// </summary>
        [DataMember]
        public TaskPriority PriorityIndex { get; set; }
        public string Periodicity { get; set; }
        public string Priority { get; set; }
        [DataMember]
        public string Category { get; set; }
        //public TaskStatus Status { get; set; } // дану его...
    }
}
