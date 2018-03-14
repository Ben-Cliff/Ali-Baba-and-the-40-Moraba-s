# The "Old Folder"

## Old downloads
.\morabHalfDone.zip - The Old Group Code

## Old code
From Program.fs
```fsharp
//take coordinate of just placed piece from int list
// recursive innerf looks at mill list, compare singulare coordinate with mills 
//          --> checks specific mill(s) that would be involved in list
//              --> capture neccessary points from potential mill
//              --> Compare with current board stat
//              YAY / NAY *************************************************loading to be done
```

From program.fs - in "rec move":
```fsharp
        (*match (moveto.[0] = (from.[0] + 1)) || (moveto.[0] = (from.[0] - 1)) with //x value differs by 1        
        |true -> match (moveto.[1] = (from.[1] + 1)) || (moveto.[1] = (from.[1] - 1)) with //y value differs by 1 
                 |true -> true
                 |_ -> false
        |_ -> false*)
	
    //let board = updateboard insertcow player (moveto.[0] + moveto.[1]) (updateboard removecow player (from.[0] + from.[1]) board)    
	
	    (*let board =                                         //checks if cow is in a mill, shoots if it is
        match (ismill mills board (moveto) player) with
	    |true -> shoot (spott.[0] + spott.[1]) (otherplayer player) board
        |false -> board*)
```

From program.fs - in "ismill":
```fsharp
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
```


