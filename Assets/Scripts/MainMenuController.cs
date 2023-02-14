using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
   [SerializeField] private GameObject _mainMenu;

   [SerializeField] private GameObject _levelSelect;

   public void loadLevelSelect()
   {
        _mainMenu.SetActive(false);
        _levelSelect.SetActive(true);
   }

   public void loadMainMenu()
   {
         _mainMenu.SetActive(true);
         _levelSelect.SetActive(false);
   }

}
