using er03;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class manageKeyItems : MonoBehaviour
{
    public bool setKeyActive;

    public GameObject redKey;
    public GameObject blueKey;
    public GameObject greenKey;

    IngredientList _ingredientList;

    // Start is called before the first frame update
    void Start()
    {
        _ingredientList = GameObject.Find("er03_Cauldron").GetComponent<IngredientList>();

    }

    // Update is called once per frame
    void Update()
    {
        KeyControl();

        KeyDestroyerManager();

    }

    private void KeyDestroyerManager()
    {
        bool areEqual = _ingredientList.ingredients.SequenceEqual(_ingredientList.correctIngredients);

        if (areEqual)
        {
            Destroy(redKey);
            Destroy(blueKey);
            Destroy(greenKey);
        }
    }

    private void KeyControl()
    {
        if(blueKey != null && greenKey != null && redKey != null )
        {
            if (!_ingredientList.ingredients.Contains("Blue"))
            {
                blueKey.SetActive(false);
            }
            else { blueKey.SetActive(true); }
            if (!_ingredientList.ingredients.Contains("Green"))
            {
                greenKey.SetActive(false);
            }
            else { greenKey.SetActive(true); }
            if (!_ingredientList.ingredients.Contains("Red"))
            {
                redKey.SetActive(false);
            }
            else { redKey.SetActive(true); }
        }

    }
}
