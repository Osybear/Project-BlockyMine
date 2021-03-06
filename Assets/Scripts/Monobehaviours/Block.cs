﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

	public BlockHandler blockHandler;
	public BlockData blockData;
	public int depth;
	public float hitPoints;
	public float expPoints;
	
	public void setBlock() {
		GetComponent<Renderer>().material = blockData.material;
		name = blockData.name;
		this.hitPoints = blockData.hitPoints;
		this.expPoints = blockData.expValue;
	}

	public void DamageBlock(float amount){
		if(hitPoints - amount <= 0)
			blockHandler.onBlockDeath(this);
		else
			hitPoints = hitPoints - amount;
	}
}
