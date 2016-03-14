using System;
using UnityEngine;

public class SpriteMesh_Managed : IEZLinkedListItem<SpriteMesh_Managed>, ISpriteMesh
{
    public int cv1;
    public int cv2;
    public int cv3;
    public int cv4;
    public int drawLayer;
    protected bool hidden;
    public int index;
    public SpriteManager m_manager;
    protected Material m_material;
    public SpriteMesh_Managed m_next;
    public SpriteMesh_Managed m_prev;
    protected SpriteRoot m_sprite;
    protected Texture m_texture;
    protected bool m_useUV2;
    protected Vector2[] m_uvs;
    protected Vector2[] m_uvs2;
    protected Vector3[] m_vertices;
    protected Color[] meshColors;
    protected Vector2[] meshUVs;
    protected Vector2[] meshUVs2;
    protected Vector3[] meshVerts;
    public int mv1;
    public int mv2;
    public int mv3;
    public int mv4;
    public int uv1;
    public int uv2;
    public int uv3;
    public int uv4;

    public SpriteMesh_Managed()
    {
        this.m_vertices = new Vector3[4];
        this.m_uvs = new Vector2[4];
        this.m_uvs2 = new Vector2[4];
        base..ctor();
        return;
    }

    public void Clear()
    {
        this.hidden = 0;
        return;
    }

    public virtual unsafe void Hide(bool tf)
    {
        if (tf == null)
        {
            goto Label_0070;
        }
        *(&(this.m_vertices[0])) = Vector3.zero;
        *(&(this.m_vertices[1])) = Vector3.zero;
        *(&(this.m_vertices[2])) = Vector3.zero;
        *(&(this.m_vertices[3])) = Vector3.zero;
        this.UpdateVerts();
        this.hidden = tf;
        goto Label_00B8;
    Label_0070:
        this.hidden = tf;
        if (this.m_sprite.pixelPerfect == null)
        {
            goto Label_0097;
        }
        this.m_sprite.CalcSize();
        goto Label_00B8;
    Label_0097:
        this.m_sprite.SetSize(this.m_sprite.width, this.m_sprite.height);
    Label_00B8:
        return;
    }

    public virtual void Init()
    {
        if (this.m_sprite.Started != null)
        {
            goto Label_001B;
        }
        this.m_sprite.Start();
    Label_001B:
        if (this.m_sprite.uvsInitialized != null)
        {
            goto Label_0042;
        }
        this.m_sprite.InitUVs();
        this.m_sprite.uvsInitialized = 1;
    Label_0042:
        this.m_sprite.SetBleedCompensation(this.m_sprite.bleedCompensation);
        if (this.m_sprite.pixelPerfect == null)
        {
            goto Label_00D0;
        }
        if ((this.m_texture != null) == null)
        {
            goto Label_008A;
        }
        this.m_sprite.SetPixelToUV(this.m_texture);
    Label_008A:
        if ((this.m_sprite.renderCamera == null) == null)
        {
            goto Label_00B5;
        }
        this.m_sprite.SetCamera(Camera.mainCamera);
        goto Label_00CB;
    Label_00B5:
        this.m_sprite.SetCamera(this.m_sprite.renderCamera);
    Label_00CB:
        goto Label_0101;
    Label_00D0:
        if (this.m_sprite.hideAtStart != null)
        {
            goto Label_0101;
        }
        this.m_sprite.SetSize(this.m_sprite.width, this.m_sprite.height);
    Label_0101:
        this.m_sprite.SetColor(this.m_sprite.color);
        return;
    }

    public virtual bool IsHidden()
    {
        return this.hidden;
    }

    public void SetBuffers(Vector3[] verts, Vector2[] uvs, Vector2[] uvs2, Color[] cols)
    {
        this.meshVerts = verts;
        this.meshUVs = uvs;
        this.meshUVs2 = uvs2;
        this.meshColors = cols;
        return;
    }

    public virtual unsafe void UpdateColors(Color color)
    {
        *(&(this.meshColors[this.cv1])) = color;
        *(&(this.meshColors[this.cv2])) = color;
        *(&(this.meshColors[this.cv3])) = color;
        *(&(this.meshColors[this.cv4])) = color;
        this.m_manager.UpdateColors();
        return;
    }

    public virtual unsafe void UpdateUVs()
    {
        *(&(this.meshUVs[this.uv1])) = *(&(this.uvs[0]));
        *(&(this.meshUVs[this.uv2])) = *(&(this.uvs[1]));
        *(&(this.meshUVs[this.uv3])) = *(&(this.uvs[2]));
        *(&(this.meshUVs[this.uv4])) = *(&(this.uvs[3]));
        if (this.m_useUV2 == null)
        {
            goto Label_0143;
        }
        *(&(this.meshUVs2[this.uv1])) = *(&(this.uvs2[0]));
        *(&(this.meshUVs2[this.uv2])) = *(&(this.uvs2[1]));
        *(&(this.meshUVs2[this.uv3])) = *(&(this.uvs2[2]));
        *(&(this.meshUVs2[this.uv4])) = *(&(this.uvs2[3]));
    Label_0143:
        this.m_manager.UpdateUVs();
        return;
    }

    public virtual unsafe void UpdateVerts()
    {
        if (this.hidden == null)
        {
            goto Label_000C;
        }
        return;
    Label_000C:
        *(&(this.meshVerts[this.mv1])) = *(&(this.m_vertices[0]));
        *(&(this.meshVerts[this.mv2])) = *(&(this.m_vertices[1]));
        *(&(this.meshVerts[this.mv3])) = *(&(this.m_vertices[2]));
        *(&(this.meshVerts[this.mv4])) = *(&(this.m_vertices[3]));
        this.m_manager.UpdatePositions();
        return;
    }

    public SpriteManager manager
    {
        get
        {
            return this.m_manager;
        }
        set
        {
            this.m_manager = value;
            this.m_material = this.m_manager.renderer.sharedMaterial;
            if ((this.m_material != null) == null)
            {
                goto Label_0044;
            }
            this.m_texture = this.m_material.GetTexture("_MainTex");
        Label_0044:
            return;
        }
    }

    public virtual Material material
    {
        get
        {
            return this.m_material;
        }
    }

    public SpriteMesh_Managed next
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

    public SpriteMesh_Managed prev
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

    public virtual SpriteRoot sprite
    {
        get
        {
            return this.m_sprite;
        }
        set
        {
            this.m_sprite = value;
            if ((this.m_sprite != null) == null)
            {
                goto Label_0029;
            }
            this.UpdateColors(this.m_sprite.color);
        Label_0029:
            return;
        }
    }

    public virtual Texture texture
    {
        get
        {
            return this.m_texture;
        }
    }

    public virtual bool UseUV2
    {
        get
        {
            return this.m_useUV2;
        }
        set
        {
            this.m_useUV2 = value;
            return;
        }
    }

    public virtual Vector2[] uvs
    {
        get
        {
            return this.m_uvs;
        }
    }

    public virtual Vector2[] uvs2
    {
        get
        {
            return this.m_uvs2;
        }
    }

    public virtual Vector3[] vertices
    {
        get
        {
            return this.m_vertices;
        }
    }
}

