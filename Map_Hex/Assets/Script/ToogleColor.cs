using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class ToogleColor : MonoBehaviour
{
    //RuleTileEditor 

    Vector3 vVec3;
    Vector3Int vVec3Int;
    public Tilemap tTilemap;
    public Grid gGrid;

    public Camera cam;
    public TileBase tTile;

    public Vector3 cameraRelative;

    public Text tText;
    public Text tGetSetTile;

    public TileBase tTileBase;
    public TileBase tTileBase2;

    public GridPalette gGridPalette;

    public Tilemap[] tTilemapMass;
    public TileChangeData tTCD;

    public ITilemap iITilemap;

    GameObject gGobj;
    public GameObject gGobj2;
    public float fSpeed = 1.5f;

    //public Vector3Int vConvertVec3ToVec3Int;


    public Sprite sSprite;

    bool tTCDChanged = false;

    public Vector3Int vConvertVec3ToVec3Int(Grid gGrid, Vector3 vVec3)
    {
        Vector3Int vVec3Int;

        vVec3Int = gGrid.WorldToCell(vVec3);

        return vVec3Int;
    }

    void Start()
    {
        tTilemapMass = new Tilemap[10];
        for (int i = 0; i < 10; i++) { 
            tTilemapMass[i] = new();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            gGobj2.transform.Translate(0, fSpeed * Time.deltaTime, 0);
        } else if (Input.GetKey(KeyCode.S))
        {
            gGobj2.transform.Translate(0, -fSpeed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            gGobj2.transform.Translate(-fSpeed * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            gGobj2.transform.Translate(fSpeed * Time.deltaTime, 0, 0);
        }

        Debug.Log("Тест обновления файла на гит, я отредактировал текст, первая попытка");


        tTilemap.SetTile(vConvertVec3ToVec3Int(gGrid, gGobj2.transform.position), tTile);
        Debug.Log($"Координаты гекс: {vConvertVec3ToVec3Int(gGrid, gGobj2.transform.position)}");

        //gGobj2.transform.


        vVec3 = cam.ScreenToWorldPoint(Input.mousePosition);
        vVec3.z = 0.0f;
        vVec3Int = gGrid.WorldToCell(vVec3);
        //Debug.Log(tTilemap.GetInstantiatedObject(vVec3Int));
        Debug.DrawRay(cam.transform.position, vVec3, Color.red);
        Debug.Log(tTile);
        
        if (Input.GetMouseButtonDown(0))
        {
            //gGobj = tTilemap.GetObjectToInstantiate(vVec3Int);
           // Debug.Log(gGobj);
           
            iITilemap.GetTile(vVec3Int);

            try
            {
                if (tTile) 
                {
                    tTilemap.SetTile(vVec3Int, tTile);
                    tGetSetTile.text = $"Заполнена последняя ячейка({vVec3Int}) Tile: {tTile.name}";
                }
                else { tGetSetTile.text = $"Не выбран Tile, установка в ячейку {vVec3Int} невозможна"; }           
            }
            catch (NullReferenceException ex)
            {
                Debug.Log("NullReferenceException GetMouseButtonDown(0)");
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            try
            {
                TileBase tTmp = tTilemap.GetTile(vVec3Int);

                if (tTmp)
                {
                    //tTileBase = tTilemap.GetTile(vVec3Int);

                    //iITilemap.cellBounds;

                    tTile = tTmp;
                    //tTile = tTilemap.GetTile(vVec3Int);


                    tGetSetTile.text = $"Выбрана модель({tTile.name}) Из координаты {vVec3Int}";
                }
                else {
                    tGetSetTile.text = $"В ячейке {vVec3Int}, Tile отсутствует";
                }
            }
            catch (NullReferenceException ex)
            {
                Debug.Log("NullReferenceException GetMouseButtonDown(1)");
            }

            //tTCD.tile = tTileBase2;
        }
        if (Input.GetMouseButtonDown(2))
        {
            //tTilemap.SetTile(gGrid.WorldToCell(vVec3), tTile);
            
            //tTCD.tile = tTileBase2;
            //Debug.Log("Модель изменена: " + tTileBase2.name);
        }
        //знаю координаты ячейки, по координатам изменить ячейку на другую
        //выходит что нужна переменная которая будет хранить все ячейки с названиями тайлов и по названием мы будем понимать что это ха клетки и что на ней стоит

        tText.text = "tTCD.position: " + tTCD.position + "\r\n" +
                    "tTCDtTCD.tile: " + tTCD.tile + "\r\n" +
                    "tTCD.color: " + tTCD.color + "\r\n" +
                    "tTCD.transform: " + tTCD.transform + "\r\n" +
                    "orthographicSize: " + cam.orthographicSize + "\r\n" +
                    "pixelHeight: " + cam.pixelHeight + "\r\n" +
                    "pixelWidth: " + cam.pixelWidth + "\r\n" +
                    "pixelRect: " + cam.pixelRect + "\r\n" +
                    "scaledPixelHeight: " + cam.scaledPixelHeight + "\r\n" +
                    "scaledPixelWidth: " + cam.scaledPixelWidth + "\r\n" +
                    "mousePositionX: " + Input.mousePosition.x + "\r\n" +
                    "mousePositionY: " + Input.mousePosition.y + "\r\n" +                    
                    "tTilemap.GetTile(vVec3): " + tTilemap.GetTile(vVec3Int) + "\r\n" +
                    "tTile = (Tile)tTileMap...: " + tTile + "\r\n" +
                    
                    "Координаты мышки/ячейки gGrid.WorldToCell(vVec3): " + vVec3Int + "\r\n" +

                    "gGrid.GetBoundsLocal(): " + gGrid.GetBoundsLocal(vVec3Int) + "\r\n" +
                    "gGrid.GetLayoutCellCenter(): " + gGrid.GetLayoutCellCenter() + "\r\n" +
                    "gGrid.cellLayout: " + gGrid.cellLayout + "\r\n" +
                    "gGrid.ToString(): " + gGrid.ToString() + "\r\n" +
                    "gGrid.GetCellCenterLocal(): " + gGrid.GetCellCenterWorld(vVec3Int) + "\r\n" +

                    "gGridPalette.cellSizing: " + gGridPalette.cellSizing + "\r\n" +
                    "gGridPalette.GetInstanceID: " + gGridPalette.GetInstanceID() + "\r\n" +

                    "vVec3: " + vVec3;
    }
}