﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

using static System.ComponentModel.DataAnnotations.Validator;

namespace UsefulStuff
{
    public static class ValidationUtils
    {
        private const string EMPTY = "";

        public static Output? AffirmUpOnProperties<T, Output>(this T type)
            where T : new()
            where Output : class, IComparable
        {
            var validationResults = new List<ValidationResult>();
            var context = new ValidationContext(type);
            var propertyInfos = type?.GetType().GetProperties().ToList();

            if (!TryValidateObject(type, context, validationResults, true))
            {
                return validationResults.Select(error =>
                {
                    string? erMsg = error?.ErrorMessage;
                    string? memberName = error?.MemberNames.FirstOrDefault(mn => !Equals(mn, default));

                    return string.Join(" :: ", memberName, erMsg);
                }).FirstOrDefault() as Output;
            }
            else
            {
                return propertyInfos?
                    .Select(pi => string.Join(";\n", string.Join($" :: ", pi.Name, pi.GetValue(type))))
                    .FirstOrDefault() as Output;
            }
        }

        public static void ThrowWhenNull(this object value)
        {
            if (value is null) 
                throw new ArgumentNullException(nameof(value), $"{nameof(value)} must not be null");
        }
    }
}
