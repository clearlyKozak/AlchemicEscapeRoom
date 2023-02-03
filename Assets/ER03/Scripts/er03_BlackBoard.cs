using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using er03;

namespace er03
{
    public class er03_BlackBoard : MonoBehaviour
    {
        public Texture2D texture;
        public Vector2 textureSize = new Vector2(2048, 2048);

        void Start()
        {
            var r = GetComponent<Renderer>();
            texture = new Texture2D((int)textureSize.x, (int)textureSize.y);
            //texture = Texture2D.blackTexture;
            texture.SetPixel((int)textureSize.x, (int)textureSize.y, Color.black);
            r.material.mainTexture = texture;
        }

    }
}