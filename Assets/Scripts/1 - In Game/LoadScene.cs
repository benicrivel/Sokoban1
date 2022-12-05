using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadScene : MonoBehaviour
{
    //This script create the scene with tilemaps

    public int LevelToOpen;

    //The maps to create the objects
    public Texture2D[] PixelMap;
    public Texture2D[] HeightMap;

    //Elevators, Wires and Activator Floor will create on scene
    public GameObject[] ElevatorsXandY;

    //Prefabs
    public GameObject Floor, ElevatorXFloor, ElevatorYFloor;
    public GameObject Character;
    public GameObject Box;
    public GameObject Target;
    public GameObject EnergyBox;
    public GameObject Toxic;
    public GameObject Flasc1;
    public GameObject Flasc2;
    public GameObject Flasc3;
    public GameObject Flasc4;

    void Awake()
    {
        //LevelToOpen = SaveSystem.LoadValue.LevelToOpen();
        //LevelToOpen = 8;

        GenerateLevel();
    }

    void Start()
    {
        PlayerMovement.Restart();
        UndoSystem.Restart();
        SceneObjects.Restart();
    }

    void GenerateLevel()
    {
        for (int x = 0; x < PixelMap[LevelToOpen].width; x++)
        {
            for (int y = 0; y < PixelMap[LevelToOpen].height; y++)
            {
                GeneratePrefab(x, y);
            }
        }

        if(ElevatorsXandY[LevelToOpen] != null)
        {
            ElevatorsXandY[LevelToOpen].SetActive(true);
        }
    }

    //Generate the prefab according the coordenate color in 2D texture
    void GeneratePrefab(int x, int z)
    {
        Color PixelColor = PixelMap[LevelToOpen].GetPixel(x, z);

        if (PixelColor.a < 0.1f)
        {
            if(FloorHeight(x, z) > 0)
            {
                Instantiate(Floor, new Vector3(x, FloorHeight(x, z), z), transform.rotation);
            }
        }

        if (PixelColor == new Color32(53, 255,0, 255))
        {
            Instantiate(Floor, new Vector3(x, FloorHeight(x, z), z), transform.rotation);
            Instantiate(Character, new Vector3(x, FloorHeight(x, z) + 1.0f, z), transform.rotation);
        }

        if (PixelColor == new Color32(255, 243, 0, 255))
        {
            Instantiate(Floor, new Vector3(x, FloorHeight(x, z), z), transform.rotation);
            Instantiate(Box, new Vector3(x, FloorHeight(x, z) + 1.0f, z), transform.rotation);
        }

        if (PixelColor == Color.red)
        {
            Instantiate(Target, new Vector3(x, FloorHeight(x, z), z), transform.rotation);
        }

        if (PixelColor == new Color32(242, 0, 255, 255))
        {
            Instantiate(Floor, new Vector3(x, FloorHeight(x, z), z), transform.rotation);
            Instantiate(EnergyBox, new Vector3(x, FloorHeight(x, z) + 1.0f, z), transform.rotation);
        }

        if (PixelColor == new Color32(0, 0, 255, 255))
        {
            Instantiate(ElevatorXFloor, new Vector3(x, FloorHeight(x, z), z), transform.rotation);
        }
        if (PixelColor == new Color32(138, 0, 0, 255))
        {
            Instantiate(ElevatorYFloor, new Vector3(x, FloorHeight(x, z), z), transform.rotation);
        }

        if (PixelColor == new Color32(105, 0, 143, 255))
        {
            Instantiate(Floor, new Vector3(x, FloorHeight(x, z), z), transform.rotation);
            Instantiate(Toxic, new Vector3(x, FloorHeight(x, z) + 0.5f, z), transform.rotation);
        }

        if (PixelColor == new Color32(255, 0, 81, 255))
        {
            Instantiate(Floor, new Vector3(x, FloorHeight(x, z), z), transform.rotation);
            Instantiate(Flasc1, new Vector3(x, FloorHeight(x, z) + 1f, z), transform.rotation);
        }

        if (PixelColor == new Color32(188, 0, 255, 255))
        {
            Instantiate(Floor, new Vector3(x, FloorHeight(x, z), z), transform.rotation);
            Instantiate(Flasc2, new Vector3(x, FloorHeight(x, z) + 1f, z), transform.rotation);
        }

        if (PixelColor == new Color32(0, 107, 255, 255))
        {
            Instantiate(Floor, new Vector3(x, FloorHeight(x, z), z), transform.rotation);
            Instantiate(Flasc3, new Vector3(x, FloorHeight(x, z) + 1f, z), transform.rotation);
        }

        if (PixelColor == new Color32(188, 255, 0, 255))
        {
            Instantiate(Floor, new Vector3(x, FloorHeight(x, z), z), transform.rotation);
            Instantiate(Flasc4, new Vector3(x, FloorHeight(x, z) + 1f, z), transform.rotation);
        }

        

    }

    public float FloorHeight(int x, int z)
    {
        Color PixelColor = HeightMap[LevelToOpen].GetPixel(x, z);
        float h = -1.0f;

        if (PixelColor == Color.white)
        {
            h = 0.5f;
        }

        if (PixelColor == new Color32(125, 125, 125, 255))
        {
            h = 1.5f;
        }

        if (PixelColor == Color.black)
        {
            h = 2.5f;
        }

        return h;
    }
}
