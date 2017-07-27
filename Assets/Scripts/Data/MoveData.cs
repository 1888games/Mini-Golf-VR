using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MoveData {



	public static void loadMoveData () {

		Move move;
		Vector2[] tiles = {new Vector2 (0, 0), new Vector2 (0, 0)};

		// x, y, z, r

		//tiles = new List<Vector2> ();


		// Start, Straight1, Hill1, Ramp1
		tiles [0] = new Vector2 (0, 0); tiles [1] = new Vector2 (0, 0);
		move = new Move (0, 1, 0, 0, tiles);
		PieceController.Instance.moves.Add (move);
		PieceController.Instance.moveNameMap.Add (move.moveString, move);

		// Curve1,2,3,Hill Curve1
		tiles [0] = new Vector2 (0, 0); tiles [1] = new Vector2 (1, 1);
		move = new Move (1, 2, 0, 90, tiles);
		PieceController.Instance.moves.Add (move);
		PieceController.Instance.moveNameMap.Add (move.moveString, move);

		// Curve 5,6,7 Hill Curve3
		tiles [0] = new Vector2 (-1, 0); tiles [1] = new Vector2 (0, 1);
		move = new Move (-1, 2, 0, -90, tiles);
		PieceController.Instance.moves.Add (move);
		PieceController.Instance.moveNameMap.Add (move.moveString, move);

		// curve4
		tiles [0] = new Vector2 (0, 0); tiles [1] = new Vector2 (2, 2);
		move = new Move (2, 3, 0, 90, tiles);
		PieceController.Instance.moves.Add (move);
		PieceController.Instance.moveNameMap.Add (move.moveString, move);

		// curve8
		tiles [0] = new Vector2 (-2, 0); tiles [1] = new Vector2 (0, 2);
		move = new Move (-2, 3, 0, -90, tiles);
		PieceController.Instance.moves.Add (move);
		PieceController.Instance.moveNameMap.Add (move.moveString, move);

		// straight2
		tiles [0] = new Vector2 (0, 0); tiles [1] = new Vector2 (0, 1);
		move = new Move (0, 2, 0, 0, tiles);
		PieceController.Instance.moves.Add (move);
		PieceController.Instance.moveNameMap.Add (move.moveString, move);

		// straight3
		tiles [0] = new Vector2 (0, 0); tiles [1] = new Vector2 (0, 2);
		move = new Move (0, 3, 0, 0, tiles);
		PieceController.Instance.moves.Add (move);
		PieceController.Instance.moveNameMap.Add (move.moveString, move);

		// zigzag1,5
		tiles [0] = new Vector2 (0, 0); tiles [1] = new Vector2 (1, 2);
		move = new Move (1, 3, 0, 0, tiles);
		PieceController.Instance.moves.Add (move);
		PieceController.Instance.moveNameMap.Add (move.moveString, move);

		// zigzag2,6
		tiles [0] = new Vector2 (0, 0); tiles [1] = new Vector2 (2, 3);
		move = new Move (2, 4, 0, 0, tiles);
		PieceController.Instance.moves.Add (move);
		PieceController.Instance.moveNameMap.Add (move.moveString, move);

		// zigzag3,7
		tiles [0] = new Vector2 (-1, 0); tiles [1] = new Vector2 (0, 2);
		move = new Move (-1, 3, 0, 0, tiles);
		PieceController.Instance.moves.Add (move);
		PieceController.Instance.moveNameMap.Add (move.moveString, move);

		// zigzag4,8
		tiles [0] = new Vector2 (-2, 0); tiles [1] = new Vector2 (0, 3);
		move = new Move (-2, 4, 0, 0, tiles);
		PieceController.Instance.moves.Add (move);
		PieceController.Instance.moveNameMap.Add (move.moveString, move);

		// elevation1,3
		tiles [0] = new Vector2 (0, 0); tiles [1] = new Vector2 (0, 1);
		move = new Move (0, 2, 1, 0, tiles);
		PieceController.Instance.moves.Add (move);
		PieceController.Instance.moveNameMap.Add (move.moveString, move);

		// elevation2
		tiles [0] = new Vector2 (0, 0); tiles [1] = new Vector2 (0, 3);
		move = new Move (0, 4, 1, 0, tiles);
		PieceController.Instance.moves.Add (move);
		PieceController.Instance.moveNameMap.Add (move.moveString, move);

		// elevation4
		tiles [0] = new Vector2 (0, 0); tiles [1] = new Vector2 (0, 2);
		move = new Move (0, 3, 1, 0, tiles);
		PieceController.Instance.moves.Add (move);
		PieceController.Instance.moveNameMap.Add (move.moveString, move);




//		tiles [0] = new Vector2 (-1, 0); tiles [1] = new Vector2 (0, 0);
//		move = new Move (-1, 1, 0, -90, tiles);
//		PieceController.Instance.moves.Add (move);
//		PieceController.Instance.moveNameMap.Add (move.moveString, move);
//
//
//		tiles [0] = new Vector2 (0, 0); tiles [1] = new Vector2 (1, 0);
//		move = new Move (1, 1, 0, 90, tiles);
//		PieceController.Instance.moves.Add (move);
//		PieceController.Instance.moveNameMap.Add (move.moveString, move);
//
//
//

//


		tiles [0] = new Vector2 (-3, -2); tiles [1] = new Vector2 (-1, -1);
		move = new Move (-2, -2, -1, 90, tiles);
		PieceController.Instance.moves.Add (move);
		PieceController.Instance.moveNameMap.Add (move.moveString, move);

		tiles [0] = new Vector2 (1, -2); tiles [1] = new Vector2 (3, -1);
		move = new Move (2, -2, -1, -90, tiles);
		PieceController.Instance.moves.Add (move);
		PieceController.Instance.moveNameMap.Add (move.moveString, move);
//
//		tiles [0] = new Vector2 (-3, -1); tiles [1] = new Vector2 (2, 0);
//		move = new Move (-3, -1, -1, 180, tiles);
//		PieceController.Instance.moves.Add (move);
//		PieceController.Instance.moveNameMap.Add (move.moveString, move);
//
//		tiles [0] = new Vector2 (0, -1); tiles [1] = new Vector2 (3, 0);
//		move = new Move (3, -1, -1, 180, tiles);
//		PieceController.Instance.moves.Add (move);
//		PieceController.Instance.moveNameMap.Add (move.moveString, move);
//

		// hill6
		tiles [0] = new Vector2 (0, 0); tiles [1] = new Vector2 (0, 4);
		move = new Move (0, 5, 0, 0, tiles);
		PieceController.Instance.moves.Add (move);
		PieceController.Instance.moveNameMap.Add (move.moveString, move);

	}


}
