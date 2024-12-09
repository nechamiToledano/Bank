﻿using Bank.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Core.InterfaceService
{
    public interface ICreditCardService
    {
        IEnumerable<CreditCard> GetAllCards();
        CreditCard GetCard(int id);
        bool AddCard(CreditCard creditCard);
        bool UpdateCard(CreditCard creditCard);
        bool DeleteCard(int id);
    }
}