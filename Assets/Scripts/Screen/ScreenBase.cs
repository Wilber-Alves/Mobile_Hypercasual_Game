using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using NaughtyAttributes;
using DG.Tweening;  

namespace Screens
{
    public enum ScreenType
    {
        Main_Menu_Panel,
        Facebook_Panel,
        Rankling_Panel,
        Shop_Panel,
        Settings_Panel,
        Profile_Panel,
        Win_Panel,
        Failed_Panel,
        Ribbon_1,
        Ribbon_2,
        Ribbon_3,
        Ribbon_4,
        Ribbon_5,
        Ribbon_6,
        Ribbon_7,
        Ribbon_8,
        Facebook_Button,
        Settings_Button,
        Mission_Button,
        Profile_Button,
        Inventory_Button,
        Shop_Button
    }

    public class ScreenBase : MonoBehaviour
    {

        public ScreenType screenType;

        public List<Transform> listOfObjects;


        public bool startHided = false;


        [Header("Animation")]
        public float delayBetweenObjects = 0.1f;
        public float animationDuration = 0.5f;  

        private void Start()
        {
            if (startHided)
            {
                HideObjects();
            }
        }


        [Button]
        protected virtual void Show()
        {
            ShowObjects();
            Debug.Log("Show");
        
        }

        [Button]
        protected virtual void Hide()
        {
            HideObjects();
            Debug.Log("Hide");

        }

        private void HideObjects()
        { 
        
        listOfObjects.ForEach(x => x.gameObject.SetActive(false)); // hide all objects in the list

        }

        private void ShowObjects()
        {

            for(int i = 0; i < listOfObjects.Count; i++)
            {
                var obj = listOfObjects[i];

                obj.gameObject.SetActive(true); // show the object
                obj.DOScale(0, animationDuration).From().SetDelay(i * delayBetweenObjects); // animate the scale from 0 to 1 with
                                                                                            // a delay based on the index

            }

        }

        private void ForceShowObjects()
        {
           
            listOfObjects.ForEach(x => x.gameObject.SetActive(true)); // show all objects in the list

        }

    }
}
