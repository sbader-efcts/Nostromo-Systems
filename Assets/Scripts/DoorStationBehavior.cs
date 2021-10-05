using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DoorStationBehavior : MonoBehaviour
{
    public Tilemap CollideableTilemap;
    public Tilemap NormalTilemap;
    public Tile EmptyTile;
    public Tile DoorTile;
    public int DoorTile1X;
    public int DoorTile1Y;
    public int DoorTile2X;
    public int DoorTile2Y;
    public GameObject Drone;
    public GameObject Self;
    public bool DoorIsOpen = false;
    public AudioSource DoorSound;

    private Vector3Int DoorTile1Pos;
    private Vector3Int DoorTile2Pos;

    void Start()
    {
        DoorTile1Pos = CollideableTilemap.WorldToCell(transform.position);
        DoorTile2Pos = CollideableTilemap.WorldToCell(transform.position);
        DoorTile1Pos.x = DoorTile1X;
        DoorTile1Pos.y = DoorTile1Y;
        DoorTile2Pos.x = DoorTile2X;
        DoorTile2Pos.y = DoorTile2Y;
    }

    void Update()
    {
        if (DoorIsOpen == true && (Input.GetKeyUp("e") || Input.GetKeyUp(KeyCode.RightControl)) && Self.GetComponent<Collider2D>().IsTouching(Drone.GetComponent<Collider2D>()))
        {
            NormalTilemap.SetTile(DoorTile1Pos, null);
            NormalTilemap.SetTile(DoorTile2Pos, null);
            CollideableTilemap.SetTile(DoorTile1Pos, DoorTile);
            CollideableTilemap.SetTile(DoorTile2Pos, DoorTile);
            DoorSound.Play();

            DoorIsOpen = false;
        }
        else if (DoorIsOpen == false && (Input.GetKeyUp("e") || Input.GetKeyUp(KeyCode.RightControl)) && Self.GetComponent<Collider2D>().IsTouching(Drone.GetComponent<Collider2D>()))
        {
            NormalTilemap.SetTile(DoorTile1Pos, EmptyTile);
            NormalTilemap.SetTile(DoorTile2Pos, EmptyTile);
            CollideableTilemap.SetTile(DoorTile1Pos, null);
            CollideableTilemap.SetTile(DoorTile2Pos, null);
            DoorSound.Play();

            DoorIsOpen = true;
        }
    }
}
