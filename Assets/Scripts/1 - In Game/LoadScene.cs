using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadScene : MonoBehaviour
{
    //This script create the scene with tilemaps

    public int LevelToOpen;

    //The maps to create the objects
    public Texture2D[] PixelMap;
    public Texture2D[] PixelMap2;
    public Texture2D[] PixelMap3;
    public Texture2D[] HeightMap;

    //Elevators, Wires and Activator Floor will create on scene
    public GameObject[] ElevatorsXandY;

    //Prefabs
    public GameObject Floor, ElevatorXFloor, ElevatorYFloor;
    public GameObject Character;
    public GameObject Box;
    public GameObject Target;
    public GameObject EnergyBox;
    public GameObject WireHor;
    public GameObject WireVer;
    public GameObject WireL_DR;
    public GameObject WireL_DL;
    public GameObject WireL_UR;
    public GameObject WireL_UL;
    public GameObject WireT_LUD;
    public GameObject WireT_RUD;
    public GameObject LaserG_Up;
    public GameObject LaserG_Right;
    public GameObject LaserG_Down; 
    public GameObject LaserG_Left;
    public GameObject LaserReflector;
    public GameObject LaserReceptor;
    public GameObject Toxic;
    public GameObject Flask1;
    public GameObject Flask2;
    public GameObject Flask3;
    public GameObject Flask4;

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
        Debug.Log("Start");
    }

    void GenerateLevel()
    {
        Debug.Log("GenerateLevel");
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
        Debug.Log("GeneratePrefab");
        Color PixelColor = PixelMap[LevelToOpen].GetPixel(x, z);

        //Floor
        if (PixelColor.a < 0.1f)
        {
            if (FloorHeight(x, z) > 0)
            {
                Instantiate(Floor, new Vector3(x, FloorHeight(x, z), z), transform.rotation);
            }
        }

        //Character
        if (PixelColor == new Color32(53, 255, 0, 255))
        {
            Instantiate(Floor, new Vector3(x, FloorHeight(x, z), z), transform.rotation);
            Instantiate(Character, new Vector3(x, FloorHeight(x, z) + 1.0f, z), transform.rotation);
        }

        //Box
        if (PixelColor == new Color32(255, 243, 0, 255))
        {
            Instantiate(Floor, new Vector3(x, FloorHeight(x, z), z), transform.rotation);
            Instantiate(Box, new Vector3(x, FloorHeight(x, z) + 1.0f, z), transform.rotation);
        }

        if (PixelColor == new Color32(242, 0, 255, 255))
        {
            Instantiate(Floor, new Vector3(x, FloorHeight(x, z), z), transform.rotation);
            Instantiate(EnergyBox, new Vector3(x, FloorHeight(x, z) + 1.0f, z), transform.rotation);
        }

        //Target
        if (PixelColor == Color.red)
        {
            Instantiate(Target, new Vector3(x, FloorHeight(x, z), z), transform.rotation);
        }

        //Elevadores
        if (PixelColor == new Color32(0, 0, 255, 255))
        {
            Instantiate(ElevatorXFloor, new Vector3(x, FloorHeight(x, z), z), transform.rotation);
        }

        if (PixelColor == new Color32(138, 0, 0, 255))
        {
            Instantiate(ElevatorYFloor, new Vector3(x, FloorHeight(x, z), z), transform.rotation);
        }


        //Wire
        if (PixelColor == new Color32(255, 248, 125, 255))
        {
            Instantiate(WireHor, new Vector3(x, FloorHeight(x, z), z), transform.rotation);
        }

        if (PixelColor == new Color32(255, 248, 53, 255))
        {
            Instantiate(WireVer, new Vector3(x, FloorHeight(x, z), z), transform.rotation);
        }

        if (PixelColor == new Color32(255, 221, 125, 255))
        {
            Instantiate(WireL_DR, new Vector3(x, FloorHeight(x, z), z), transform.rotation);
        }

        if (PixelColor == new Color32(255, 193, 127, 255))
        {
            Instantiate(WireL_DL, new Vector3(x, FloorHeight(x, z), z), transform.rotation);
        }

        if (PixelColor == new Color32(200, 221, 125, 255))
        {
            Instantiate(WireL_UR, new Vector3(x, FloorHeight(x, z), z), transform.rotation);
        }

        if (PixelColor == new Color32(168, 186, 106, 255))
        {
            Instantiate(WireL_UL, new Vector3(x, FloorHeight(x, z), z), transform.rotation);
        }

        if (PixelColor == new Color32(255, 212, 53, 255))
        {
            Instantiate(WireT_LUD, new Vector3(x, FloorHeight(x, z), z), transform.rotation);
        }

        if (PixelColor == new Color32(255, 140, 53, 255))
        {
            Instantiate(WireT_RUD, new Vector3(x, FloorHeight(x, z), z), transform.rotation);
        }

        //Laser
        if (PixelColor == new Color32(255, 107, 0, 255))
        {
            Instantiate(LaserG_Up, new Vector3(x, FloorHeight(x, z), z), transform.rotation);
        }

        if (PixelColor == new Color32(212, 89, 0, 255))
        {
            Instantiate(LaserG_Right, new Vector3(x, FloorHeight(x, z), z), transform.rotation);
        }

        if (PixelColor == new Color32(130, 54, 0, 255))
        {
            Instantiate(LaserG_Down, new Vector3(x, FloorHeight(x, z), z), transform.rotation);
        }

        if (PixelColor == new Color32(56, 23, 0, 255))
        {
            Instantiate(LaserG_Left, new Vector3(x, FloorHeight(x, z), z), transform.rotation);
        }

        if (PixelColor == new Color32(194, 164, 0, 255))
        {
            Instantiate(LaserReflector, new Vector3(x, FloorHeight(x, z), z), transform.rotation);
        }

        if (PixelColor == new Color32(255, 183, 103, 255))
        {
            Instantiate(LaserReceptor, new Vector3(x, FloorHeight(x, z), z), transform.rotation);
        }


        //Flasks
        if (PixelColor == new Color32(105, 0, 143, 255))
        {
            Instantiate(Floor, new Vector3(x, FloorHeight(x, z), z), transform.rotation);
            Instantiate(Toxic, new Vector3(x, FloorHeight(x, z) + 0.5f, z), transform.rotation);
        }

        if (PixelColor == new Color32(0, 107, 255, 255))
        {
            Instantiate(Floor, new Vector3(x, FloorHeight(x, z), z), transform.rotation);
            Instantiate(Flask1, new Vector3(x, FloorHeight(x, z) + 1f, z), transform.rotation);
        }

        if (PixelColor == new Color32(255, 0, 81, 255))
        {
            Instantiate(Floor, new Vector3(x, FloorHeight(x, z), z), transform.rotation);
            Instantiate(Flask2, new Vector3(x, FloorHeight(x, z) + 1f, z), transform.rotation);
        }

        if (PixelColor == new Color32(188, 0, 255, 255))
        {
            Instantiate(Floor, new Vector3(x, FloorHeight(x, z), z), transform.rotation);
            Instantiate(Flask3, new Vector3(x, FloorHeight(x, z) + 1f, z), transform.rotation);
        }

        if (PixelColor == new Color32(188, 255, 0, 255))
        {
            Instantiate(Floor, new Vector3(x, FloorHeight(x, z), z), transform.rotation);
            Instantiate(Flask4, new Vector3(x, FloorHeight(x, z) + 1f, z), transform.rotation);
        }

        
        if (PixelMap2[LevelToOpen] != null)
        {
            Color PixelColor2 = PixelMap2[LevelToOpen].GetPixel(x, z);

            //Floor
            if (PixelColor.a < 0.1f)
            {
                if (FloorHeight(x, z) > 0)
                {
                    Instantiate(Floor, new Vector3(x, FloorHeight(x, z), z), transform.rotation);
                }
            }

            //Character
            if (PixelColor == new Color32(53, 255, 0, 255))
            {
                Instantiate(Floor, new Vector3(x, FloorHeight(x, z), z), transform.rotation);
                Instantiate(Character, new Vector3(x, FloorHeight(x, z) + 1.0f, z), transform.rotation);
            }

            //Box
            if (PixelColor == new Color32(255, 243, 0, 255))
            {
                Instantiate(Floor, new Vector3(x, FloorHeight(x, z), z), transform.rotation);
                Instantiate(Box, new Vector3(x, FloorHeight(x, z) + 1.0f, z), transform.rotation);
            }

            if (PixelColor == new Color32(242, 0, 255, 255))
            {
                Instantiate(Floor, new Vector3(x, FloorHeight(x, z), z), transform.rotation);
                Instantiate(EnergyBox, new Vector3(x, FloorHeight(x, z) + 1.0f, z), transform.rotation);
            }

            //Target
            if (PixelColor == Color.red)
            {
                Instantiate(Target, new Vector3(x, FloorHeight(x, z), z), transform.rotation);
            }

            //Elevadores
            if (PixelColor == new Color32(0, 0, 255, 255))
            {
                Instantiate(ElevatorXFloor, new Vector3(x, FloorHeight(x, z), z), transform.rotation);
            }

            if (PixelColor == new Color32(138, 0, 0, 255))
            {
                Instantiate(ElevatorYFloor, new Vector3(x, FloorHeight(x, z), z), transform.rotation);
            }


            //Wire
            if (PixelColor == new Color32(255, 248, 125, 255))
            {
                Instantiate(WireHor, new Vector3(x, FloorHeight(x, z), z), transform.rotation);
            }

            if (PixelColor == new Color32(255, 248, 53, 255))
            {
                Instantiate(WireVer, new Vector3(x, FloorHeight(x, z), z), transform.rotation);
            }

            if (PixelColor == new Color32(255, 221, 125, 255))
            {
                Instantiate(WireL_DR, new Vector3(x, FloorHeight(x, z), z), transform.rotation);
            }

            if (PixelColor == new Color32(255, 193, 127, 255))
            {
                Instantiate(WireL_DL, new Vector3(x, FloorHeight(x, z), z), transform.rotation);
            }

            if (PixelColor == new Color32(200, 221, 125, 255))
            {
                Instantiate(WireL_UR, new Vector3(x, FloorHeight(x, z), z), transform.rotation);
            }

            if (PixelColor == new Color32(168, 186, 106, 255))
            {
                Instantiate(WireL_UL, new Vector3(x, FloorHeight(x, z), z), transform.rotation);
            }

            if (PixelColor == new Color32(255, 212, 53, 255))
            {
                Instantiate(WireT_LUD, new Vector3(x, FloorHeight(x, z), z), transform.rotation);
            }

            if (PixelColor == new Color32(255, 140, 53, 255))
            {
                Instantiate(WireT_RUD, new Vector3(x, FloorHeight(x, z), z), transform.rotation);
            }

            //Laser
            if (PixelColor == new Color32(255, 107, 0, 255))
            {
                Instantiate(LaserG_Up, new Vector3(x, FloorHeight(x, z), z), transform.rotation);
            }

            if (PixelColor == new Color32(212, 89, 0, 255))
            {
                Instantiate(LaserG_Right, new Vector3(x, FloorHeight(x, z), z), transform.rotation);
            }

            if (PixelColor == new Color32(130, 54, 0, 255))
            {
                Instantiate(LaserG_Down, new Vector3(x, FloorHeight(x, z), z), transform.rotation);
            }

            if (PixelColor == new Color32(56, 23, 0, 255))
            {
                Instantiate(LaserG_Left, new Vector3(x, FloorHeight(x, z), z), transform.rotation);
            }

            if (PixelColor == new Color32(194, 164, 0, 255))
            {
                Instantiate(LaserReflector, new Vector3(x, FloorHeight(x, z), z), transform.rotation);
            }

            if (PixelColor == new Color32(255, 183, 103, 255))
            {
                Instantiate(LaserReceptor, new Vector3(x, FloorHeight(x, z), z), transform.rotation);
            }


            //Flasks
            if (PixelColor == new Color32(105, 0, 143, 255))
            {
                Instantiate(Floor, new Vector3(x, FloorHeight(x, z), z), transform.rotation);
                Instantiate(Toxic, new Vector3(x, FloorHeight(x, z) + 0.5f, z), transform.rotation);
            }

            if (PixelColor == new Color32(0, 107, 255, 255))
            {
                Instantiate(Floor, new Vector3(x, FloorHeight(x, z), z), transform.rotation);
                Instantiate(Flask1, new Vector3(x, FloorHeight(x, z) + 1f, z), transform.rotation);
            }

            if (PixelColor == new Color32(255, 0, 81, 255))
            {
                Instantiate(Floor, new Vector3(x, FloorHeight(x, z), z), transform.rotation);
                Instantiate(Flask2, new Vector3(x, FloorHeight(x, z) + 1f, z), transform.rotation);
            }

            if (PixelColor == new Color32(188, 0, 255, 255))
            {
                Instantiate(Floor, new Vector3(x, FloorHeight(x, z), z), transform.rotation);
                Instantiate(Flask3, new Vector3(x, FloorHeight(x, z) + 1f, z), transform.rotation);
            }

            if (PixelColor == new Color32(188, 255, 0, 255))
            {
                Instantiate(Floor, new Vector3(x, FloorHeight(x, z), z), transform.rotation);
                Instantiate(Flask4, new Vector3(x, FloorHeight(x, z) + 1f, z), transform.rotation);
            }
        }

        if (PixelMap3[LevelToOpen] != null)
        {
            Color PixelColor2 = PixelMap2[LevelToOpen].GetPixel(x, z);

            //Floor
            if (PixelColor.a < 0.1f)
            {
                if (FloorHeight(x, z) > 0)
                {
                    Instantiate(Floor, new Vector3(x, FloorHeight(x, z), z), transform.rotation);
                }
            }

            //Character
            if (PixelColor == new Color32(53, 255, 0, 255))
            {
                Instantiate(Floor, new Vector3(x, FloorHeight(x, z), z), transform.rotation);
                Instantiate(Character, new Vector3(x, FloorHeight(x, z) + 1.0f, z), transform.rotation);
            }

            //Box
            if (PixelColor == new Color32(255, 243, 0, 255))
            {
                Instantiate(Floor, new Vector3(x, FloorHeight(x, z), z), transform.rotation);
                Instantiate(Box, new Vector3(x, FloorHeight(x, z) + 1.0f, z), transform.rotation);
            }

            if (PixelColor == new Color32(242, 0, 255, 255))
            {
                Instantiate(Floor, new Vector3(x, FloorHeight(x, z), z), transform.rotation);
                Instantiate(EnergyBox, new Vector3(x, FloorHeight(x, z) + 1.0f, z), transform.rotation);
            }

            //Target
            if (PixelColor == Color.red)
            {
                Instantiate(Target, new Vector3(x, FloorHeight(x, z), z), transform.rotation);
            }

            //Elevadores
            if (PixelColor == new Color32(0, 0, 255, 255))
            {
                Instantiate(ElevatorXFloor, new Vector3(x, FloorHeight(x, z), z), transform.rotation);
            }

            if (PixelColor == new Color32(138, 0, 0, 255))
            {
                Instantiate(ElevatorYFloor, new Vector3(x, FloorHeight(x, z), z), transform.rotation);
            }


            //Wire
            if (PixelColor == new Color32(255, 248, 125, 255))
            {
                Instantiate(WireHor, new Vector3(x, FloorHeight(x, z), z), transform.rotation);
            }

            if (PixelColor == new Color32(255, 248, 53, 255))
            {
                Instantiate(WireVer, new Vector3(x, FloorHeight(x, z), z), transform.rotation);
            }

            if (PixelColor == new Color32(255, 221, 125, 255))
            {
                Instantiate(WireL_DR, new Vector3(x, FloorHeight(x, z), z), transform.rotation);
            }

            if (PixelColor == new Color32(255, 193, 127, 255))
            {
                Instantiate(WireL_DL, new Vector3(x, FloorHeight(x, z), z), transform.rotation);
            }

            if (PixelColor == new Color32(200, 221, 125, 255))
            {
                Instantiate(WireL_UR, new Vector3(x, FloorHeight(x, z), z), transform.rotation);
            }

            if (PixelColor == new Color32(168, 186, 106, 255))
            {
                Instantiate(WireL_UL, new Vector3(x, FloorHeight(x, z), z), transform.rotation);
            }

            if (PixelColor == new Color32(255, 212, 53, 255))
            {
                Instantiate(WireT_LUD, new Vector3(x, FloorHeight(x, z), z), transform.rotation);
            }

            if (PixelColor == new Color32(255, 140, 53, 255))
            {
                Instantiate(WireT_RUD, new Vector3(x, FloorHeight(x, z), z), transform.rotation);
            }

            //Laser
            if (PixelColor == new Color32(255, 107, 0, 255))
            {
                Instantiate(LaserG_Up, new Vector3(x, FloorHeight(x, z), z), transform.rotation);
            }

            if (PixelColor == new Color32(212, 89, 0, 255))
            {
                Instantiate(LaserG_Right, new Vector3(x, FloorHeight(x, z), z), transform.rotation);
            }

            if (PixelColor == new Color32(130, 54, 0, 255))
            {
                Instantiate(LaserG_Down, new Vector3(x, FloorHeight(x, z), z), transform.rotation);
            }

            if (PixelColor == new Color32(56, 23, 0, 255))
            {
                Instantiate(LaserG_Left, new Vector3(x, FloorHeight(x, z), z), transform.rotation);
            }

            if (PixelColor == new Color32(194, 164, 0, 255))
            {
                Instantiate(LaserReflector, new Vector3(x, FloorHeight(x, z), z), transform.rotation);
            }

            if (PixelColor == new Color32(255, 183, 103, 255))
            {
                Instantiate(LaserReceptor, new Vector3(x, FloorHeight(x, z), z), transform.rotation);
            }


            //Flasks
            if (PixelColor == new Color32(105, 0, 143, 255))
            {
                Instantiate(Floor, new Vector3(x, FloorHeight(x, z), z), transform.rotation);
                Instantiate(Toxic, new Vector3(x, FloorHeight(x, z) + 0.5f, z), transform.rotation);
            }

            if (PixelColor == new Color32(0, 107, 255, 255))
            {
                Instantiate(Floor, new Vector3(x, FloorHeight(x, z), z), transform.rotation);
                Instantiate(Flask1, new Vector3(x, FloorHeight(x, z) + 1f, z), transform.rotation);
            }

            if (PixelColor == new Color32(255, 0, 81, 255))
            {
                Instantiate(Floor, new Vector3(x, FloorHeight(x, z), z), transform.rotation);
                Instantiate(Flask2, new Vector3(x, FloorHeight(x, z) + 1f, z), transform.rotation);
            }

            if (PixelColor == new Color32(188, 0, 255, 255))
            {
                Instantiate(Floor, new Vector3(x, FloorHeight(x, z), z), transform.rotation);
                Instantiate(Flask3, new Vector3(x, FloorHeight(x, z) + 1f, z), transform.rotation);
            }

            if (PixelColor == new Color32(188, 255, 0, 255))
            {
                Instantiate(Floor, new Vector3(x, FloorHeight(x, z), z), transform.rotation);
                Instantiate(Flask4, new Vector3(x, FloorHeight(x, z) + 1f, z), transform.rotation);
            }
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
