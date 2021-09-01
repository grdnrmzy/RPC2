using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(PlayerMotor))]
    public class PlayerController : MonoBehaviour
    {
        [HideInInspector]
        public LayerMask movementMask;

        [SerializeField]
        Camera cam;
        PlayerMotor motor;

        void Start()
        {
            cam = Camera.main;
            motor = GetComponent<PlayerMotor>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButton(0))
            {
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 100, movementMask))
                {
                    motor.MoveToPoint(hit.point);

                }
            }

            if (Input.GetMouseButtonDown(1))
            {
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 100))
                {
                    motor.MoveToPoint(hit.point);
                }


            }

        }

    }
}