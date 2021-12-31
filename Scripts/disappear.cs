using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class disappear : MonoBehaviour
{
    public Tilemap tile;
    public Vector3Int vec3int;


    void Start(){
        tile = GetComponent<Tilemap>();


    }

    void OnCollisionStay2D(Collision2D other) {
        if (other.gameObject.tag == "phoenix" ) {
    //         // Destroy(gameObject);
    //         // other.contacts[0].point;
            foreach (ContactPoint2D contact in other.contacts){
                Vector3Int pos = tile.WorldToCell(new Vector3Int((int)contact.point.x, (int)contact.point.y, 0));
                tile.SetTile(pos, null);
            }
            //int x, y;
            //foreach (ContactPoint2D contact in other.contacts)
            //{
            //    x = tile.WorldToCell(other.contacts[0].point).x;
            //    y = tile.WorldToCell(other.contacts[0].point).y;
            //    vec3int = new Vector3Int(x, y, 0);
            //    tile.SetTile(vec3int, null);
            //}
        }       
    }

    // void OnTriggerStay2D(Collider2D other) {
    //     if (other.gameObject.tag == "phoenix") {

    //         int x, y;
    //         x = tile.WorldToCell(other.bounds.ClosestPoint(transform.position)).x;
    //         y = tile.WorldToCell(other.bounds.ClosestPoint(transform.position)).y;
    //         vec3int = new Vector3Int(x, y, 0);
    //         Debug.Log(other.bounds.ClosestPoint(transform.position));
    //         Debug.Log(other.contacts);
    //         tile.SetTile(vec3int, null);
    //     }
    // }    
}
