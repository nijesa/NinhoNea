using UnityEngine;

public class SliderMovement : MonoBehaviour
{
    [SerializeField] Transform RightLimit;
    [SerializeField] Transform LeftLimit;
    [SerializeField] float speed = 2f;

    Transform tran;
    Transform target;

    void Start()
    {
        tran = GetComponent<Transform>();
        target = RightLimit;
    }

    void Update()
    {
        if (RightLimit == null || LeftLimit == null)
        {
            return;
        }

        tran.position = Vector3.MoveTowards(tran.position, target.position, speed * Time.deltaTime);

        if (Vector3.Distance(tran.position, target.position) < 0.01f)
        {
            target = target == RightLimit ? LeftLimit : RightLimit;
        }
    }
}
