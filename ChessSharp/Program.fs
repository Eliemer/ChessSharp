open Models
open Behaviours

let initBoard (board : Board) : Board =
    // White team
    // Pawns
    board.[1, *] <- [| for i=0 to 7 do Some {pieceType = Pawn; color = White; position = {x = 1; y = i}} |]
    
    // Rooks
    board.[0, 0] <- Some {pieceType = Rook; color = White; position = {x = 0; y = 0}}
    board.[0, 7] <- Some {pieceType = Rook; color = White; position = {x = 0; y = 7}}

    // Knights
    board.[0, 1] <- Some {pieceType = Knight; color = White; position = {x = 0; y = 1}}
    board.[0, 6] <- Some {pieceType = Knight; color = White; position = {x = 0; y = 6}}

    // Bishops

    board

[<EntryPoint>]
let main argv =
    let mutable board : Board = Array2D.init 8 8 (fun i j -> None) |> initBoard

    printfn "%A" board
    0