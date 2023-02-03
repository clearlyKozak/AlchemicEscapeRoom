using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using er03;

namespace er03
{
    public class er03_BlacboardMarker : MonoBehaviour
    {
        [SerializeField] private Transform _tip;
        [SerializeField] private int _penSize = 5;

        private Renderer _renderer;
        private Color[] _colors;
        private float _tipHeight;

        private RaycastHit _touch;

        private er03_BlackBoard _blackBoard;

        private Vector2 _touchPos;
        private Vector2 _lastTouchPos;

        private Quaternion _lastTouchRot;

        private bool _touchedLastFrame;

        void Start()
        {
            //get renderer, setup colors array and tip height

            _renderer = _tip.GetComponent<Renderer>();
            _colors = Enumerable.Repeat(_renderer.material.color, _penSize * _penSize).ToArray();
            _tipHeight = _tip.localScale.y;

        }


        void Update()
        {
            Draw();
        }

        private void Draw()
        {
            //Shoot raycast
            if (Physics.Raycast(_tip.position, transform.up, out _touch, _tipHeight))
            {
                if (_touch.transform.CompareTag("er03_BlackBoard")) //check if item is blackboard
                {
                    if (_blackBoard == null) //cache the blackboard
                    {
                        _blackBoard = _touch.transform.GetComponent<er03_BlackBoard>();
                    }

                    //get touch position from texture coordinates
                    _touchPos = new Vector2(_touch.textureCoord.x, _touch.textureCoord.y);

                    //convert texture position to pixel position 
                    var x = (int)(_touchPos.x * _blackBoard.textureSize.x - (_penSize / 2));
                    var y = (int)(_touchPos.y * _blackBoard.textureSize.y - (_penSize / 2));

                    //if we are outside the texture don't draw
                    if (y < 0 || y > _blackBoard.textureSize.y || x < 0 || x > _blackBoard.textureSize.x)
                    {
                        return;
                    }

                    if (_touchedLastFrame)
                    {
                        _blackBoard.texture.SetPixels(x, y, _penSize, _penSize, _colors);

                        for (float f = 0.01f; f < 1.00f; f += 0.01f) //color pixels
                        {
                            var lerpX = (int)Mathf.Lerp(_lastTouchPos.x, x, f);
                            var lerpY = (int)Mathf.Lerp(_lastTouchPos.y, y, f);
                            _blackBoard.texture.SetPixels(lerpX, lerpY, _penSize, _penSize, _colors);



                        }

                        transform.rotation = _lastTouchRot;
                        _blackBoard.texture.Apply();

                    }

                    //if we didn't touch the blackboard we don't color
                    _lastTouchPos = new Vector2(x, y);
                    _lastTouchRot = transform.rotation;
                    _touchedLastFrame = true;
                    return;

                }
            }

            _blackBoard = null;
            _touchedLastFrame = false;

        }

    }
}