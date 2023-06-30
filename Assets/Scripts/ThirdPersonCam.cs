using UnityEngine;
public class ThirdPersonCam : MonoBehaviour
{
    public Transform orientation;
    public Transform combatOrientation;
    public Transform player;
    public Transform playerObject;
    public float rotationSpeed;
    public GameObject basicCam;
    public GameObject combatCam;
    public GameObject cross;
    private PlayerController _playerController;
    private void Start()
    {
        _playerController = PlayerController.Instance;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if(Input.GetMouseButton(1))
        {
            cross.SetActive(true);
            combatCam.transform.position = basicCam.transform.position;
            basicCam.SetActive(false);
            combatCam.SetActive(true);
            var dirToCombatOrientation =  combatOrientation.position - new Vector3(transform.position.x, combatOrientation.position.y, transform.position.z);
            orientation.forward = dirToCombatOrientation.normalized;
            _playerController.SetState(CurrentState.Aiming);
            //playerObject.forward = dirToCombatOrientation.normalized;
            //playerObject.forward = Vector3.Slerp(playerObject.forward, inputDir.normalized, rotationSpeed * Time.deltaTime * rotationSpeed);
            
        }
        else
        {
            _playerController.SetState(CurrentState.Normal);
            basicCam.transform.position = combatCam.transform.position;
            cross.SetActive(false);
            basicCam.SetActive(true);
            combatCam.SetActive(false);
        }
        var viewDir = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
        orientation.forward = viewDir.normalized;

        var horizontalInput = Input.GetAxis("Horizontal");
        var verticalInput = Input.GetAxis("Vertical");
        var inputDir = orientation.forward * verticalInput + orientation.right * horizontalInput;
        if (inputDir.magnitude > 0.1f)
        {
            playerObject.forward = Vector3.Slerp(playerObject.forward, inputDir.normalized, rotationSpeed * Time.deltaTime * rotationSpeed);
        }
        

    }
}
