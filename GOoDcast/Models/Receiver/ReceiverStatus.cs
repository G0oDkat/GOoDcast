namespace GOoDcast.Models.Receiver
{
    using System.Collections.Generic;

    /// <summary>
    /// Receiver status
    /// </summary>
    public class ReceiverStatus
    {
        /// <summary>
        /// Gets or sets the applications collection
        /// </summary>
        public IEnumerable<Application> Applications { get; set; }

        /// <summary>
        /// Gets or sets the volume
        /// </summary>
        public Volume Volume { get; set; }
    }
}
