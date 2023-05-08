﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LinkedList
{
    public class LinkedList<T> : IEnumerable
    {
        public Item<T> Head { get; private set; }
        public Item<T> Tail { get; private set; }
        public int Count { get; private set; }
        public LinkedList()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }
        public LinkedList(T data)
        {
            SetHeadAndTail(data);
        }
        public void Add(T data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }
            var item = new Item<T>(data);
            if (Tail != null)
            {
                Tail.Next = item;
                Tail = item;
                Count++;
            }
            else
            {
                SetHeadAndTail(data);
            }
        }
        public void Delete(T data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }
            if (Head != null)
            {
                if (Head.Data.Equals(data))
                {
                    Head = Head.Next;
                    Count--;
                    return;
                }
                var current = Head.Next;
                var previous = Head.Next;
                while(current != null)
                {
                    if (current.Data.Equals(data))
                    {
                        previous.Next = current.Next;
                        Count--;
                    }
                    previous = current;
                    current = current.Next;
                }
            }
            else
            {
                SetHeadAndTail(data);
            }
        }
        public void Insert(T target, T data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }
            if (Head != null)
            {
               var current = Head;
               while (current != null)
               {
                    for (int i = 2; i < Count; i++)
                    {
                       if (i.Equals(target))
                       {
                          var item = new Item<T>(data);
                          item.Next = current.Next;
                          current.Next = item;
                          Count++;
                          return;
                       }
                       else
                       {
                          current = current.Next;
                       }
                    }
               }
            }
            else
            {
                SetHeadAndTail(target);
                Add(data);
            }
        }
        public void Sort()
        {
            var list = new List<T>(this.Cast<T>());
            list.Sort();
            var current = Head;
            foreach (var item in list)
            {
                current.Data = item;
                current = current.Next;
            }
        }
        public void Reverse()
        {
            if (Head == null || Head.Next == null)
            {
                return;
            }
            var previous = Head;
            var current = Head.Next;
            previous.Next = null;
            Tail = previous;
            while (current != null)
            {
                var next = current.Next;
                current.Next = previous;
                previous = current;
                current = next;
            }
            Head = previous;
        }
        public IEnumerator GetEnumerator()
        {
            var current = Head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
        private void SetHeadAndTail(T data)
        {
            var item = new Item<T>(data);
            Head = item;
            Tail = item;
            Count = 1;
        }
    }
}
