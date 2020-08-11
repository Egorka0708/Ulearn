using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Constraints;


namespace TodoApplication
{
    public class Item<TItem>
    {
        public TItem Value;
        public int Index;
    }

    public class ListModel<TItem>
    {
        LimitedSizeStack<string> LastActions;
        LimitedSizeStack<Item<TItem>> RemovedItems;
        public List<TItem> Items { get; }
        public int Limit;

        public ListModel(int limit)
        {
            Items = new List<TItem>();
            Limit = limit;
            LastActions = new LimitedSizeStack<string>(limit);
            RemovedItems = new LimitedSizeStack<Item<TItem>>(limit);
        }

        public void AddItem(TItem item)
        {
            LastActions.Push("Add");
            Items.Add(item);
        }

        public void RemoveItem(int index)
        {
            LastActions.Push("Remove");
            RemovedItems.Push(new Item<TItem> { Value = Items[index], Index = index });
            Items.RemoveAt(index);
        }

        public bool CanUndo()
        {
            return LastActions.Count > 0;
        }

        public void Undo()
        {
            if (CanUndo())
            {
                if (LastActions.Pop() == "Add")
                {
                    Items.RemoveAt(Items.Count - 1);
                }
                else
                {
                    var lastRemovedItem = RemovedItems.Pop();
                    Items.Insert(lastRemovedItem.Index, lastRemovedItem.Value);
                }
            }
        }
    }
}
