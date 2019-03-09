namespace GOoDcast.Models.Receiver
{
    using System.Collections.Generic;

    /// <summary>
    /// Application
    /// </summary>
    
    public class Application
    {
        /// <summary>
        /// Gets or sets the application identifier
        /// </summary>
    
        public string AppId { get; set; }

        /// <summary>
        /// Gets or sets the display name
        /// </summary>
    
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the backdrop app is running or not 
        /// </summary>
    
        public bool IsIdleScreen { get; set; }

        /// <summary>
        /// Gets or sets the namespaces
        /// </summary>
    
        public IEnumerable<Namespace> Namespaces { get; set; }

        /// <summary>
        /// Gets or sets the session identifier
        /// </summary>
    
        public string SessionId { get; set; }

        /// <summary>
        /// Gets or sets the status text
        /// </summary>
    
        public string StatusText { get; set; }

        /// <summary>
        /// Gets or sets the transport identifier
        /// </summary>
    
        public string TransportId { get; set; }
    }
}
