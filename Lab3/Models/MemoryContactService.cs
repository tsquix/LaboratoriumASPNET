﻿using Labolatorium_3.Models;
using System;
using System.Collections.Generic;

namespace Labolatorium_3.Models
{
    public class MemoryContactService : IContactService
    {
        private Dictionary<int, Contact> _items = new Dictionary<int, Contact>();
        private readonly IDateTimeProvider _timeProvider;

        public MemoryContactService(IDateTimeProvider timeProvider)
        {
            _timeProvider = timeProvider;
        }

        public int Add(Contact item)
        {
            int id = _items.Keys.Count != 0 ? _items.Keys.Max() : 0;
            item.Id = id + 1;
            item.Created = _timeProvider.GetDateTime();
            _items.Add(item.Id, item);
            return item.Id;
        }


        public void Delete(int id)
        {
            _items.Remove(id);
        }

        public List<Contact> FindAll()
        {
            return _items.Values.ToList();
        }

        public Contact? FindById(int id)
        {
            return _items.GetValueOrDefault(id);
        }

        public void Update(Contact item)
        {
            _items[item.Id] = item;
        }
    }
}
