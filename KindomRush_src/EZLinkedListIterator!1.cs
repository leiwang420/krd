using System;

public class EZLinkedListIterator<T> where T: IEZLinkedListItem<T>
{
    protected T cur;
    protected EZLinkedList<T> list;

    public EZLinkedListIterator()
    {
        base..ctor();
        return;
    }

    public bool Begin(EZLinkedList<T> l)
    {
        this.list = l;
        this.cur = l.Head;
        return (((T) this.cur) == null);
    }

    public void End()
    {
        this.list.End(this);
        return;
    }

    public unsafe bool Next()
    {
        if (((T) this.cur) == null)
        {
            goto Label_0027;
        }
        this.cur = &this.cur.next;
    Label_0027:
        if (((T) this.cur) != null)
        {
            goto Label_0045;
        }
        this.list.End(this);
        return 0;
    Label_0045:
        return 1;
    }

    public unsafe bool NextNoRemove()
    {
        if (((T) this.cur) == null)
        {
            goto Label_0027;
        }
        this.cur = &this.cur.next;
    Label_0027:
        return ((((T) this.cur) == null) == 0);
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

    public bool Done
    {
        get
        {
            return (((T) this.cur) == null);
        }
    }
}

