using System;

namespace Sat.Recruitment.Api.Responses
{
    public class ErrorResponse
    {
        /// <summary>
        /// a URI identifier that categorizes the error
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        ///
        /// </summary>
        public DateTime TimeStamp { get; set; }

        /// <summary>
        ///  the HTTP response code (optional)
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// a brief, human-readable message about the error
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// a human-readable explanation of the error
        /// </summary>
        public string Detail { get; set; }

        /// <summary>
        /// a URI that identifies the specific occurrence of the error
        /// </summary>
        public string Instance { get; set; }
    }
}
