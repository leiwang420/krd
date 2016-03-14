using System;

public interface IEZLinkedListItem<T>
{
    T next { get; set; }

    T prev { get; set; }
}

