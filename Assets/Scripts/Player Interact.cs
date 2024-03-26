using System;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private Camera _cam;
    [SerializeField] private LayerMask _mask;

    private PlayerUI _playerUI;
    private InputManager _inputManager;
    private PlayerController _playerController;

    [SerializeField] private float _distance = 3f;

    void Start()
    {
        _cam = GetComponent<PlayerLook>()._camera;
        _playerUI = GetComponent<PlayerUI>();
        _inputManager = GetComponent<InputManager>();
        _playerController = GetComponent<PlayerController>();
    }

    void Update()
    {
        _playerUI.UpdatePromptText(String.Empty);
        Ray _ray = new Ray(_cam.transform.position, _cam.transform.forward);
        Debug.DrawRay(_ray.origin, _ray.direction * _distance);
        RaycastHit hitInfo;

        if (Physics.Raycast(_ray, out hitInfo, _distance, _mask))
        {
            if (hitInfo.collider.GetComponent<Interactable>() != null)
            {
                Interactable _interactable = hitInfo.collider.GetComponent<Interactable>();
                _playerUI.UpdatePromptText(_interactable._prompt);
                if (_inputManager._movement.Interact.triggered)
                {
                    _interactable.Interact(); 
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BlueFlag"))
        {
            PlayerUI.Instance.UpdatePromptText("Press F to carry the Blue Flag");
        }
        else if (other.CompareTag("RedFlag"))
        {
            PlayerUI.Instance.UpdatePromptText("Press F to return the Red Flag");
        }
        else if (other.CompareTag("Enemy") && GameManager.Instance._redFlagPickedUp)
        {
            Debug.Log("Collided with enemy carrying red flag");

            //Unparent the blue flag from the player
            GameManager.Instance._redFlag.transform.parent = null;

            //Reset _blueFlagPickedUp to false
            GameManager.Instance._redFlagPickedUp = false;

            //Move the blue flag back to its original position
            GameManager.Instance._redFlag.transform.position = GameManager.Instance._redFlagBasePosition.position;
            GameManager.Instance._redFlag.transform.rotation = GameManager.Instance._redFlagBasePosition.rotation;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("BlueFlag") && Input.GetKeyDown(KeyCode.F))
        {
            _playerController.CarryBlueFlag();
            other.GetComponent<FlagInteract>().Interact(); 
            PlayerUI.Instance.UpdatePromptText("");
        }
        else if (other.CompareTag("RedFlag") && Input.GetKeyDown(KeyCode.F))
        {
            other.GetComponent<FlagInteract>().Interact(); 
            PlayerUI.Instance.UpdatePromptText("");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PlayerUI.Instance.UpdatePromptText("");
    }
}
