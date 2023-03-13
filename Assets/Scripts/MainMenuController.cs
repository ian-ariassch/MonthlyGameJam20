using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
   [SerializeField] private GameObject _mainMenu;

   [SerializeField] private GameObject _levelSelect;

   [SerializeField] private GameObject _howToPlay;

   public void loadLevelSelect()
   {
        _mainMenu.SetActive(false);

        _howToPlay.SetActive(false);

        _levelSelect.SetActive(true);
   }

   public void loadMainMenu()
   {
         _mainMenu.SetActive(true);

         _howToPlay.SetActive(false);

         _levelSelect.SetActive(false);
   }

   public void loadHowToPlay()
   {
         _mainMenu.SetActive(false);
   
         _howToPlay.SetActive(true);
   
         _levelSelect.SetActive(false);
   }

}
