using System;

public class SmallXmlParserException : SystemException
{
    private int column;
    private int line;

    public SmallXmlParserException(string msg, int line, int column)
    {
        base..ctor(string.Format("{0}. At ({1},{2})", msg, (int) line, (int) column));
        this.line = line;
        this.column = column;
        return;
    }

    public int Column
    {
        get
        {
            return this.column;
        }
    }

    public int Line
    {
        get
        {
            return this.line;
        }
    }
}

