using System;
using UnityEngine;

public class PrizeInfo
{
    public Sprite PrizeImage { get; private set; }

    public Action Action { get; private set; }

    public PrizeInfo(Sprite prizeImage, Action action)
    {
        PrizeImage = prizeImage;
        Action = action;
    }
}
