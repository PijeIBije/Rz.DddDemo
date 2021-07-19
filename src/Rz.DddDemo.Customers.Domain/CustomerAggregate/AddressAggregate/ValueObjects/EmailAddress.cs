﻿using System.Net.Mail;
using Rz.DddDemo.Base.Domain.ValueObject;

namespace Rz.DddDemo.Customers.Domain.CustomerAggregate.AddressAggregate.ValueObjects
{
    public class EmailAddress:StringValueObjectBase
    {
        public EmailAddress(string value) : base(value)
        {
            var _ = new MailAddress(value);
        }

        public static implicit operator EmailAddress(string value) => value != null ? new EmailAddress(value) : null;
    }
}
