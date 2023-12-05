using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinBox : MonoBehaviour
{
	private DungeonMaster dm;
	private void Awake()
	{
		dm = GameObject.Find("Dungeon Master").GetComponent<DungeonMaster>();
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == LayerMask.NameToLayer("Player")) dm.WinGame();
	}
}
