﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Skrotlog.Domain;

namespace Skrotlog.UI
{
    public class ContractLineDisplayItem
    {
        Contract parentContract;
        ContractLine contractLineItem;

        public int ContractId
        {
            get { return parentContract.Id; }
        }
        public DateTime Date
        {
            get { return parentContract.Date; }
        }
        public string CustomerName
        {
            get { return parentContract.Customer.Name; }
        }
        public string MaterialName
        {
            get { return contractLineItem.Material.Type; }
        }
        public decimal MaterialPrice
        {
            get { return contractLineItem.Price; }
        }
        public Currency Currency
        {
            get { return parentContract.Currency; }
        }
        public int TotalAmount
        {
            get { return contractLineItem.TotalAmount; }
        }
        public int DeliveredAmount
        {
            get { return contractLineItem.DeliveredAmount; }
        }
        public int RemainingAmount
        {
            get { return contractLineItem.RemainingAmount; }
        }
        public string Comment
        {
            get { return contractLineItem.Comment; }
        }
        public string Initials
        {
            get { return parentContract.Initials; }
        }
        public bool Active
        {
            get { return contractLineItem.Active; }
        }
        
        public ContractLineDisplayItem(Contract contract, ContractLine contractLine)
        {
            parentContract = contract;
            contractLineItem = contractLine;
        }
    }
}