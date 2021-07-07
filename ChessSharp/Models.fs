module Models

type Position = { x : int; y : int }
type Color = Black | White
type Occupied = Empty | Ally | Enemy
type PieceType = 
    | King
    | Queen
    | Rook
    | Knight
    | Bishop
    | Pawn

type Piece = {pieceType : PieceType; color : Color; position : Position}
type Board = Option<Piece> [,]