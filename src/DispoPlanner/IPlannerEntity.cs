using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace DispoPlanner
{
    /// <summary>
    /// Represents a planner entity
    /// </summary>
    public  interface IPlannerEntity
    {
        /// <summary>
        /// Appointments
        /// </summary>
        ObservableCollection<IAppointment> Appointments { get; set; }
    }
}
