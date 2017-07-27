using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PieceData {


	public static void addMove(Piece proto, string move) {

		//Debug.Log ("LOOK FOR: " + move);

		if (PieceController.Instance.moveNameMap.ContainsKey(move)) {
			proto.moves.Add (PieceController.Instance.moveNameMap[move]);
			return;
		}
			
		//Debug.Log(move + " not found");

		

	}

	public static void loadPieceData () {

		Piece proto;

		//                    NAME,      X, Y, DF, FQ, XOFF, 2SPLIT, 3SPLIT

		proto = new Piece ("Start", 1, 5);
		PieceController.Instance.piecePrototypes.Add (proto.name, proto);
		//addMove (proto, "LR 0 FB 1 UD 0 RO 0");

		proto = new Piece ("Straight_01",1, 5);
		PieceController.Instance.piecePrototypes.Add (proto.name, proto);
		addMove (proto, "LR 0 FB 1 UD 0 RO 0");

		proto = new Piece ("Hill_01", 3, 2);
		PieceController.Instance.piecePrototypes.Add (proto.name, proto);
		addMove (proto, "LR 0 FB 1 UD 0 RO 0");

		proto = new Piece ("Ramp_01",1, 1);
		PieceController.Instance.piecePrototypes.Add (proto.name, proto);
		addMove (proto, "LR 0 FB 1 UD 0 RO 0");

		proto = new Piece ("Curve_01", 4, 3);
		PieceController.Instance.piecePrototypes.Add (proto.name, proto);
		addMove (proto, "LR 1 FB 2 UD 0 RO 90");

		proto = new Piece ("Curve_05", 4, 3);
		PieceController.Instance.piecePrototypes.Add (proto.name, proto);
		addMove (proto, "LR -1 FB 2 UD 0 RO -90");

		proto = new Piece ("Curve_02", 3, 3);
		PieceController.Instance.piecePrototypes.Add (proto.name, proto);
		addMove (proto, "LR 1 FB 2 UD 0 RO 90");

		proto = new Piece ("Curve_03", 2, 3);
		PieceController.Instance.piecePrototypes.Add (proto.name, proto);
		addMove (proto, "LR 1 FB 2 UD 0 RO 90");

		proto = new Piece ("Curve_04", 2, 3);
		PieceController.Instance.piecePrototypes.Add (proto.name, proto);
		addMove (proto, "LR 2 FB 3 UD 0 RO 90");

		proto = new Piece ("Curve_06", 3, 3);
		PieceController.Instance.piecePrototypes.Add (proto.name, proto);
		addMove (proto, "LR -1 FB 2 UD 0 RO -90");

		proto = new Piece ("Curve_07", 2, 3);
		PieceController.Instance.piecePrototypes.Add (proto.name, proto);
		addMove (proto, "LR -1 FB 2 UD 0 RO -90");

		proto = new Piece ("Curve_08", 2, 3);
		PieceController.Instance.piecePrototypes.Add (proto.name, proto);
		addMove (proto, "LR -2 FB 3 UD 0 RO -90");

		proto = new Piece ("HillCurve_01", 3, 2);
		PieceController.Instance.piecePrototypes.Add (proto.name, proto);
		addMove (proto, "LR 1 FB 2 UD 0 RO 90");

		proto = new Piece ("HillCurve_03", 3, 2);
		PieceController.Instance.piecePrototypes.Add (proto.name, proto);
		addMove (proto, "LR -1 FB 2 UD 0 RO -90");




		proto = new Piece ("Straight_02", 1, 4);
		PieceController.Instance.piecePrototypes.Add (proto.name, proto);
		addMove (proto, "LR 0 FB 2 UD 0 RO 0");

		proto = new Piece ("Straight_03",1, 3);
		PieceController.Instance.piecePrototypes.Add (proto.name, proto);
		addMove (proto, "LR 0 FB 3 UD 0 RO 0");

		proto = new Piece ("Zigzag_01", 2, 2);
		PieceController.Instance.piecePrototypes.Add (proto.name, proto);
		addMove (proto, "LR 1 FB 3 UD 0 RO 0");

		proto = new Piece ("Zigzag_02", 3, 2);
		PieceController.Instance.piecePrototypes.Add (proto.name, proto);
		addMove (proto, "LR 2 FB 4 UD 0 RO 0");

		proto = new Piece ("Zigzag_03",2, 2);
		PieceController.Instance.piecePrototypes.Add (proto.name, proto);
		addMove (proto, "LR -1 FB 3 UD 0 RO 0");

		proto = new Piece ("Zigzag_04", 3, 2);
		PieceController.Instance.piecePrototypes.Add (proto.name, proto);
		addMove (proto, "LR -2 FB 4 UD 0 RO 0");

		proto = new Piece ("Zigzag_05", 2, 2);
		PieceController.Instance.piecePrototypes.Add (proto.name, proto);
		addMove (proto, "LR 1 FB 3 UD 0 RO 0");

		proto = new Piece ("Zigzag_06", 2, 2);
		PieceController.Instance.piecePrototypes.Add (proto.name, proto);
		addMove (proto, "LR -1 FB 3 UD 0 RO 0");

		proto = new Piece ("Zigzag_07",2, 2);
		PieceController.Instance.piecePrototypes.Add (proto.name, proto);
		addMove (proto, "LR 2 FB 4 UD 0 RO 0");

		proto = new Piece ("Zigzag_08", 2, 2);
		PieceController.Instance.piecePrototypes.Add (proto.name, proto);
		addMove (proto, "LR -2 FB 4 UD 0 RO 0");
//


	


		proto = new Piece ("Hill_02",3, 2);
		PieceController.Instance.piecePrototypes.Add (proto.name, proto);
		addMove (proto, "LR 0 FB 2 UD 0 RO 0");

		proto = new Piece ("Hill_03", 3, 2);
		PieceController.Instance.piecePrototypes.Add (proto.name, proto);
		addMove (proto, "LR 0 FB 3 UD 0 RO 0");

		proto = new Piece ("Hill_04",3, 2);
		PieceController.Instance.piecePrototypes.Add (proto.name, proto);
		addMove (proto, "LR 0 FB 2 UD 0 RO 0");

		proto = new Piece ("Hill_05", 3, 2);
		PieceController.Instance.piecePrototypes.Add (proto.name, proto);
		addMove (proto, "LR 0 FB 3 UD 0 RO 0");

		proto = new Piece ("Hill_06", 3, 2);
		PieceController.Instance.piecePrototypes.Add (proto.name, proto);
		addMove (proto, "LR 0 FB 5 UD 0 RO 0");


		proto = new Piece ("HillCurve_02", 3, 2);
		PieceController.Instance.piecePrototypes.Add (proto.name, proto);
		addMove (proto, "LR 2 FB 3 UD 0 RO 90");


		proto = new Piece ("HillCurve_04", 3, 2);
		PieceController.Instance.piecePrototypes.Add (proto.name, proto);
		addMove (proto, "LR -2 FB 3 UD 0 RO -90");


		proto = new Piece ("Elevation_01", 5, 1);
		PieceController.Instance.piecePrototypes.Add (proto.name, proto);
		addMove (proto, "LR 0 FB 2 UD 1 RO 0");

		proto = new Piece ("Elevation_02", 5, 1);
		PieceController.Instance.piecePrototypes.Add (proto.name, proto);
		addMove (proto, "LR 0 FB 4 UD 1 RO 0");

		proto = new Piece ("Elevation_03", 4, 1);
		PieceController.Instance.piecePrototypes.Add (proto.name, proto);
		addMove (proto, "LR 0 FB 2 UD 1 RO 0");

		proto = new Piece ("Elevation_04", 3, 1);
		PieceController.Instance.piecePrototypes.Add (proto.name, proto);
		addMove (proto, "LR 0 FB 3 UD 1 RO 0");

		proto = new Piece ("ElevationCurve_01",3, 1);
		PieceController.Instance.piecePrototypes.Add (proto.name, proto);
		addMove (proto, "LR -2 FB -2 UD -1 RO 90");

		proto = new Piece ("ElevationCurve_02", 3, 1);
		PieceController.Instance.piecePrototypes.Add (proto.name, proto);
		addMove (proto, "LR 2 FB -2 UD -1 RO -90");
//
//
//		proto = new Piece ("ElevationCurve_03", 3, 1);
//		PieceController.Instance.piecePrototypes.Add (proto.name, proto);
//		addMove (proto, "LR -3 FB 0 UD -1 RO 180");
//
//		proto = new Piece ("ElevationCurve_04", 3, 1);
//		PieceController.Instance.piecePrototypes.Add (proto.name, proto);
//		addMove (proto, "LR 3 FB 0 UD -1 RO 180");
//

//
//		proto = new Piece ("Ramp_02", 2, 1);
//		PieceController.Instance.piecePrototypes.Add (proto.name, proto);
//		addMove (proto, "LR 0 FB 2 UD 0 RO 0");
//
//		proto = new Piece ("Ramp_03", 3, 1);
//		PieceController.Instance.piecePrototypes.Add (proto.name, proto);
//		addMove (proto, "LR 0 FB 3 UD 0 RO 0");

			

	}



}
