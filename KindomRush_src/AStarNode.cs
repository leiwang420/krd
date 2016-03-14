using System;
using System.Runtime.InteropServices;
using UnityEngine;

public class AStarNode
{
    private double cost;
    private double f;
    private double g;
    private double h;
    private AStarNode parentNode;
    private Vector2 position;
    private bool walkable;

    public AStarNode(int x, int y, bool isWalkable = true)
    {
        base..ctor();
        this.position = new Vector2((float) x, (float) y);
        this.walkable = isWalkable;
        this.cost = 1.0;
        return;
    }

    public unsafe Vector2 GetNodeRealPosition()
    {
        return new Vector2(-960f + (10f + (20f * &this.position.x)), 540f - (10f + (20f * &this.position.y)));
    }

    public double Cost
    {
        get
        {
            return this.cost;
        }
    }

    public double F
    {
        get
        {
            return this.f;
        }
        set
        {
            this.f = value;
            return;
        }
    }

    public double G
    {
        get
        {
            return this.g;
        }
        set
        {
            this.g = value;
            return;
        }
    }

    public double H
    {
        get
        {
            return this.h;
        }
        set
        {
            this.h = value;
            return;
        }
    }

    public AStarNode ParentNode
    {
        get
        {
            return this.parentNode;
        }
        set
        {
            this.parentNode = value;
            return;
        }
    }

    public Vector2 Position
    {
        get
        {
            return this.position;
        }
    }

    public bool Walkable
    {
        get
        {
            return this.walkable;
        }
    }
}

