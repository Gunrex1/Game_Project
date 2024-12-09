using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

  public float speed;

  [SerializeField]
  private Renderer bgRenderer;

  // Update is called once per frame
  void Update()
  {
      bgRenderer.material.mainTextureOffset += new Vector2( speed * Time.deltaTime,0);
  }
}
