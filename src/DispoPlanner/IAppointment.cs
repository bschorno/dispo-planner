using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;

namespace DispoPlanner
{
    /// <summary>
    /// Represents an appointment
    /// </summary>
    public interface IAppointment
    {
        /// <summary>
        /// Start date
        /// </summary>
        DateTime Start { get; set; }

        /// <summary>
        /// End date
        /// </summary>
        DateTime End { get; set; }

        /// <summary>
        /// Appointment subject
        /// </summary>
        string Subject { get; set; }

        /// <summary>
        /// Appointment style
        /// </summary>
        AppointmentStyle Style { get; set; }
    }
}
