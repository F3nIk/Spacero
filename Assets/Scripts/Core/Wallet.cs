using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public struct Wallet 
{
    private int particles;
    public int Particles => particles;

    public void ChangeParticles(int value)
    {
        particles += value;
	}
    
}
