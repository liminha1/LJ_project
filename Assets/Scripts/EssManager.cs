using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EssManager : MonoBehaviour
{
    public GameObject Car;
    public GameObject Car_1;

    private int NumOfCar = 1;
    public Text CarNum;

    private const float width = 20f;
    public static List<Transform> CountCar;

    
    void Awake()
    {
        CountCar = new List<Transform>();
        CountCar.Add(Car.transform);
    }

    public void SetNumOfCar(float Num)
    {
        NumOfCar = (int)Num;
        CarNum.text = NumOfCar.ToString();
    }

    public void StartSimulation()
    {
        for (int i = 0; i < NumOfCar; i++)
        {
            MakeCar();
        }
    }
    
    private void MakeCar()
    {
        var posX = Random.Range(-width, width);
        var posY = Random.Range(-width, width);
            
        var carInstance= Instantiate(Car_1, new Vector3(posX, 1f, posY), Quaternion.identity);
        CountCar.Add(carInstance.transform);
    }
}
