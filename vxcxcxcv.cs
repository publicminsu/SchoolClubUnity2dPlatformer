using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class vxcxcxcv : MonoBehaviour
{
    Tilemap sadasd;
    void Start()
    {
        sadasd = GetComponent<Tilemap>();
    }
    public void asdasdad(Vector3 pos)
    {
        Vector3Int pasdasd = sadasd.WorldToCell(pos);
        sadasd.SetTile(pasdasd, null);
    }
}
