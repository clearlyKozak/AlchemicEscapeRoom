using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using er03;

namespace er03
{
    public class BlueStream : MonoBehaviour
    {
        [Header("Put in line renderer prefab")]
        private LineRenderer lineRenderer = null;
        private ParticleSystem splashParticle = null;

        IngredientList _ingredientList;


        private Coroutine pourRoutine = null;
        private Vector3 targetPosition = Vector3.zero;

        private void Awake()
        {
            //Setup and reference line renderer and splash particle
            lineRenderer = GetComponent<LineRenderer>();
            splashParticle = GetComponentInChildren<ParticleSystem>();
            _ingredientList = GameObject.Find("er03_Cauldron").GetComponent<IngredientList>();
        }

        private void Start()
        {
            //put line renderer in correct place
            MoveToPosition(0, transform.position); //start point of linerender
            MoveToPosition(1, transform.position); //end point of line renderer
        }

        public void Begin()
        {
            StartCoroutine(UpdateParticle());

            //store the coroutine for later
            pourRoutine = StartCoroutine(BeginPour());
        }

        private IEnumerator BeginPour()
        {
            //manage where stream hits and animate endpoint to ground

            while (gameObject.activeSelf)
            {
                //shoot raycast to ground to find the end point
                targetPosition = FindEndpoint();

                MoveToPosition(0, transform.position); //the start point of the line renderer remains where it is
                AnimateToPosition(1, targetPosition); //animate the end point to the spot we found earlier

                yield return null;
            }

        }

        public void End()
        {
            StopCoroutine(pourRoutine);
            pourRoutine = StartCoroutine(EndPour());
        }

        private IEnumerator EndPour()
        {
            while (!HasReachedPosition(0, targetPosition))
            {
                //animate both in case user stops pouring before line renderer
                //reached it's target position on the ground 
                AnimateToPosition(0, targetPosition);
                AnimateToPosition(1, targetPosition);

                yield return null;
            }

            Destroy(gameObject);
        }

        //raycast to find endpoint of line renderer
        private Vector3 FindEndpoint()
        {
            RaycastHit hit;
            Ray ray = new Ray(transform.position, Vector3.down);

            Physics.Raycast(ray, out hit, 2.0f);
            if (hit.collider.tag == "er03_Cauldron")
            {
                if (!_ingredientList.ingredients.Contains("Blue"))
                {
                    _ingredientList.ingredients.Add("Blue");
                    Debug.Log("Blue was Added");
                }
            }

            //determine if the raycast should end on ground collision
            //or depending on it's max length (of 2 in this case)
            Vector3 endPoint = hit.collider ? hit.point : ray.GetPoint(2.0f);

            return endPoint;
        }

        private void MoveToPosition(int index, Vector3 targetPosition)
        {
            lineRenderer.SetPosition(index, targetPosition);

        }

        public void AnimateToPosition(int index, Vector3 targetPosition)
        {
            Vector3 currentPoint = lineRenderer.GetPosition(index);
            Vector3 newPosition = Vector3.MoveTowards(currentPoint, targetPosition, Time.deltaTime * 1.75f);
            lineRenderer.SetPosition(index, newPosition);
        }

        private bool HasReachedPosition(int index, Vector3 targetPosition)
        {
            //check if line renderer has reached position it's animating towards
            Vector3 currentPosition = lineRenderer.GetPosition(index);
            return currentPosition == targetPosition;
        }

        private IEnumerator UpdateParticle()
        {
            //manage splash particles
            while (gameObject.activeSelf)
            {
                splashParticle.gameObject.transform.position = targetPosition;

                bool isHitting = HasReachedPosition(1, targetPosition);
                splashParticle.gameObject.SetActive(isHitting);
                yield return null;
            }

        }

    }
}