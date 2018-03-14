module Morabaraba

open DataSets
open Drawing

//The following functions are the functions passed into UPDATEBOARD. They determine how the board will be updated.
let insertcow (player: int) (coord: int) (board : int list) (index : int) (valu: int): int = //this function is passed into updateboard (custom List.mapi), operates on each element
    match (index = coord )with
    | true -> player //coord ofType in. (x+y)
    |_ -> valu

let removecow (player: int) (coord: int) (board : int list) (index : int) (valu: int): int = 
    match (index = coord) with
    | true -> 0 //coord ofType in. (x+y)
    |_ -> valu

//UPDATEBOARD below
let updateboard (f : int -> int -> int list -> int -> int -> int) (player: int) (coord: int) (board : int list) : int list =      //Similar to mapi, altered for game purposes
    let rec innerF (lst : int list) (inc : int) (len : int) (ans : int list) : int list =    // inc used as length at first call, and list incerment in recursion 
        match (inc - len) with
        |0 -> ans
        |a -> innerF lst (inc+1) len (List.append ans [(f player coord lst inc lst.[(inc)])])
    innerF board 0 board.Length []

//---------------------------------------------------------------------------------
//MAIN FUNCTIONS: PLACE, MOVE FLY

let inAct =
    fun (board : int list) (coords : int list) (expect : int) -> // 0 empty, 1 player, 2 other player
        board.[coords.[0] + coords.[1]]=expect

let rec interaction (player :int ) (board : int list) (sentence : string) (expect : int) : string =                                                                  //takes in input and checks if it exsists (see isoccupied for position che)
    //System.Console.Clear()
    drawBoard board
    let msg = sprintf "%A's  turn: type the Y value of the cell that you want to %s. 
             Only accepts letters A ; B ; C ; D; E ; F ; G" (getIcon player) sentence // sentence = "play into" for place state as appose to " mve from " alterative for move state
    consColorWrite msg
    let i = (System.Convert.ToString (System.Console.ReadKey true).KeyChar).ToUpper()
    match i with 
    | "A" | "B" | "C" | "D" | "E" | "F" | "G" ->
        let d = string i                                //saves Y value into d
        printfn "Type the X coordinate of the position that you want to %s.
                 EG '3' (Between 1 - 7) " sentence // sentence = "play into" for place state as appose to " mve from " alterative for move state
        let n = (System.Console.ReadKey true).KeyChar
        match n with
        | '1' | '2' | '3' | '4' | '5' | '6' | '7' ->
            match  mrbaToFlat (d + string(n))    with
            | [9;9]-> 
                //check move
                interaction player board sentence expect    //potential change for options, watch this space failinput                                                            
            | _ -> match inAct board (mrbaToFlat (d + string(n))) expect   with
                   |true -> (d + string(n) )             //final return case -> Saves value into n and smushes input into string EG "A1'
                   |_ ->
                        writeError "Sorry, you couldnt choose that point. Please try again!"
                        interaction player board sentence expect
        | _ -> interaction player board sentence expect//invalid input, try again silly hooman      
    | _ -> interaction player board sentence expect//invalid input, try again silly hooman 
   
let otherplayer (player : int) : int = //Returns the opposite player
    match player with 
    |1 -> 2
    |_ -> 1

let shoot (point : int) (victim: int) (board: int list) (player): int list =   //Still need to make sure the victim cow is not in a mill
    System.Console.WriteLine("asdf")
    System.Threading.Thread.Sleep(2000)

    let point = interaction player board "to shoot" (otherplayer player)
    updateboard removecow victim ((mrbaToFlat point).[0] + (mrbaToFlat point).[1]) board

let rec place (mills : Mill list) (player : int) (cowsleft : int) (board : int list) (ismill : Mill list -> int list -> int list -> int -> bool) : int list=        //SKELETON //cowsleft should be 24 when first called
    match cowsleft with
    |0 -> board
    |_ ->                                                   
        let spot = interaction player board "play into" (0)                    //accepted input
        let spott = match (mrbaToFlat spot) with             //Testing if use input is valid
                    |[9;9] -> [9;9] ///TEMP. fail case goes here. MUST CHANGE $$$$$$$$$$$$$$$$$$$$$$$$
                    |_ -> mrbaToFlat spot



        let board = updateboard insertcow player (spott.[0] + spott.[1]) (*<- this is x+y. see ReadMe*) board

        let boarda =                                         //checks if cow is in a mill, shoots if it is
            match (ismill mills board (spott) player) with
            |true -> shoot (spott.[0] + spott.[1]) (otherplayer player) board player
            |false -> board 
            
        match player with 
        |1 -> place mills 2 (cowsleft-1) boarda ismill         //Go to Next Move
        |_ -> place mills 1 (cowsleft-1) boarda ismill
    
    //take coordinate of just placed piece from int list
// recursive innerf looks at mill list, compare singulare coordinate with mills 
//          --> checks specific mill(s) that would be involved in list
//              --> capture neccessary points from potential mill
//              --> Compare with current board stat
//              YAY / NAY *************************************************loading to be done

//  MOVE FUNCTION :: in progress version allows 20 moves, as cows cannit be shot yet. hence movesleft parameter
let rec move (movesleft : int) (mills : Mill list) (player : int) (board : int list) (ismill : Mill list -> int list -> int list -> int -> bool) : int list =        //SKELETON 
    
    let froms = interaction player board "move from" player//take in user input
    let movetos = interaction player board "move to" 0//take in user input
    let (from : int list) = mrbaToFlat froms
    let (moveto : int list) = mrbaToFlat movetos 
    (*let allgood = match oneaway from moveto with
                |true -> updateboard insertcow player moveto (updateboard removecow player from board)    
                //board is updated to remove cow. this result is passed into the next update which adds the cow to its new position.           
                |_ -> move*) 

    let oneaway (from: int list) (moveto : int list) : bool = //checks if move position is 1 away
        match (moveto.[0] = (from.[0] + 1)) || (moveto.[0] = (from.[0] - 1)) with //x value differs by 1        
        |true -> match (moveto.[1] = (from.[1] + 1)) || (moveto.[1] = (from.[1] - 1)) with //y value differs by 1 
                 |true -> true
                 |_ -> false
        |_ -> false
        
    let board = updateboard insertcow player (moveto.[0] + moveto.[1]) (updateboard removecow player (from.[0] + from.[1]) board)    



        //------------------------------------------------
        (*let board =                                         //checks if cow is in a mill, shoots if it is
            match (ismill mills board (moveto) player) with
            |true -> shoot (spott.[0] + spott.[1]) (otherplayer player) board
            |false -> board*)
    printf"%A \n"board
    match movesleft with
    |0 -> board
    |_ -> match player with 
          |1 -> move (movesleft-1) mills 2 (board) ismill 
          |_ -> move (movesleft-1) mills 1 (board) ismill
    
            




//LESSER FUNCTIONS. MILL CHECKS, SHOOTING

(*          list of each mill, board = board, spott = spot on board, player = playernum*)          
let ismill (mills : Mill list) (board : int list) (spott : int list) (player : int): bool =                    //function checks which possible mills a co-ord can be a part of, and if they are full (call to millfull)       
    // Ernest tried to fix the mill code
    //  - Note: the code from before might work, it seems a slight bug comes from "searching" for specific mills, will sort that tomorrow
    // This is a function checking if it is a "mill" of that players number
    let getMillValue =
        fun (m:Mill) ->
            (board.[m.PointA.x + m.PointA.y]=player)&&((board.[m.PointA.x + m.PointA.y]=board.[m.PointB.x + m.PointB.y])&&(board.[m.PointC.x + m.PointC.y]=board.[m.PointB.x + m.PointB.y])) // all 3 the same? all 3 the player
    // This is a function that hunts through the mills for the point we are currently on
    //  - Note that this is where the bug is roughly - it currently only finds a mill from the first element in the mill points (PointA) if it is the first element
    let rec getTheMills = 
        fun (sspot : int list) (allThem : Mill list) (b : Mill list) ->
            match b with
            | [] -> allThem
            | head::tail ->
                match ((head.PointA.x=sspot.[0])&&(head.PointA.y=sspot.[1]))||((head.PointB.x=sspot.[0])&&(head.PointB.y=sspot.[1]))||((head.PointC.x=sspot.[0])&&(head.PointC.y=sspot.[1])) with
                | true -> getTheMills sspot (head::allThem) tail
                | false -> getTheMills sspot allThem tail
    // Slightly Random
    let checkEachOption =
        fun (m: Mill) (sppoott: int list) -> // sppoott is same as other ssssspppppooooooottttts
            let q = m.PointA.x+m.PointA.y=sppoott.[0]+sppoott.[1]
            let r = m.PointB.x+m.PointB.y=sppoott.[0]+sppoott.[1]
            let e = m.PointC.x+m.PointC.y=sppoott.[0]+sppoott.[1]
            let a = board.[m.PointA.x+m.PointA.y]
            let b = board.[m.PointB.x+m.PointB.y]
            let c = board.[m.PointC.x+m.PointC.y]
            let d = board.[sppoott.[0]+sppoott.[1]]
            let e = a=d
            let f = b=d
            let g = c=d
            match q,r,e with
            | true, false, false | false, true, false | false, false, true ->
                match e,f,g with
                | true, true, true -> true
                | _ -> false
            | _ -> false
    let chosenMills = getTheMills spott [] mills
    let rec eachChoice =
        fun (cm: Mill list) (spooot: int list) ->
            match cm with
            | [] -> false
            | head::tail ->
                match checkEachOption head spott with
                | true -> true
                | false -> eachChoice tail spott
    eachChoice chosenMills spott
        (*let millfull (mil : Mill) (player : int) (board : int list): bool = 
            match ( (board.[mil.PointA.x + mil.PointA.y] = player) && (board.[mil.PointB.x + mil.PointB.y] = player) && (board.[mil.PointB.x + mil.PointB.y] = player)) with
                |true -> true
                |_ -> false*) // done
        (*let xandy (mil : Mill) (abc : string) : int list =      //generates x and y list for specofied position in mill
            match abc with
            |"A" -> [mil.PointA.x ; mil.PointA.y]
            |"B" -> [mil.PointB.x ; mil.PointB.y]
            |"C" -> [mil.PointC.x ; mil.PointA.y]
            |_ -> [0;0]

        match inc with
        |20 -> false                    //applies to each mill in list. i.e 20 iterations
        |_  -> match ((xandy mills.[inc] "A" = spott) || (xandy mills.[inc] "B" = spott) || (xandy mills.[inc] "C" = spott) ) with      //comepares the spot [x;y] with          
               |true -> millfull mills.[inc] player board
               |_ -> innerF mills board spott (inc+1) player 
    innerF mills board spott 0 player*)
    //NOTE FACK: certain positions hold up to three mills, need to carry on recursion

let (placedboard : int list) = [0]
[<EntryPoint>]
let main argv = 
    move 20 mills 1 (place mills 1 24 flatboard ismill) ismill
    0 // return an integer exit code


