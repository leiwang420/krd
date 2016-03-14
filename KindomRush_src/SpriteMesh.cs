using System;
using UnityEngine;

public class SpriteMesh : ISpriteMesh
{
    protected Color[] m_colors;
    protected int[] m_faces;
    protected Mesh m_mesh;
    protected SpriteRoot m_sprite;
    protected Texture m_texture;
    protected bool m_useUV2;
    protected Vector2[] m_uvs;
    protected Vector2[] m_uvs2;
    protected Vector3[] m_vertices;
    protected MeshFilter meshFilter;
    protected MeshRenderer meshRenderer;

    public SpriteMesh()
    {
        this.m_vertices = new Vector3[4];
        this.m_colors = new Color[4];
        this.m_uvs = new Vector2[4];
        this.m_uvs2 = new Vector2[4];
        this.m_faces = new int[6];
        base..ctor();
        return;
    }

    protected void CreateMesh()
    {
        this.meshFilter.sharedMesh = new Mesh();
        this.m_mesh = this.meshFilter.sharedMesh;
        if (this.m_sprite.persistent == null)
        {
            goto Label_003C;
        }
        UnityEngine.Object.DontDestroyOnLoad(this.m_mesh);
    Label_003C:
        return;
    }

    public virtual void Hide(bool tf)
    {
        if ((this.meshRenderer == null) == null)
        {
            goto Label_0012;
        }
        return;
    Label_0012:
        this.meshRenderer.enabled = tf == 0;
        return;
    }

    public virtual void Init()
    {
        if ((this.m_mesh == null) == null)
        {
            goto Label_0017;
        }
        this.CreateMesh();
    Label_0017:
        this.m_mesh.Clear();
        this.m_mesh.vertices = this.m_vertices;
        this.m_mesh.uv = this.m_uvs;
        this.m_mesh.colors = this.m_colors;
        this.m_mesh.triangles = this.m_faces;
        this.SetWindingOrder(this.m_sprite.winding);
        if (this.m_sprite.uvsInitialized != null)
        {
            goto Label_009E;
        }
        this.m_sprite.InitUVs();
        this.m_sprite.uvsInitialized = 1;
    Label_009E:
        this.m_sprite.SetBleedCompensation(this.m_sprite.bleedCompensation);
        if (this.m_sprite.pixelPerfect == null)
        {
            goto Label_016E;
        }
        if ((this.m_texture == null) == null)
        {
            goto Label_0106;
        }
        if ((this.meshRenderer.sharedMaterial != null) == null)
        {
            goto Label_0106;
        }
        this.m_texture = this.meshRenderer.sharedMaterial.GetTexture("_MainTex");
    Label_0106:
        if ((this.m_texture != null) == null)
        {
            goto Label_0128;
        }
        this.m_sprite.SetPixelToUV(this.m_texture);
    Label_0128:
        if ((this.m_sprite.renderCamera == null) == null)
        {
            goto Label_0153;
        }
        this.m_sprite.SetCamera(Camera.mainCamera);
        goto Label_0169;
    Label_0153:
        this.m_sprite.SetCamera(this.m_sprite.renderCamera);
    Label_0169:
        goto Label_019F;
    Label_016E:
        if (this.m_sprite.hideAtStart != null)
        {
            goto Label_019F;
        }
        this.m_sprite.SetSize(this.m_sprite.width, this.m_sprite.height);
    Label_019F:
        this.m_mesh.RecalculateNormals();
        this.m_sprite.SetColor(this.m_sprite.color);
        return;
    }

    public virtual bool IsHidden()
    {
        if ((this.meshRenderer == null) == null)
        {
            goto Label_0013;
        }
        return 1;
    Label_0013:
        return (this.meshRenderer.enabled == 0);
    }

    public void SetPersistent()
    {
        if ((this.m_mesh != null) == null)
        {
            goto Label_001C;
        }
        UnityEngine.Object.DontDestroyOnLoad(this.m_mesh);
    Label_001C:
        return;
    }

    public virtual void SetWindingOrder(SpriteRoot.WINDING_ORDER winding)
    {
        this.m_faces[0] = 0;
        this.m_faces[1] = 3;
        this.m_faces[2] = 1;
        this.m_faces[3] = 3;
        this.m_faces[4] = 2;
        this.m_faces[5] = 1;
        if ((this.m_mesh != null) == null)
        {
            goto Label_0058;
        }
        this.m_mesh.triangles = this.m_faces;
    Label_0058:
        return;
    }

    public virtual unsafe void UpdateColors(Color color)
    {
        *(&(this.m_colors[0])) = color;
        *(&(this.m_colors[1])) = color;
        *(&(this.m_colors[2])) = color;
        *(&(this.m_colors[3])) = color;
        if ((this.m_mesh != null) == null)
        {
            goto Label_006A;
        }
        this.m_mesh.colors = this.m_colors;
    Label_006A:
        return;
    }

    public virtual void UpdateUVs()
    {
        if ((this.m_mesh != null) == null)
        {
            goto Label_003E;
        }
        this.m_mesh.uv = this.m_uvs;
        if (this.m_useUV2 == null)
        {
            goto Label_003E;
        }
        this.m_mesh.uv2 = this.m_uvs2;
    Label_003E:
        return;
    }

    public virtual void UpdateVerts()
    {
        if ((this.m_mesh == null) == null)
        {
            goto Label_0017;
        }
        this.CreateMesh();
    Label_0017:
        this.m_mesh.vertices = this.m_vertices;
        this.m_mesh.RecalculateBounds();
        return;
    }

    public virtual Material material
    {
        get
        {
            return this.meshRenderer.sharedMaterial;
        }
        set
        {
            this.meshRenderer.sharedMaterial = value;
            this.m_texture = this.meshRenderer.sharedMaterial.mainTexture;
            if ((this.m_sprite != null) == null)
            {
                goto Label_0055;
            }
            if ((this.m_texture != null) == null)
            {
                goto Label_0055;
            }
            this.m_sprite.SetPixelToUV(this.m_texture);
        Label_0055:
            return;
        }
    }

    public virtual Mesh mesh
    {
        get
        {
            if ((this.m_mesh == null) == null)
            {
                goto Label_0017;
            }
            this.CreateMesh();
        Label_0017:
            return this.m_mesh;
        }
        set
        {
            this.m_mesh = value;
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
                goto Label_003A;
            }
            if (this.m_sprite.spriteMesh == this)
            {
                goto Label_003B;
            }
            this.m_sprite.spriteMesh = this;
            goto Label_003B;
        Label_003A:
            return;
        Label_003B:
            this.meshFilter = (MeshFilter) this.m_sprite.gameObject.GetComponent(typeof(MeshFilter));
            if ((this.meshFilter == null) == null)
            {
                goto Label_0096;
            }
            this.meshFilter = (MeshFilter) this.m_sprite.gameObject.AddComponent(typeof(MeshFilter));
        Label_0096:
            this.meshRenderer = (MeshRenderer) this.m_sprite.gameObject.GetComponent(typeof(MeshRenderer));
            if ((this.meshRenderer == null) == null)
            {
                goto Label_00F1;
            }
            this.meshRenderer = (MeshRenderer) this.m_sprite.gameObject.AddComponent(typeof(MeshRenderer));
        Label_00F1:
            this.m_mesh = this.meshFilter.sharedMesh;
            if ((this.meshRenderer.sharedMaterial != null) == null)
            {
                goto Label_0133;
            }
            this.m_texture = this.meshRenderer.sharedMaterial.GetTexture("_MainTex");
        Label_0133:
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

