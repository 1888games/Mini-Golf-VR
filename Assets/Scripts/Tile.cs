using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile  {


	public int x { get; protected set; }
	public int y { get; protected set; }
	public int z { get; protected set; }

	public Piece installedPiece;


	public Tile (int x, int y, int z) {

		this.x = x;
		this.y = y;
		this.z = z;


	}


}
