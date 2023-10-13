using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CharactersSelection : MonoBehaviour
{
    
    [SerializeField] private InputAction characterSelectArrows;

    private GameObject[] characterList;

    private int index = 0;

    private void OnEnable()
    {
        characterSelectArrows.Enable();

    }

    private void OnDisable()
    {
        characterSelectArrows.Disable();
    }

    private void Start()
    {
        index = PlayerPrefs.GetInt("CharacterSelected");
        // Create an array
        characterList = new GameObject[transform.childCount];

        // Fill the array with our models
        for(int i = 0; i < transform.childCount; i++)
        {
            characterList[i] = transform.GetChild(i).gameObject;
        }

        // Toggle off their renderer
        foreach(GameObject go in characterList)
        {
            go.SetActive(false);
        }

        // We toggle on the first index
        if (characterList[index])
        {
            characterList[index].SetActive(true);
        }
    }

    private void Update()
    {
        //bool isLeftKey = characterSelectArrows.ReadValue<Vector2>();

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ToggleLeft();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            ToggleRight();
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            PlayerPrefs.SetInt("CharacterSelected", index);
            SceneManager.LoadScene("PlayScene");
        }
    }

    public void ToggleLeft()
    {

        // Toggle off the current model
        characterList[index].SetActive(false);
        index--;
        if(index < 0)
        {
            index = characterList.Length - 1;
        }
        characterList[index].SetActive(true);
    }

    public void ToggleRight()
    {

        // Toggle off the current model
        characterList[index].SetActive(false);
        index++;
        if (index == characterList.Length)
        {
            index = 0;
        }
        characterList[index].SetActive(true);
    }
}
