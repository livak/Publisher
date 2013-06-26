﻿using NationalInstruments.NetworkVariable;
using Publisher.Subscriber.Intefaces;

namespace Publisher.Subscriber.Implementations.NationalInstruments
{
    class Item : IBrowserItem
    {
        private readonly BrowserItem _browserItem;

        public IBrowserItem ParentItem { get { return new Item(_browserItem); } }

        public string Name { get { return _browserItem.Name; } }
        public string Path { get { return _browserItem.Path; } }

        public Item(BrowserItem browserItem)
        {
            _browserItem = browserItem;
        }
    }
}