using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathGenerator : MonoBehaviour
{
    private GameObject groundUnit;
    // Start is called before the first frame update
    void Start()
    {
        GenerateGridOfSize(20);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    List<List<GameObject>> lst2D_GroundUnits = new List<List<GameObject>>();
    private void GenerateGridOfSize(int n)
    {
        groundUnit = GameObject.CreatePrimitive(PrimitiveType.Cube);
        groundUnit.name = "GroundUnit";
        for (int i = 0; i < n; i++)
        {
            List<GameObject> lst_GroundUnits = new List<GameObject>();
            for (int j = 0; j < n; j++)
            {
                lst_GroundUnits.Add(Instantiate(groundUnit,transform));
                lst_GroundUnits[j].GetComponent<MeshRenderer>().materials[0].color = Color.blue;
                if(i == 3)
                {
                    lst_GroundUnits[j].GetComponent<MeshRenderer>().materials[0].color = Color.yellow;
                    //HSVToRGB(Random.Range(0, 361f), Random.Range(0, 1f), Random.Range(0, 1f));
                }
                lst_GroundUnits[j].transform.position = new Vector3(i, 0, j);
            }
            lst2D_GroundUnits.Add(lst_GroundUnits);
            lst_GroundUnits.Clear();
        }
        DestroyImmediate(groundUnit);
    }
}
