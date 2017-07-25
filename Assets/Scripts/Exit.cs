using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum direction {North, East, South, West}

public class Exit  {

	public direction exitDirection;
	public Piece parentPiece;

	public int leftRightOffset;
	public int forwardBackOffset;
	public int upDownOffset;




	public Exit (direction dir, Piece piece, int lr = 0, int fb = 0, int ud =0 ) {

		this.exitDirection = dir;
		this.parentPiece = piece;
		this.leftRightOffset = lr;
		this.forwardBackOffset = fb;
		this.upDownOffset = ud;


	}


}
