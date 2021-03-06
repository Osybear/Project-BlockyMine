﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class DisplayInventoryData : MonoBehaviour {

	public InventoryData inventory;
	public Transform parent;
	public Text moneyText;
	public GameObject blockTextPrefab;
	public List<BlockText> blockTextList;

	private void Start() {
		//add display items
		foreach(BlockCount blockCount in inventory.blockCountList){
			GameObject clone = Instantiate(blockTextPrefab, parent);
			blockTextList.Add(new BlockText(blockCount, clone.GetComponent<Text>()));
		}
		UpdateMoneyText();
	}

	public void UpdateBlockCount(){
		int index = blockTextList.IndexOf(new BlockText(new BlockCount(inventory.tempBlockData)));
		if(index != -1){
			BlockText blockText = blockTextList[index];

			if(blockText.blockCount.count == 0){
				Destroy(blockText.blockText.gameObject);
				blockTextList.Remove(blockText);
			}else
				blockText.UpdateText();	
		}else{
			GameObject clone = Instantiate(blockTextPrefab, parent);
			blockTextList.Add(new BlockText(inventory.blockCountList[inventory.blockCountList.Count - 1], clone.GetComponent<Text>()));
		}
	}

	public void UpdateMoneyText(){
		moneyText.text = "$" + inventory.money.ToString("0.00");
	}
}

[Serializable]
public class BlockText : IEquatable<BlockText>{
	public BlockCount blockCount;
	public Text blockText;

	public BlockText(BlockCount blockCount, Text blockText){
		this.blockCount = blockCount;
		this.blockText = blockText;
		UpdateText();
	}

	public BlockText(BlockCount blockCount){
		this.blockCount = blockCount;	
	}

	public void UpdateText(){
		blockText.color = blockCount.blockData.material.color;
		blockText.text = blockCount.blockData.name + " " + blockCount.count;
	}

	public bool Equals(BlockText other)
    {
        if(other.blockCount.blockData == blockCount.blockData)
			return true;
		return false;
    }
}
