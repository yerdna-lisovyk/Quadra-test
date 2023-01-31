using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Qustion
{
    public int IDQuestion { get; set; }
    public string Description{ get; set; }
    public Texture2D Img { get; set; }
    public List<Variant> Variants { get; set; }
    
}
