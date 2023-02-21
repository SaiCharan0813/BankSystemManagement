﻿using System;

namespace BankManagement
{
    public class TransactionHistory
    {
        public string SenderAccountId { get; set; }
        public string SenderBankId { get; set; }
        public string RecieverAccountId { get; set; }
        public string RecieverBankId { get; set; }
        public double TransactionAmount { get; set; }
        public string TransactionId { get; set; }
        public string TransactionType { get; set; }
    }
}
