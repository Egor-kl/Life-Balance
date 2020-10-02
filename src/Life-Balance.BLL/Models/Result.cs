using System;
using System.Collections.Generic;
using System.Linq;

namespace Life_Balance.BLL.Models
{
    public class Result
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="succeeded">Success result.</param>
        /// <param name="errors">Array of errors.</param>
        internal Result(bool succeeded, IEnumerable<string> errors)
        {
            Succeeded = succeeded;
            Errors = errors.ToArray();
        }

        /// <summary>
        /// Success result.
        /// </summary>
        public bool Succeeded { get; set; }

        /// <summary>
        /// Array of errors.
        /// </summary>
        public IEnumerable<string> Errors { get; set; }

        /// <summary>
        /// Success result.
        /// </summary>
        /// <returns>Result.</returns>
        public static Result Success()
        {
            return new Result(true, Array.Empty<string>());
        }

        /// <summary>
        /// Result with error.
        /// </summary>
        /// <param name="errors">Array of errors.</param>
        /// <returns>Result with errors.</returns>
        public static Result Failure(IEnumerable<string> errors)
        {
            return new Result(false, errors);
        }
    }
}
