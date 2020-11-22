using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class MoveAi : MonoBehaviour
{
     NavMeshAgent agent;
    [SerializeField]

    Transform _destination;

    NavMeshAgent _navMeshAgent;

    public Text text;

    private Ray ray;
    private RaycastHit hit;

    private GameObject target;
    private GameObject Item;

    private bool       mouseState;

    private int        count;
    private float      distance;

    private enum arrow
    {
        Up,
        Down,
        Left,
        Right
    }

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        _navMeshAgent = this.GetComponent<NavMeshAgent>();

        InvokeRepeating("ThreeSec", 1, 3);
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.RandomSpawning)
        {
            MouseClick();
        }

        if (mouseState && distance <= 5)
        {
            Item = target;
            GameManager.IsHold = true;
        }

        CarryItem(); //물체(아이템) 상호작용
        ShowText(); //텍스트 띄우기

    }
    private void ThreeSec()
    {
        if (GameManager.RandomSpawning)
        {
            if (_destination != null)
            {
                Vector3 targetVector = _destination.transform.position;
                _navMeshAgent.SetDestination(targetVector);
            }

            if(Vector3.Distance(this.transform.position, _destination.transform.position) <= 5)
            {
                GameManager.RandomSpawning = false;
            }
        }

        if (GameManager.IsHold)
        {
            count = Random.Range(1, 10);

            if (count == 1 || count == 2)
            {
                GameManager.IsHold = false;
            }
        }
    }

    private void MouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
            }

            target = GetClickedObject();

            if (target.name == "Rock")
            {
                distance = Vector3.Distance(this.transform.position, target.transform.position);

                mouseState = true;
            }
            else if (target.name == "Seaweed")
            {
                distance = Vector3.Distance(this.transform.position, target.transform.position);

                mouseState = true;
            }
        }
        else if (Input.GetMouseButtonUp(0) && mouseState == true)
        {
            mouseState = false;
        }
    }


    private GameObject GetClickedObject()
    {
        GameObject target = null;

        if (Physics.Raycast(ray.origin, ray.direction * 10, out hit))
        {
            target = hit.collider.gameObject;
        }

        return target;
    }
   
    private void CarryItem()
    {
        if(GameManager.IsHold)
        {
            //물체가 금붕어를 따라다니도록 설정
            if (hit.point.x < this.transform.position.x)
            {
                Item.transform.position = new Vector3(this.transform.position.x - 3, this.transform.position.y, this.transform.position.z);
            }
            else if (hit.point.x > this.transform.position.x)
            {
                Item.transform.position = new Vector3(this.transform.position.x + 3, this.transform.position.y, this.transform.position.z);
            }

            //물체를 들었을 때 상호작용
            if(Input.GetKeyDown(KeyCode.E))
            {
                if(Item.name == "Seaweed")
                {
                    Destroy(Item);
                    GameManager.Instance.M1count++;
                }

                GameManager.IsHold = false;
            }
        }
    }

    private void ShowText()
    {
        if (GameManager.IsHold)
        {
            text.gameObject.SetActive(true);

            if (Item.name == "Seaweed") //해초
            {
                text.text = "해초 먹기" + "<color=orange>" + "(E)" + "</color>";
            }
            else
            {
                text.text = "아이템 놓기" + "<color=orange>" + "(E)" + "</color>";
            }
        }
        else
        {
            text.gameObject.SetActive(false);
        }
    }
}
