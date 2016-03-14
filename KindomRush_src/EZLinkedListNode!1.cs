using System;

public class EZLinkedListNode<T> : IEZLinkedListItem<EZLinkedListNode<T>>
{
    private EZLinkedListNode<T> m_next;
    private EZLinkedListNode<T> m_prev;
    public T val;

    public EZLinkedListNode(T v)
    {
        base..ctor();
        this.val = v;
        return;
    }

    public EZLinkedListNode<T> next
    {
        get
        {
            return this.m_next;
        }
        set
        {
            this.m_next = value;
            return;
        }
    }

    public EZLinkedListNode<T> prev
    {
        get
        {
            return this.m_prev;
        }
        set
        {
            this.m_prev = value;
            return;
        }
    }
}

