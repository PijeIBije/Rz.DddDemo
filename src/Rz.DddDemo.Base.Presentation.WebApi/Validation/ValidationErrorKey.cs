using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.VisualBasic;

namespace Rz.DddDemo.Base.Presentation.WebApi.Validation
{
    public class ValidationErrorKey
    {
        private readonly int lastKey = 0;

        private static readonly string MessagePrefix = $"Error id:";

        private static readonly string Value = $"Error stored in {nameof(ValidationErrorsDictionary)}";

        public ValidationErrorKey()
        {
            Key = lastKey++;
        }

        public int Key { get; }

        public ValidationResult ValidationResult =>new ValidationResult(ToMessage());

        private string ToMessage()
        {
            return $"{MessagePrefix}{lastKey}";
        }

        public bool CompareWithKeyAsMessage(string keyMessage)
        {
            var keyFromMessage = int.Parse(keyMessage.Substring(MessagePrefix.Length - 1));

            return keyFromMessage == Key;
        }

        public override bool Equals(object obj)
        {
            return obj is ValidationErrorKey validationErrorKey && Equals(validationErrorKey);
        }

        protected bool Equalt(ValidationErrorKey validationErrorKey)
        {
            return Key.Equals(validationErrorKey.Key);
        }

        public override int GetHashCode()
        {
            return Key;
        }
    }
}
