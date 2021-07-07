module Behaviours

open Models

let getPositionOccupant (pos : Position) (piece : Piece) (board : Board) : Occupied =
    match board.[pos.x, pos.y] with
        | None -> Empty
        | Some piece' -> if piece.color = piece'.color then Ally else Enemy

let getPositionOccupant' (pos : Position) (color : Color) (board : Board) : Occupied =
    match board.[pos.x, pos.y] with
        | None -> Empty
        | Some piece -> if piece.color = color then Ally else Enemy

let isWithinBoard (piece : Piece) : bool =
    let x = piece.position.x
    let y = piece.position.y 

    x >= 0 && x < 8 && y >= 0 && y < 8

let isWithinBoard' (pos : Position) : bool =
    pos.x >= 0 && pos.y >= 0 && pos.x < 8 && pos.y < 8

let canMoveTo (color : Color) (board : Board) (pos : Position) : bool =
    match getPositionOccupant' pos color board with
        | Ally -> false
        | _ -> true

let generateAllMoves (piece : Piece) : seq<Position> =
    match piece.pieceType with
        | King  -> 
            let (x, y) = (piece.position.x , piece.position.y)
            seq { for row in -1 .. 1 do
                    for col in -1 .. 1 do
                       { x = x + row; y = y + col }}

        | Queen -> Seq.empty 
        | Rook -> Seq.empty 
        | Knight -> Seq.empty
        | Bishop -> Seq.empty
        | Pawn -> Seq.empty

let generateMoves (piece: Piece) (board : Board) : seq<Position> =
    generateAllMoves piece
    |> Seq.filter isWithinBoard'
    |> Seq.filter (canMoveTo piece.color board)

let movePiece (piece : Piece) (pos : Position) (board : Board) : Board =
    board.[piece.position.x, piece.position.y] <- None
    board.[pos.x, pos.y] <- Some piece
    board