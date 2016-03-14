using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SkinnedMeshRenderer)), ExecuteInEditMode]
public class SpriteManager : MonoBehaviour
{
    protected EZLinkedList<SpriteMesh_Managed> activeBlocks;
    public int allocBlockSize;
    public bool autoUpdateBounds;
    protected EZLinkedList<SpriteMesh_Managed> availableBlocks;
    protected Matrix4x4[] bindPoses;
    protected Transform[] bones;
    protected BoneWeight[] boneWeights;
    protected float boundUpdateInterval;
    protected Color[] colors;
    protected bool colorsChanged;
    public bool drawBoundingBox;
    protected SpriteDrawLayerComparer drawOrderComparer;
    protected bool initialized;
    protected Mesh mesh;
    protected SkinnedMeshRenderer meshRenderer;
    public bool persistent;
    protected List<SpriteRoot> spriteAddQueue;
    protected List<SpriteMesh_Managed> spriteDrawOrder;
    protected SpriteMesh_Managed[] sprites;
    protected SpriteMesh_Managed tempSprite;
    protected Texture texture;
    protected int[] triIndices;
    protected bool updateBounds;
    protected Vector2[] UVs;
    protected Vector2[] UVs2;
    protected bool uvsChanged;
    protected bool vertCountChanged;
    protected Vector3[] vertices;
    protected bool vertsChanged;
    public SpriteRoot.WINDING_ORDER winding;

    public SpriteManager()
    {
        this.winding = 1;
        this.allocBlockSize = 10;
        this.autoUpdateBounds = 1;
        this.availableBlocks = new EZLinkedList<SpriteMesh_Managed>();
        this.activeBlocks = new EZLinkedList<SpriteMesh_Managed>();
        this.spriteDrawOrder = new List<SpriteMesh_Managed>();
        this.drawOrderComparer = new SpriteDrawLayerComparer();
        base..ctor();
        return;
    }

    public unsafe SpriteMesh_Managed AddSprite(SpriteRoot sprite)
    {
        int num;
        SpriteMesh_Managed managed;
        if ((sprite.manager == this) == null)
        {
            goto Label_0028;
        }
        if (sprite.AddedToManager == null)
        {
            goto Label_0028;
        }
        return (SpriteMesh_Managed) sprite.spriteMesh;
    Label_0028:
        if (this.initialized != null)
        {
            goto Label_0057;
        }
        if (this.spriteAddQueue != null)
        {
            goto Label_0049;
        }
        this.spriteAddQueue = new List<SpriteRoot>();
    Label_0049:
        this.spriteAddQueue.Add(sprite);
        return null;
    Label_0057:
        if (this.availableBlocks.Empty == null)
        {
            goto Label_0074;
        }
        this.EnlargeArrays(this.allocBlockSize);
    Label_0074:
        num = this.availableBlocks.Head.index;
        this.availableBlocks.Remove(this.availableBlocks.Head);
        managed = this.sprites[num];
        sprite.spriteMesh = managed;
        sprite.manager = this;
        sprite.AddedToManager = 1;
        managed.drawLayer = sprite.drawLayer;
        this.bones[num] = sprite.gameObject.transform;
        *(&(this.bindPoses[num])) = this.bones[num].worldToLocalMatrix * sprite.transform.localToWorldMatrix;
        this.activeBlocks.Add(managed);
        managed.Init();
        this.SortDrawingOrder();
        this.vertCountChanged = 1;
        this.vertsChanged = 1;
        this.uvsChanged = 1;
        return managed;
    }

    public SpriteMesh_Managed AddSprite(GameObject go)
    {
        SpriteRoot root;
        root = (SpriteRoot) go.GetComponent(typeof(SpriteRoot));
        if ((root == null) == null)
        {
            goto Label_0024;
        }
        return null;
    Label_0024:
        return this.AddSprite(root);
    }

    public bool AlreadyAdded(SpriteRoot sprite)
    {
        if (this.activeBlocks.Rewind() == null)
        {
            goto Label_003D;
        }
    Label_0010:
        if ((this.activeBlocks.Current.sprite == sprite) == null)
        {
            goto Label_002D;
        }
        return 1;
    Label_002D:
        if (this.activeBlocks.MoveNext() != null)
        {
            goto Label_0010;
        }
    Label_003D:
        return 0;
    }

    private void Awake()
    {
        int num;
        if (this.spriteAddQueue != null)
        {
            goto Label_0016;
        }
        this.spriteAddQueue = new List<SpriteRoot>();
    Label_0016:
        this.meshRenderer = (SkinnedMeshRenderer) base.GetComponent(typeof(SkinnedMeshRenderer));
        if ((this.meshRenderer != null) == null)
        {
            goto Label_0073;
        }
        if ((this.meshRenderer.sharedMaterial != null) == null)
        {
            goto Label_0073;
        }
        this.texture = this.meshRenderer.sharedMaterial.GetTexture("_MainTex");
    Label_0073:
        if ((this.meshRenderer.sharedMesh == null) == null)
        {
            goto Label_0099;
        }
        this.meshRenderer.sharedMesh = new Mesh();
    Label_0099:
        this.mesh = this.meshRenderer.sharedMesh;
        if (this.persistent == null)
        {
            goto Label_00C6;
        }
        UnityEngine.Object.DontDestroyOnLoad(this);
        UnityEngine.Object.DontDestroyOnLoad(this.mesh);
    Label_00C6:
        this.EnlargeArrays(this.allocBlockSize);
        base.transform.rotation = Quaternion.identity;
        this.initialized = 1;
        num = 0;
        goto Label_0108;
    Label_00F1:
        this.AddSprite(this.spriteAddQueue[num]);
        num += 1;
    Label_0108:
        if (num < this.spriteAddQueue.Count)
        {
            goto Label_00F1;
        }
        return;
    }

    public void CancelBoundsUpdate()
    {
        base.CancelInvoke("UpdateBounds");
        return;
    }

    public SpriteRoot CreateSprite(GameObject prefab)
    {
        return this.CreateSprite(prefab, Vector3.zero, Quaternion.identity);
    }

    public SpriteRoot CreateSprite(GameObject prefab, Vector3 position, Quaternion rotation)
    {
        GameObject obj2;
        SpriteRoot root;
        obj2 = (GameObject) UnityEngine.Object.Instantiate(prefab, position, rotation);
        root = (SpriteRoot) obj2.GetComponent(typeof(SpriteRoot));
        this.AddSprite(obj2);
        return root;
    }

    public virtual void DoMirror()
    {
        if (Application.isPlaying == null)
        {
            goto Label_000B;
        }
        return;
    Label_000B:
        if (this.vertCountChanged == null)
        {
            goto Label_00C0;
        }
        this.vertCountChanged = 0;
        this.colorsChanged = 0;
        this.vertsChanged = 0;
        this.uvsChanged = 0;
        this.updateBounds = 0;
        this.meshRenderer.bones = this.bones;
        this.mesh.Clear();
        this.mesh.vertices = this.vertices;
        this.mesh.bindposes = this.bindPoses;
        this.mesh.boneWeights = this.boneWeights;
        this.mesh.uv = this.UVs;
        this.mesh.colors = this.colors;
        this.mesh.triangles = this.triIndices;
        goto Label_014D;
    Label_00C0:
        if (this.vertsChanged == null)
        {
            goto Label_00EA;
        }
        this.vertsChanged = 0;
        this.updateBounds = 1;
        this.mesh.vertices = this.vertices;
    Label_00EA:
        if (this.updateBounds == null)
        {
            goto Label_0107;
        }
        this.mesh.RecalculateBounds();
        this.updateBounds = 0;
    Label_0107:
        if (this.colorsChanged == null)
        {
            goto Label_012A;
        }
        this.colorsChanged = 0;
        this.mesh.colors = this.colors;
    Label_012A:
        if (this.uvsChanged == null)
        {
            goto Label_014D;
        }
        this.uvsChanged = 0;
        this.mesh.uv = this.UVs;
    Label_014D:
        return;
    }

    protected unsafe void DrawCenter()
    {
        float num;
        float num2;
        Bounds bounds;
        Vector3 vector;
        Bounds bounds2;
        Vector3 vector2;
        Bounds bounds3;
        Vector3 vector3;
        Bounds bounds4;
        Bounds bounds5;
        Bounds bounds6;
        Bounds bounds7;
        Bounds bounds8;
        Bounds bounds9;
        num2 = Mathf.Max(Mathf.Max(&&this.meshRenderer.bounds.size.x, &&this.meshRenderer.bounds.size.y), &&this.meshRenderer.bounds.size.z) * 0.015f;
        Gizmos.DrawLine(&this.meshRenderer.bounds.center - (Vector3.up * num2), &this.meshRenderer.bounds.center + (Vector3.up * num2));
        Gizmos.DrawLine(&this.meshRenderer.bounds.center - (Vector3.right * num2), &this.meshRenderer.bounds.center + (Vector3.right * num2));
        Gizmos.DrawLine(&this.meshRenderer.bounds.center - (Vector3.forward * num2), &this.meshRenderer.bounds.center + (Vector3.forward * num2));
        return;
    }

    protected unsafe int EnlargeArrays(int count)
    {
        int num;
        SpriteMesh_Managed[] managedArray;
        Transform[] transformArray;
        Matrix4x4[] matrixxArray;
        Vector3[] vectorArray;
        BoneWeight[] weightArray;
        Vector2[] vectorArray2;
        Color[] colorArray;
        int[] numArray;
        int num2;
        int num3;
        if (this.sprites != null)
        {
            goto Label_001D;
        }
        this.InitArrays();
        num = 0;
        count -= 1;
        goto Label_0026;
    Label_001D:
        num = (int) this.sprites.Length;
    Label_0026:
        managedArray = this.sprites;
        this.sprites = new SpriteMesh_Managed[((int) this.sprites.Length) + count];
        managedArray.CopyTo(this.sprites, 0);
        transformArray = this.bones;
        this.bones = new Transform[((int) this.bones.Length) + count];
        transformArray.CopyTo(this.bones, 0);
        matrixxArray = this.bindPoses;
        this.bindPoses = new Matrix4x4[((int) this.bindPoses.Length) + count];
        matrixxArray.CopyTo(this.bindPoses, 0);
        vectorArray = this.vertices;
        this.vertices = new Vector3[((int) this.vertices.Length) + (count * 4)];
        vectorArray.CopyTo(this.vertices, 0);
        weightArray = this.boneWeights;
        this.boneWeights = new BoneWeight[((int) this.boneWeights.Length) + (count * 4)];
        weightArray.CopyTo(this.boneWeights, 0);
        vectorArray2 = this.UVs;
        this.UVs = new Vector2[((int) this.UVs.Length) + (count * 4)];
        vectorArray2.CopyTo(this.UVs, 0);
        colorArray = this.colors;
        this.colors = new Color[((int) this.colors.Length) + (count * 4)];
        colorArray.CopyTo(this.colors, 0);
        numArray = this.triIndices;
        this.triIndices = new int[((int) this.triIndices.Length) + (count * 6)];
        numArray.CopyTo(this.triIndices, 0);
        num2 = 0;
        goto Label_01B6;
    Label_018A:
        this.sprites[num2].SetBuffers(this.vertices, this.UVs, this.UVs2, this.colors);
        num2 += 1;
    Label_01B6:
        if (num2 < num)
        {
            goto Label_018A;
        }
        num3 = num;
        goto Label_03ED;
    Label_01C6:
        this.sprites[num3] = new SpriteMesh_Managed();
        this.sprites[num3].index = num3;
        this.sprites[num3].manager = this;
        this.sprites[num3].SetBuffers(this.vertices, this.UVs, this.UVs2, this.colors);
        this.sprites[num3].mv1 = num3 * 4;
        this.sprites[num3].mv2 = (num3 * 4) + 1;
        this.sprites[num3].mv3 = (num3 * 4) + 2;
        this.sprites[num3].mv4 = (num3 * 4) + 3;
        this.sprites[num3].uv1 = num3 * 4;
        this.sprites[num3].uv2 = (num3 * 4) + 1;
        this.sprites[num3].uv3 = (num3 * 4) + 2;
        this.sprites[num3].uv4 = (num3 * 4) + 3;
        this.sprites[num3].cv1 = num3 * 4;
        this.sprites[num3].cv2 = (num3 * 4) + 1;
        this.sprites[num3].cv3 = (num3 * 4) + 2;
        this.sprites[num3].cv4 = (num3 * 4) + 3;
        this.availableBlocks.Add(this.sprites[num3]);
        this.triIndices[num3 * 6] = num3 * 4;
        this.triIndices[(num3 * 6) + 1] = (num3 * 4) + 3;
        this.triIndices[(num3 * 6) + 2] = (num3 * 4) + 1;
        this.triIndices[(num3 * 6) + 3] = (num3 * 4) + 3;
        this.triIndices[(num3 * 6) + 4] = (num3 * 4) + 2;
        this.triIndices[(num3 * 6) + 5] = (num3 * 4) + 1;
        this.spriteDrawOrder.Add(this.sprites[num3]);
        this.bones[num3] = base.transform;
        *(&(this.bindPoses[num3])) = this.bones[num3].worldToLocalMatrix * base.transform.localToWorldMatrix;
        this.SetupBoneWeights(this.sprites[num3]);
        num3 += 1;
    Label_03ED:
        if (num3 < ((int) this.sprites.Length))
        {
            goto Label_01C6;
        }
        this.vertsChanged = 1;
        this.uvsChanged = 1;
        this.colorsChanged = 1;
        this.vertCountChanged = 1;
        return num;
    }

    public SpriteMesh_Managed GetSprite(int i)
    {
        if (i >= ((int) this.sprites.Length))
        {
            goto Label_0017;
        }
        return this.sprites[i];
    Label_0017:
        return null;
    }

    protected void InitArrays()
    {
        this.bones = new Transform[] { base.transform };
        this.bindPoses = new Matrix4x4[1];
        this.sprites = new SpriteMesh_Managed[] { new SpriteMesh_Managed() };
        this.vertices = new Vector3[4];
        this.UVs = new Vector2[4];
        this.colors = new Color[4];
        this.triIndices = new int[6];
        this.boneWeights = new BoneWeight[4];
        this.sprites[0].index = 0;
        this.sprites[0].mv1 = 0;
        this.sprites[0].mv2 = 1;
        this.sprites[0].mv3 = 2;
        this.sprites[0].mv4 = 3;
        this.SetupBoneWeights(this.sprites[0]);
        return;
    }

    public virtual void LateUpdate()
    {
        if (this.vertCountChanged == null)
        {
            goto Label_00D6;
        }
        this.vertCountChanged = 0;
        this.colorsChanged = 0;
        this.vertsChanged = 0;
        this.uvsChanged = 0;
        this.updateBounds = 0;
        this.meshRenderer.bones = this.bones;
        this.mesh.Clear();
        this.mesh.vertices = this.vertices;
        this.mesh.bindposes = this.bindPoses;
        this.mesh.boneWeights = this.boneWeights;
        this.mesh.uv = this.UVs;
        this.mesh.colors = this.colors;
        this.mesh.triangles = this.triIndices;
        this.mesh.RecalculateNormals();
        if (this.autoUpdateBounds == null)
        {
            goto Label_016E;
        }
        this.mesh.RecalculateBounds();
        goto Label_016E;
    Label_00D6:
        if (this.vertsChanged == null)
        {
            goto Label_010B;
        }
        this.vertsChanged = 0;
        if (this.autoUpdateBounds == null)
        {
            goto Label_00FA;
        }
        this.updateBounds = 1;
    Label_00FA:
        this.mesh.vertices = this.vertices;
    Label_010B:
        if (this.updateBounds == null)
        {
            goto Label_0128;
        }
        this.mesh.RecalculateBounds();
        this.updateBounds = 0;
    Label_0128:
        if (this.colorsChanged == null)
        {
            goto Label_014B;
        }
        this.colorsChanged = 0;
        this.mesh.colors = this.colors;
    Label_014B:
        if (this.uvsChanged == null)
        {
            goto Label_016E;
        }
        this.uvsChanged = 0;
        this.mesh.uv = this.UVs;
    Label_016E:
        return;
    }

    public void MoveBehind(SpriteMesh_Managed toMove, SpriteMesh_Managed reference)
    {
        int[] numArray;
        int num;
        int num2;
        int num3;
        numArray = new int[6];
        num = this.spriteDrawOrder.IndexOf(toMove) * 6;
        num2 = this.spriteDrawOrder.IndexOf(reference) * 6;
        if (num >= 0)
        {
            goto Label_002D;
        }
        return;
    Label_002D:
        if (num >= num2)
        {
            goto Label_0035;
        }
        return;
    Label_0035:
        toMove.drawLayer = reference.drawLayer - 1;
        numArray[0] = this.triIndices[num];
        numArray[1] = this.triIndices[num + 1];
        numArray[2] = this.triIndices[num + 2];
        numArray[3] = this.triIndices[num + 3];
        numArray[4] = this.triIndices[num + 4];
        numArray[5] = this.triIndices[num + 5];
        num3 = num;
        goto Label_012E;
    Label_0096:
        this.triIndices[num3] = this.triIndices[num3 - 6];
        this.triIndices[num3 + 1] = this.triIndices[num3 - 5];
        this.triIndices[num3 + 2] = this.triIndices[num3 - 4];
        this.triIndices[num3 + 3] = this.triIndices[num3 - 3];
        this.triIndices[num3 + 4] = this.triIndices[num3 - 2];
        this.triIndices[num3 + 5] = this.triIndices[num3 - 1];
        this.spriteDrawOrder[num3 / 6] = this.spriteDrawOrder[(num3 / 6) - 1];
        num3 -= 6;
    Label_012E:
        if (num3 > num2)
        {
            goto Label_0096;
        }
        this.triIndices[num2] = numArray[0];
        this.triIndices[num2 + 1] = numArray[1];
        this.triIndices[num2 + 2] = numArray[2];
        this.triIndices[num2 + 3] = numArray[3];
        this.triIndices[num2 + 4] = numArray[4];
        this.triIndices[num2 + 5] = numArray[5];
        this.spriteDrawOrder[num2 / 6] = toMove;
        this.vertCountChanged = 1;
        return;
    }

    public void MoveInfrontOf(SpriteMesh_Managed toMove, SpriteMesh_Managed reference)
    {
        int[] numArray;
        int num;
        int num2;
        int num3;
        numArray = new int[6];
        num = this.spriteDrawOrder.IndexOf(toMove) * 6;
        num2 = this.spriteDrawOrder.IndexOf(reference) * 6;
        if (num >= 0)
        {
            goto Label_002D;
        }
        return;
    Label_002D:
        if (num <= num2)
        {
            goto Label_0035;
        }
        return;
    Label_0035:
        toMove.drawLayer = reference.drawLayer + 1;
        numArray[0] = this.triIndices[num];
        numArray[1] = this.triIndices[num + 1];
        numArray[2] = this.triIndices[num + 2];
        numArray[3] = this.triIndices[num + 3];
        numArray[4] = this.triIndices[num + 4];
        numArray[5] = this.triIndices[num + 5];
        num3 = num;
        goto Label_0131;
    Label_0096:
        this.triIndices[num3] = this.triIndices[num3 + 6];
        this.triIndices[num3 + 1] = this.triIndices[num3 + 7];
        this.triIndices[num3 + 2] = this.triIndices[num3 + 8];
        this.triIndices[num3 + 3] = this.triIndices[num3 + 9];
        this.triIndices[num3 + 4] = this.triIndices[num3 + 10];
        this.triIndices[num3 + 5] = this.triIndices[num3 + 11];
        this.spriteDrawOrder[num3 / 6] = this.spriteDrawOrder[(num3 / 6) + 1];
        num3 += 6;
    Label_0131:
        if (num3 < num2)
        {
            goto Label_0096;
        }
        this.triIndices[num2] = numArray[0];
        this.triIndices[num2 + 1] = numArray[1];
        this.triIndices[num2 + 2] = numArray[2];
        this.triIndices[num2 + 3] = numArray[3];
        this.triIndices[num2 + 4] = numArray[4];
        this.triIndices[num2 + 5] = numArray[5];
        this.spriteDrawOrder[num2 / 6] = toMove;
        this.vertCountChanged = 1;
        return;
    }

    public void MoveToBack(SpriteMesh_Managed s)
    {
        int[] numArray;
        int num;
        int num2;
        numArray = new int[6];
        num = this.spriteDrawOrder.IndexOf(s) * 6;
        if (num >= 0)
        {
            goto Label_001E;
        }
        return;
    Label_001E:
        s.drawLayer = this.spriteDrawOrder[0].drawLayer - 1;
        numArray[0] = this.triIndices[num];
        numArray[1] = this.triIndices[num + 1];
        numArray[2] = this.triIndices[num + 2];
        numArray[3] = this.triIndices[num + 3];
        numArray[4] = this.triIndices[num + 4];
        numArray[5] = this.triIndices[num + 5];
        num2 = num;
        goto Label_0122;
    Label_008A:
        this.triIndices[num2] = this.triIndices[num2 - 6];
        this.triIndices[num2 + 1] = this.triIndices[num2 - 5];
        this.triIndices[num2 + 2] = this.triIndices[num2 - 4];
        this.triIndices[num2 + 3] = this.triIndices[num2 - 3];
        this.triIndices[num2 + 4] = this.triIndices[num2 - 2];
        this.triIndices[num2 + 5] = this.triIndices[num2 - 1];
        this.spriteDrawOrder[num2 / 6] = this.spriteDrawOrder[(num2 / 6) - 1];
        num2 -= 6;
    Label_0122:
        if (num2 > 5)
        {
            goto Label_008A;
        }
        this.triIndices[0] = numArray[0];
        this.triIndices[1] = numArray[1];
        this.triIndices[2] = numArray[2];
        this.triIndices[3] = numArray[3];
        this.triIndices[4] = numArray[4];
        this.triIndices[5] = numArray[5];
        this.spriteDrawOrder[0] = s;
        this.vertCountChanged = 1;
        return;
    }

    public void MoveToFront(SpriteMesh_Managed s)
    {
        int[] numArray;
        int num;
        int num2;
        numArray = new int[6];
        num = this.spriteDrawOrder.IndexOf(s) * 6;
        if (num >= 0)
        {
            goto Label_001E;
        }
        return;
    Label_001E:
        s.drawLayer = this.spriteDrawOrder[this.spriteDrawOrder.Count - 1].drawLayer + 1;
        numArray[0] = this.triIndices[num];
        numArray[1] = this.triIndices[num + 1];
        numArray[2] = this.triIndices[num + 2];
        numArray[3] = this.triIndices[num + 3];
        numArray[4] = this.triIndices[num + 4];
        numArray[5] = this.triIndices[num + 5];
        num2 = num;
        goto Label_0131;
    Label_0096:
        this.triIndices[num2] = this.triIndices[num2 + 6];
        this.triIndices[num2 + 1] = this.triIndices[num2 + 7];
        this.triIndices[num2 + 2] = this.triIndices[num2 + 8];
        this.triIndices[num2 + 3] = this.triIndices[num2 + 9];
        this.triIndices[num2 + 4] = this.triIndices[num2 + 10];
        this.triIndices[num2 + 5] = this.triIndices[num2 + 11];
        this.spriteDrawOrder[num2 / 6] = this.spriteDrawOrder[(num2 / 6) + 1];
        num2 += 6;
    Label_0131:
        if (num2 < (((int) this.triIndices.Length) - 6))
        {
            goto Label_0096;
        }
        this.triIndices[((int) this.triIndices.Length) - 6] = numArray[0];
        this.triIndices[((int) this.triIndices.Length) - 5] = numArray[1];
        this.triIndices[((int) this.triIndices.Length) - 4] = numArray[2];
        this.triIndices[((int) this.triIndices.Length) - 3] = numArray[3];
        this.triIndices[((int) this.triIndices.Length) - 2] = numArray[4];
        this.triIndices[((int) this.triIndices.Length) - 1] = numArray[5];
        this.spriteDrawOrder[this.spriteDrawOrder.Count - 1] = s;
        this.vertCountChanged = 1;
        return;
    }

    public virtual unsafe void OnDrawGizmos()
    {
        Bounds bounds;
        Bounds bounds2;
        if (this.drawBoundingBox == null)
        {
            goto Label_0046;
        }
        Gizmos.color = Color.yellow;
        this.DrawCenter();
        Gizmos.DrawWireCube(&this.meshRenderer.bounds.center, &this.meshRenderer.bounds.size);
    Label_0046:
        return;
    }

    public unsafe void OnDrawGizmosSelected()
    {
        Bounds bounds;
        Bounds bounds2;
        Gizmos.color = Color.yellow;
        this.DrawCenter();
        Gizmos.DrawWireCube(&this.meshRenderer.bounds.center, &this.meshRenderer.bounds.size);
        return;
    }

    public unsafe Vector2 PixelCoordToUVCoord(Vector2 xy)
    {
        if ((this.texture == null) == null)
        {
            goto Label_0017;
        }
        return Vector2.zero;
    Label_0017:
        return new Vector2(&xy.x / (((float) this.texture.width) - 1f), 1f - (&xy.y / (((float) this.texture.height) - 1f)));
    }

    public Vector2 PixelCoordToUVCoord(int x, int y)
    {
        return this.PixelCoordToUVCoord(new Vector2((float) x, (float) y));
    }

    public unsafe Vector2 PixelSpaceToUVSpace(Vector2 xy)
    {
        if ((this.texture == null) == null)
        {
            goto Label_0017;
        }
        return Vector2.zero;
    Label_0017:
        return new Vector2(&xy.x / ((float) this.texture.width), &xy.y / ((float) this.texture.height));
    }

    public Vector2 PixelSpaceToUVSpace(int x, int y)
    {
        return this.PixelSpaceToUVSpace(new Vector2((float) x, (float) y));
    }

    public unsafe void RemoveSprite(SpriteMesh_Managed sprite)
    {
        *(&(this.vertices[sprite.mv1])) = Vector3.zero;
        *(&(this.vertices[sprite.mv2])) = Vector3.zero;
        *(&(this.vertices[sprite.mv3])) = Vector3.zero;
        *(&(this.vertices[sprite.mv4])) = Vector3.zero;
        this.activeBlocks.Remove(sprite);
        if ((base.gameObject != null) == null)
        {
            goto Label_009C;
        }
        this.bones[sprite.index] = base.transform;
    Label_009C:
        sprite.Clear();
        sprite.sprite.spriteMesh = null;
        sprite.sprite = null;
        this.availableBlocks.Add(sprite);
        this.vertsChanged = 1;
        return;
    }

    public void RemoveSprite(SpriteRoot sprite)
    {
        if ((sprite.spriteMesh as SpriteMesh_Managed) == null)
        {
            goto Label_004B;
        }
        if (sprite.spriteMesh == null)
        {
            goto Label_004B;
        }
        if ((sprite.manager == this) == null)
        {
            goto Label_003A;
        }
        sprite.manager = null;
        sprite.AddedToManager = 0;
    Label_003A:
        this.RemoveSprite((SpriteMesh_Managed) sprite.spriteMesh);
    Label_004B:
        return;
    }

    public void ScheduleBoundsUpdate(float seconds)
    {
        this.boundUpdateInterval = seconds;
        base.InvokeRepeating("UpdateBounds", seconds, seconds);
        return;
    }

    protected unsafe void SetupBoneWeights(SpriteMesh_Managed s)
    {
        &(this.boneWeights[s.mv1]).boneIndex0 = s.index;
        &(this.boneWeights[s.mv1]).weight0 = 1f;
        &(this.boneWeights[s.mv2]).boneIndex0 = s.index;
        &(this.boneWeights[s.mv2]).weight0 = 1f;
        &(this.boneWeights[s.mv3]).boneIndex0 = s.index;
        &(this.boneWeights[s.mv3]).weight0 = 1f;
        &(this.boneWeights[s.mv4]).boneIndex0 = s.index;
        &(this.boneWeights[s.mv4]).weight0 = 1f;
        return;
    }

    public void SortDrawingOrder()
    {
        SpriteMesh_Managed managed;
        int num;
        int num2;
        this.spriteDrawOrder.Sort(this.drawOrderComparer);
        if (this.winding != null)
        {
            goto Label_00B4;
        }
        num = 0;
        goto Label_009E;
    Label_0023:
        managed = this.spriteDrawOrder[num];
        this.triIndices[num * 6] = managed.mv1;
        this.triIndices[(num * 6) + 1] = managed.mv2;
        this.triIndices[(num * 6) + 2] = managed.mv4;
        this.triIndices[(num * 6) + 3] = managed.mv4;
        this.triIndices[(num * 6) + 4] = managed.mv2;
        this.triIndices[(num * 6) + 5] = managed.mv3;
        num += 1;
    Label_009E:
        if (num < this.spriteDrawOrder.Count)
        {
            goto Label_0023;
        }
        goto Label_0147;
    Label_00B4:
        num2 = 0;
        goto Label_0136;
    Label_00BB:
        managed = this.spriteDrawOrder[num2];
        this.triIndices[num2 * 6] = managed.mv1;
        this.triIndices[(num2 * 6) + 1] = managed.mv4;
        this.triIndices[(num2 * 6) + 2] = managed.mv2;
        this.triIndices[(num2 * 6) + 3] = managed.mv4;
        this.triIndices[(num2 * 6) + 4] = managed.mv3;
        this.triIndices[(num2 * 6) + 5] = managed.mv2;
        num2 += 1;
    Label_0136:
        if (num2 < this.spriteDrawOrder.Count)
        {
            goto Label_00BB;
        }
    Label_0147:
        this.vertCountChanged = 1;
        return;
    }

    public void UpdateBounds()
    {
        this.updateBounds = 1;
        return;
    }

    public void UpdateColors()
    {
        this.colorsChanged = 1;
        return;
    }

    public void UpdatePositions()
    {
        this.vertsChanged = 1;
        return;
    }

    public void UpdateUVs()
    {
        this.uvsChanged = 1;
        return;
    }

    public bool IsInitialized
    {
        get
        {
            return this.initialized;
        }
    }
}

