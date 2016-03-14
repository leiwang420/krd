using System;
using System.Collections;

public class AStarGrid
{
    private AStarNode endNode;
    private ArrayList nodes;
    private int numCols;
    private int numRows;
    private AStarNode startNode;

    public AStarGrid()
    {
        base..ctor();
        return;
    }

    public AStarNode GetNodeAtPosition(int x, int y)
    {
        if (this.nodes.Count > x)
        {
            goto Label_0013;
        }
        return null;
    Label_0013:
        if (((ArrayList) this.nodes[x]).Count > y)
        {
            goto Label_0031;
        }
        return null;
    Label_0031:
        return (AStarNode) ((ArrayList) this.nodes[x])[y];
    }

    public void Init(ArrayList myArray)
    {
        this.nodes = myArray;
        this.numCols = myArray.Count;
        this.numRows = ((ArrayList) myArray[0]).Count;
        return;
    }

    public void Init(int cols, int rows)
    {
        int num;
        ArrayList list;
        int num2;
        AStarNode node;
        this.nodes = new ArrayList();
        this.numCols = cols;
        this.numRows = rows;
        num = 0;
        goto Label_005F;
    Label_0020:
        list = new ArrayList();
        num2 = 0;
        goto Label_0042;
    Label_002D:
        node = new AStarNode(num, num2, 1);
        list.Add(node);
        num2 += 1;
    Label_0042:
        if (num2 < this.numRows)
        {
            goto Label_002D;
        }
        this.nodes.Add(list);
        num += 1;
    Label_005F:
        if (num < this.numCols)
        {
            goto Label_0020;
        }
        return;
    }

    public void SetEndNodePosition(int x, int y)
    {
        this.endNode = this.GetNodeAtPosition(x, y);
        return;
    }

    public void SetStartNodePosition(int x, int y)
    {
        this.startNode = this.GetNodeAtPosition(x, y);
        return;
    }

    public AStarNode EndNode
    {
        get
        {
            return this.endNode;
        }
    }

    public int NumCols
    {
        get
        {
            return this.numCols;
        }
    }

    public int NumRows
    {
        get
        {
            return this.numRows;
        }
    }

    public AStarNode StartNode
    {
        get
        {
            return this.startNode;
        }
    }
}

