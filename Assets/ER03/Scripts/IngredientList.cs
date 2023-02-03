using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using er03;
using System.Linq;

namespace er03
{
    public class IngredientList : MonoBehaviour
    {
        public List<string> ingredients = new List<string>();
        public List<string> correctIngredients = new List<string>() { "Red", "Green", "Blue" };

        [SerializeField] GameObject keyObj;

        bool debugged;

        private void Awake()
        {
            //correctIngredients.Add("Blue");
            //correctIngredients.Add("Red");
            //correctIngredients.Add("Green");
            foreach (var x in correctIngredients)
            {
                Debug.Log("Correct items: " + x.ToString());
            }


        }


        private void Update()
        {

            if (ingredients.Count >= 3)
            {
                CheckList();
                if(debugged==false)
                {
                    Debug.Log("Cheching lists");
                }
            }
        }


        private void CheckList()
        {
            //bool listsAreEqual;

            bool areEqual = ingredients.SequenceEqual(correctIngredients);

            //if(ingredients.Contains("Red"))
            //{
            //    chiaveRossa.SetActive(true);
            //    Debug.Log("<color=red> red key part Active </color>");
            //}

            //if(ingredients.Contains("Blue"))
            //{
            //    chiaveBlu.SetActive(true);
            //    Debug.Log("<color=red> Blue key part active </color>");
            //}

            //if(ingredients.Contains("Green"))
            //{
            //    chiaveVerde.SetActive(true);
            //    Debug.Log("<color=red> Green key part active </color>");

            //}

            if (areEqual)
            {
                Debug.Log("Lists are equal");
                debugged=true;
                //Spawn key
                keyObj.SetActive(true);
            }
            else
            {
                debugged = false;
                Debug.Log("Lists are NOT equal");
                ingredients.Clear();
                debugged = true;
            }


            //for (var i = 0; i < correctIngredients.Count; i++)
            //{

            //    if (ingredients != correctIngredients)
            //    {

            //        listsAreEqual = false;
            //        Debug.Log("Lists are NOT equal " + listsAreEqual);
            //        //reset player list
            //        ingredients.Clear();
            //        ingredients.Add(" ");
            //        debugged = false;

            //    }
            //    else
            //    {
            //        listsAreEqual = true;
            //        Debug.Log("Lists are equal " + listsAreEqual);
            //        //spawn key
            //        keyObj.SetActive(true);
            //        debugged= true;
            //    }
            //}

        }



    }
}
