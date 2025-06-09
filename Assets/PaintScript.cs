using System;
using System.Collections.Generic;
using UnityEngine;

public class PaintScript : MonoBehaviour
{
    private static readonly int CenterUV = Shader.PropertyToID("_UV");
    public RenderTexture srcRt;
    
    public Camera cam;

    public LayerMask paintLayer;

    public float minBrushDistance;

    private Vector2? _lastHit = null;
    
    public MeshRenderer targetRenderer;

    public Material brushMatSrc;
    public Material clearMat;

    public RenderTexture rt1;
    public RenderTexture rt2;
    public Material brushMat;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rt1 = new RenderTexture(1024, 1024, 0, RenderTextureFormat.ARGB32);
        rt1.Create();
        
        rt2 = new RenderTexture(1024, 1024, 0, RenderTextureFormat.ARGB32);
        rt2.Create();

        
        targetRenderer.material.SetTexture("_BaseMap", rt1);
        
        brushMat = new Material(brushMatSrc);
        brushMat.name += "(Clone)";
        
        Graphics.Blit(null, rt1, clearMat);
    }
    
    void OnDestroy()
    {
        if (rt1)
        {
            rt1.Release();
            Destroy(rt1);
        }
        if (rt2)
        {
            rt2.Release();
            Destroy(rt2);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!Input.GetMouseButton(0))
        {
            _lastHit = null;
            return;
        }
        
        var ray = cam.ScreenPointToRay(Input.mousePosition);

        if (!Physics.Raycast(ray, out var hit, Mathf.Infinity, paintLayer.value))
        {
            _lastHit = null;
            return;
        }
        
        var uv = hit.textureCoord;

        PointUtils.GetLerpedPoints(_lastHit ?? uv, uv, minBrushDistance, DrawPoint);
        _lastHit = uv;
        
        targetRenderer.material.SetTexture("_BaseMap", rt2);
    }

    private void DrawPoint(Vector2 point)
    {
        brushMat.SetTexture("_MainTex", rt1);
        brushMat.SetVector(CenterUV, point);
        Graphics.Blit(null, rt2, brushMat);
        (rt2, rt1) = (rt1, rt2);
    }
}

static class PointUtils
{
    public static void GetLerpedPoints(Vector2 start, Vector2 end, float minDistance, Action<Vector2> callback)
    {
        float totalDistance = Vector2.Distance(start, end);
        if (totalDistance < minDistance || minDistance <= 0)
        {
            callback(end);
            return;
        }

        int steps = Mathf.FloorToInt(totalDistance / minDistance);

        for (int i = 1; i <= steps; i++) // Start from i = 1 to exclude 'start'
        {
            float t = (float)i / steps;
            callback(Vector2.Lerp(start, end, t));
        }
    }
}