using Api.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Api.Entities
{
    public class Payment
    {   
        private readonly static Regex _cardNumberRegex = new Regex("^[0-9]{16}$", RegexOptions.Compiled);
        private readonly static Regex _expiryRegex = new Regex("^[0-9]{2}/[0-9]{2}$", RegexOptions.Compiled);
        private readonly static Regex _ccvRegex = new Regex("^[0-9]{3}$", RegexOptions.Compiled);
        public string CardNumber { get; private set; }
        public string Expiry { get; private set; }
        public string Ccv { get; private set; }
        public int Amount { get; private set; }
        public CurrencyEnum Currency { get; private set; }

        public Payment(string cardNumber, string expiry, string ccv, int amount, CurrencyEnum currency)
        {
            AssignCardNumber(cardNumber);
            AssignExpiry(expiry);
            AssignCcv(ccv);
            Amount = amount;
            Currency = currency;
        }

        private void AssignCardNumber(string cardNumber)
        {
            if(string.IsNullOrEmpty(cardNumber) || !_cardNumberRegex.IsMatch(cardNumber))
            {
                throw new ArgumentException("Invalid card number");
            }
            CardNumber = cardNumber;
        }

        private void AssignExpiry(string expiry)
        {

            if (string.IsNullOrEmpty(expiry) || !ValidateExpiry(expiry))
            {
                throw new ArgumentException("Invalid expiry");
            }
            Expiry = expiry;
        }

        private void AssignCcv(string ccv)
        {
            if (string.IsNullOrEmpty(ccv) || !_ccvRegex.IsMatch(ccv))
            {
                throw new ArgumentException("Invalid ccv number");
            }
            Ccv = ccv;
        }

        private bool ValidateExpiry(string expiry)
        {
            var formatIsValid = _expiryRegex.IsMatch(expiry);
            if (!formatIsValid)
            {
                return false;
            }

            var temp = expiry.Split('/');
            try
            {
                var validDate = new DateTime(20 + int.Parse(temp[1]), int.Parse(temp[0]), 1);
                return true;
            }
            catch(ArgumentOutOfRangeException)
            {
                return false;
            }            
        }
    }
}
