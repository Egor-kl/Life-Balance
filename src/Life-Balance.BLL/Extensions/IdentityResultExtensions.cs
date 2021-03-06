﻿using Life_Balance.BLL.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;

namespace Life_Balance.BLL.Extencions
{
    public static class IdentityResultExtensions
    {
        /// <summary>
        /// Identity.
        /// </summary>
        /// <param name="result">Identity result.</param>
        /// <returns>Result.</returns>
        public static Result ToApplicationResult(this IdentityResult result)
        {
            result = result ?? throw new ArgumentNullException(nameof(result));

            return result.Succeeded
                ? Result.Success()
                : Result.Failure(result.Errors.Select(e => e.Description));
        }

        /// <summary>
        /// Sign in identity
        /// </summary>
        /// <param name="result">sign in result</param>
        /// <returns>Result</returns>
        public static Result ToApplicationResult(this SignInResult result)
        {
            result = result ?? throw new ArgumentNullException(nameof(result));

            return result.Succeeded
                ? Result.Success()
                : Result.Failure(Array.Empty<string>());
        }
    }
}
