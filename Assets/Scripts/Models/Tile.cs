using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tile  {

	// this class represents a tile or 'block' in the 3D hole grid

	public int x { get; protected set; }
	public int y { get; protected set; }
	public int z { get; protected set; }		// the X,Y,Z position of the tile in the grid. (Z-UP)

	public Piece installedPiece;		// the piece installed in or owning this tile

	public Tile (int x, int y, int z) {

		this.x = x;
		this.y = y;
		this.z = z;	// copy positions passed from grid creation

	}


}
