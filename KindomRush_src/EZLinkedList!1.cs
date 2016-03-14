using System;
using System.Collections.Generic;

public class EZLinkedList<T> where T: IEZLinkedListItem<T>
{
    protected int count;
    protected T cur;
    private List<EZLinkedListIterator<T>> freeIters;
    protected T head;
    private List<EZLinkedListIterator<T>> iters;
    protected T nextItem;

    public EZLinkedList()
    {
        this.iters = new List<EZLinkedListIterator<T>>();
        this.freeIters = new List<EZLinkedListIterator<T>>();
        base..ctor();
        return;
    }

    public unsafe void Add(T item)
    {
        if (((T) this.head) == null)
        {
            goto Label_0035;
        }
        &item.next = this.head;
        &this.head.prev = item;
    Label_0035:
        this.head = item;
        this.count += 1;
        return;
    }

    public EZLinkedListIterator<T> Begin()
    {
        EZLinkedListIterator<T> iterator;
        if (this.freeIters.Count <= 0)
        {
            goto Label_0047;
        }
        iterator = this.freeIters[this.freeIters.Count - 1];
        this.freeIters.RemoveAt(this.freeIters.Count - 1);
        goto Label_004D;
    Label_0047:
        iterator = new EZLinkedListIterator<T>();
    Label_004D:
        this.iters.Add(iterator);
        iterator.Begin(this);
        return iterator;
    }

    public unsafe void Clear()
    {
        T local;
        T local2;
        T local3;
        T local4;
        this.count = 0;
        if (((T) this.head) != null)
        {
            goto Label_0018;
        }
        return;
    Label_0018:
        this.cur = this.head;
        this.head = default(T);
    Label_0033:
        local = &this.cur.next;
        local3 = default(T);
        &this.cur.prev = local3;
        local4 = default(T);
        &this.cur.next = local4;
        this.cur = local;
        if (((T) this.cur) != null)
        {
            goto Label_0033;
        }
        return;
    }

    public void End(EZLinkedListIterator<T> it)
    {
        if (this.iters.Remove(it) == null)
        {
            goto Label_001D;
        }
        this.freeIters.Add(it);
    Label_001D:
        return;
    }

    public unsafe bool MoveNext()
    {
        this.cur = this.nextItem;
        if (((T) this.cur) == null)
        {
            goto Label_0033;
        }
        this.nextItem = &this.cur.next;
    Label_0033:
        return ((((T) this.cur) == null) == 0);
    }

    public unsafe void Remove(T item)
    {
        int num;
        int num2;
        T local;
        T local2;
        T local3;
        T local4;
        T local5;
        T local6;
        T local7;
        T local8;
        if (((T) this.head) == null)
        {
            goto Label_001B;
        }
        if (((T) item) != null)
        {
            goto Label_001C;
        }
    Label_001B:
        return;
    Label_001C:
        if (&this.head.Equals((T) item) == null)
        {
            goto Label_00E0;
        }
        this.head = &item.next;
        if (this.iters.Count <= 0)
        {
            goto Label_0232;
        }
        num = 0;
        goto Label_00CA;
    Label_0063:
        if (((T) this.iters[num].Current) == null)
        {
            goto Label_00C6;
        }
        if (&this.iters[num].Current.Equals((T) item) == null)
        {
            goto Label_00C6;
        }
        this.iters[num].Current = &item.next;
    Label_00C6:
        num += 1;
    Label_00CA:
        if (num < this.iters.Count)
        {
            goto Label_0063;
        }
        goto Label_0232;
    Label_00E0:
        if (this.iters.Count <= 0)
        {
            goto Label_0170;
        }
        num2 = 0;
        goto Label_015F;
    Label_00F8:
        if (((T) this.iters[num2].Current) == null)
        {
            goto Label_015B;
        }
        if (&this.iters[num2].Current.Equals((T) item) == null)
        {
            goto Label_015B;
        }
        this.iters[num2].Current = &item.prev;
    Label_015B:
        num2 += 1;
    Label_015F:
        if (num2 < this.iters.Count)
        {
            goto Label_00F8;
        }
    Label_0170:
        if (((T) &item.next) == null)
        {
            goto Label_01F5;
        }
        if (((T) &item.prev) == null)
        {
            goto Label_01C7;
        }
        &&item.prev.next = &item.next;
    Label_01C7:
        &&item.next.prev = &item.prev;
        goto Label_0232;
    Label_01F5:
        if (((T) &item.prev) == null)
        {
            goto Label_0232;
        }
        &&item.prev.next = default(T);
    Label_0232:
        &item.next = default(T);
        &item.prev = default(T);
        this.count -= 1;
        return;
    }

    public unsafe bool Rewind()
    {
        T local;
        this.cur = this.head;
        if (((T) this.cur) == null)
        {
            goto Label_0035;
        }
        this.nextItem = &this.cur.next;
        return 1;
    Label_0035:
        this.nextItem = default(T);
        return 0;
    }

    public int Count
    {
        get
        {
            return this.count;
        }
    }

    public T Current
    {
        get
        {
            return this.cur;
        }
        set
        {
            this.cur = value;
            return;
        }
    }

    public bool Empty
    {
        get
        {
            return (((T) this.head) == null);
        }
    }

    public T Head
    {
        get
        {
            return this.head;
        }
    }
}

