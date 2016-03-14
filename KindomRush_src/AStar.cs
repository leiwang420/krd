using System;
using System.Collections;
using UnityEngine;

public class AStar
{
    private ArrayList closed;
    private double diagonalCost;
    private AStarGrid grid;
    private Constants.heuristic heuristicType;
    private ArrayList open;
    private ArrayList path;
    private double straightCost;

    public AStar()
    {
        base..ctor();
        return;
    }

    private ArrayList BuildPath()
    {
        AStarNode node;
        this.path.Clear();
        node = this.grid.EndNode;
        goto Label_0030;
    Label_001C:
        this.path.Add(node);
        node = node.ParentNode;
    Label_0030:
        if (node.Equals(this.grid.StartNode) == null)
        {
            goto Label_001C;
        }
        return this.path;
    }

    private unsafe double Diagonal(AStarNode node)
    {
        double num;
        double num2;
        double num3;
        double num4;
        Vector2 vector;
        Vector2 vector2;
        Vector2 vector3;
        Vector2 vector4;
        num = (double) Math.Abs(&node.Position.x - &this.grid.EndNode.Position.x);
        num2 = (double) Math.Abs(&node.Position.y - &this.grid.EndNode.Position.y);
        num3 = Math.Min(num, num2);
        num4 = num + num2;
        return ((this.diagonalCost * num3) + (this.straightCost * (num4 - (2.0 * num3))));
    }

    private unsafe double Euclidian(AStarNode node)
    {
        double num;
        double num2;
        Vector2 vector;
        Vector2 vector2;
        Vector2 vector3;
        Vector2 vector4;
        num = (double) (&node.Position.x - &this.grid.EndNode.Position.x);
        num2 = (double) (&node.Position.y - &this.grid.EndNode.Position.y);
        return Math.Sqrt((num * num) + (num2 * num2));
    }

    public bool FindPath()
    {
        if (this.grid.StartNode == null)
        {
            goto Label_0020;
        }
        if (this.grid.EndNode != null)
        {
            goto Label_0022;
        }
    Label_0020:
        return 0;
    Label_0022:
        if (this.grid.StartNode.Walkable == null)
        {
            goto Label_004C;
        }
        if (this.grid.EndNode.Walkable != null)
        {
            goto Label_004E;
        }
    Label_004C:
        return 0;
    Label_004E:
        this.open.Clear();
        this.closed.Clear();
        this.path.Clear();
        this.grid.StartNode.G = 0.0;
        this.grid.StartNode.H = this.GetHeruistic(this.grid.StartNode);
        this.grid.StartNode.F = this.grid.StartNode.G + this.grid.StartNode.H;
        return this.Search();
    }

    private double GetHeruistic(AStarNode node)
    {
        Constants.heuristic heuristic;
        switch (this.heuristicType)
        {
            case 0:
                goto Label_001E;

            case 1:
                goto Label_0026;

            case 2:
                goto Label_002E;
        }
        goto Label_0036;
    Label_001E:
        return this.Diagonal(node);
    Label_0026:
        return this.Manhattan(node);
    Label_002E:
        return this.Euclidian(node);
    Label_0036:
        return this.Diagonal(node);
    }

    public ArrayList GetPath()
    {
        return this.path;
    }

    public void InitWithGrid(AStarGrid g)
    {
        this.grid = g;
        this.diagonalCost = 1.4140000343322754;
        this.straightCost = 1.0;
        this.heuristicType = 1;
        this.open = new ArrayList();
        this.closed = new ArrayList();
        this.path = new ArrayList();
        return;
    }

    private bool IsClosed(AStarNode node)
    {
        AStarNode node2;
        IEnumerator enumerator;
        bool flag;
        IDisposable disposable;
        enumerator = this.closed.GetEnumerator();
    Label_000C:
        try
        {
            goto Label_0030;
        Label_0011:
            node2 = (AStarNode) enumerator.Current;
            if (node2.Equals(node) == null)
            {
                goto Label_0030;
            }
            flag = 1;
            goto Label_0054;
        Label_0030:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0011;
            }
            goto Label_0052;
        }
        finally
        {
        Label_0040:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_004B;
            }
        Label_004B:
            disposable.Dispose();
        }
    Label_0052:
        return 0;
    Label_0054:
        return flag;
    }

    private bool IsOpen(AStarNode node)
    {
        AStarNode node2;
        IEnumerator enumerator;
        bool flag;
        IDisposable disposable;
        enumerator = this.open.GetEnumerator();
    Label_000C:
        try
        {
            goto Label_0030;
        Label_0011:
            node2 = (AStarNode) enumerator.Current;
            if (node2.Equals(node) == null)
            {
                goto Label_0030;
            }
            flag = 1;
            goto Label_0054;
        Label_0030:
            if (enumerator.MoveNext() != null)
            {
                goto Label_0011;
            }
            goto Label_0052;
        }
        finally
        {
        Label_0040:
            disposable = enumerator as IDisposable;
            if (disposable != null)
            {
                goto Label_004B;
            }
        Label_004B:
            disposable.Dispose();
        }
    Label_0052:
        return 0;
    Label_0054:
        return flag;
    }

    private unsafe double Manhattan(AStarNode node)
    {
        Vector2 vector;
        Vector2 vector2;
        Vector2 vector3;
        Vector2 vector4;
        return ((((double) Math.Abs(&node.Position.x - &this.grid.EndNode.Position.x)) * this.straightCost) + (((double) Math.Abs(&node.Position.y - &this.grid.EndNode.Position.y)) * this.straightCost));
    }

    private unsafe bool Search()
    {
        AStarNode node;
        int num;
        int num2;
        int num3;
        int num4;
        int num5;
        int num6;
        AStarNode node2;
        double num7;
        double num8;
        double num9;
        double num10;
        Vector2 vector;
        Vector2 vector2;
        Vector2 vector3;
        Vector2 vector4;
        Vector2 vector5;
        Vector2 vector6;
        Vector2 vector7;
        Vector2 vector8;
        node = this.grid.StartNode;
        goto Label_0253;
    Label_0011:
        num = (int) Math.Max(0f, &node.Position.x - 1f);
        num2 = (int) Math.Min((float) (this.grid.NumCols - 1), &node.Position.x + 1f);
        num3 = (int) Math.Max(0f, &node.Position.y - 1f);
        num4 = (int) Math.Min((float) (this.grid.NumRows - 1), &node.Position.y + 1f);
        num5 = num;
        goto Label_01FE;
    Label_00B0:
        num6 = num3;
        goto Label_01EF;
    Label_00B8:
        node2 = this.grid.GetNodeAtPosition(num5, num6);
        if (node2.Equals(node) == null)
        {
            goto Label_00DB;
        }
        goto Label_01E9;
    Label_00DB:
        if (node2.Walkable != null)
        {
            goto Label_00EC;
        }
        goto Label_01E9;
    Label_00EC:
        num7 = this.straightCost;
        if (&node.Position.x == &node2.Position.x)
        {
            goto Label_0144;
        }
        if (&node.Position.y == &node2.Position.y)
        {
            goto Label_0144;
        }
        num7 = this.diagonalCost;
    Label_0144:
        num8 = node.G + (num7 * node2.Cost);
        num9 = this.GetHeruistic(node2);
        num10 = num8 + num9;
        if (this.IsOpen(node2) != null)
        {
            goto Label_0182;
        }
        if (this.IsClosed(node2) == null)
        {
            goto Label_01B8;
        }
    Label_0182:
        if (node2.F <= num10)
        {
            goto Label_01E9;
        }
        node2.F = num10;
        node2.G = num8;
        node2.H = num9;
        node2.ParentNode = node;
        goto Label_01E9;
    Label_01B8:
        node2.F = num10;
        node2.G = num8;
        node2.H = num9;
        node2.ParentNode = node;
        this.open.Add(node2);
    Label_01E9:
        num6 += 1;
    Label_01EF:
        if (num6 <= num4)
        {
            goto Label_00B8;
        }
        num5 += 1;
    Label_01FE:
        if (num5 <= num2)
        {
            goto Label_00B0;
        }
        this.closed.Add(node);
        if (this.open.Count != null)
        {
            goto Label_0225;
        }
        return 0;
    Label_0225:
        this.open.Sort(new AStarComparer());
        node = (AStarNode) this.open[0];
        this.open.RemoveAt(0);
    Label_0253:
        if (node.Equals(this.grid.EndNode) == null)
        {
            goto Label_0011;
        }
        this.BuildPath();
        return 1;
    }

    public AStarGrid Grid
    {
        get
        {
            return this.grid;
        }
    }

    public class AStarComparer : IComparer
    {
        public AStarComparer()
        {
            base..ctor();
            return;
        }

        int IComparer.Compare(object x, object y)
        {
            if (((AStarNode) x).F <= ((AStarNode) y).F)
            {
                goto Label_001D;
            }
            return 1;
        Label_001D:
            if (((AStarNode) x).F >= ((AStarNode) y).F)
            {
                goto Label_003A;
            }
            return -1;
        Label_003A:
            return 0;
        }
    }
}

