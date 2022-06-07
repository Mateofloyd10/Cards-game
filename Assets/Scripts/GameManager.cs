using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kalkatos.DottedArrow;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static int numerGlobal = 0;
    public static bool globalColisionAttack = true;
    public static bool globalColisionDefense = true;
    public static string globalName;
    public static ParticleSystem[] particles = new ParticleSystem[2];

    public GameObject Hero;
    public GameObject Enemy;
    public GameObject Card;
    public Transform InstantiatePoint;

    [SerializeField] private Arrow arrow;
 

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        Instantiate(Hero);
        Instantiate(Enemy);

        particles[0] = GameObject.Find("Explosion").GetComponent<ParticleSystem>();
        particles[1] = GameObject.Find("DefenseParticles").GetComponent<ParticleSystem>();
        for (int i = 0; i < 5; i++)
        {
            GameObject go = Instantiate(Card, InstantiatePoint.transform);
            switch (i)
            {
                case 0:
                    go.GetComponent<RectTransform>().localPosition = new Vector3(-600, -324, 0);
                    break;
                case 1:
                    go.GetComponent<RectTransform>().localPosition = new Vector3(-300, -324, 0);
                    break;
                case 2:
                    go.GetComponent<RectTransform>().localPosition = new Vector3(0, -324, 0);
                    break;
                case 3:
                    go.GetComponent<RectTransform>().localPosition = new Vector3(300, -324, 0);
                    break;
                case 4:
                    go.GetComponent<RectTransform>().localPosition = new Vector3(600, -324, 0);
                    break;
            }
        
        }
        
    }

    public void BeginAttack(MouseOver card)
    {
        arrow.SetupAndActivate(card.transform);
    }

    public void EndAttack() 
    {
        arrow.Deactivate();
    }
}
