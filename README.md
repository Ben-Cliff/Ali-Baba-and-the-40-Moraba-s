# Morabaraba  
*A brief look at the baord representation*
**VIEW IN RAW**

This current version of Morabaraba has some intresting takes to the data representation. 
Initially the initial data representation seems adequate. This would be a 7 by 7 grid of X-Y values with the X
represented by 1-7 and the Y's by A-G.

    1   2    3   4   5    6  7
A    **----------**----------**
     | `.        |         ,' | 
B    |   **------**------**   | 
     |   | `.     |    ,' |   | 
C    |   |   **--**--**   |   | 
     |   |   |        |   |   | 
D    **--**--**      **--**-- **
     |   |   |        |   |   | 
E    |   |   **--**--**   |   | 
     |   | ,'    |     `. |   | 
F    |   **------**------**   | 
     | ,'         |        `. | 
G    **----------**----------**

Noticable is the that the places where one can place/move/fly their cows is not uniformerly distributed.
Eg E1; E2; E6 & E7 do not exist.
As a result this format is can be considered a bit periphrastic.


Looking into the way the board is structured, one can reformat the board by deviding its definitions into its four sides:

side 1:                       side 2:                       Side 3 ... etc etc
A1----------A4----------A7    A7----------D7----------G7
   `.        |         ,'       `.        |         ,'
     B2------B4------B6           B6------D6------F6 
      `.     |    ,'               `.     |    ,'     
        C3--C4--C5                   C5--D5--E5
        
        

By looking at the board this way, one can make a recatangle 2D array with 8 X 3 dimensions.
Note: points like A7 are not repeated in this array
This 2d structure does not store invalid points compared to the previous structure. 



On looking at this, a further simplification of the data can occur being that all the points may be stored on a
1D array.
This owes to the idea that there lies 24 points.
There are 8 points on each circumference (from outter to innner). 
The X value ranges from 0-7 indicating where on the circumference the point lies.
The Y value is either 0, 8 or 16. Indicating which circumference the point is on.
X+Y = element on list. There will be 24 elements on the list, all sums of X and Y.

The inspiration of this arose from the 8 X 3 array.

This allows the three square to exist on a one dimensional array.


An illustration would be as follows:



 1----------02----------03 
 | `.        |         ,' | 
 |   09------10------11   | 
 |   | `.     |    ,' |   | 
 |   |   17--18--19   |   | 
 |   |   |        |   |   | 
 08--16--24      20--12--04 
 |   |   |        |   |   | 
 |   |   23--22--21   |   | 
 |   | ,'    |     `. |   | 
 |   15------14------13   | 
 | ,'         |        `. | 
 07----------06----------05 


Each number indicates the position on the list. There is a pattern of clockwise incrementation.

In this version, being incomplete, the placing and moving states are defined.

However, since the "shooting" aspect of the mills has not been implemented, only placing is workable. Once all the pieces have been placed, the game cannot continue further owing to there being no space to allow this.


**Of Interest to Player**

After each succesful move, an int list is printed.
it will look something like this:

[0 ;0 ;0 ; 0 ;0 ;0 ;0 ;0 ;0 ;0 ;0 ;0 ;0 ;0 ;0 ;0 ;0 ;0 ;0 ;0 ;0 ;0 ;0]

0 represents free points on the board

Each of the 24 elements represents a point on the grid.
If player one has played, a 1 will be played 
EG
        A1

[1 ;0 ;0 ; 0 ;0 ;0 ;0 ;0 ;0 ;0 ;0 ;0 ;0 ;0 ;0 ;0 ;0 ;0 ;0 ;0 ;0 ;0 ;0]

If player two has played, a two will be played

EG 
        D3
        
[1 ;0 ;0 ; 0 ;0 ;0 ;0 ;0 ;0 ;0 ;0 ;0 ;0 ;0 ;0 ;0 ;0 ;0 ;0 ;0 ;0 ;0 ;2]


As one can see, A1 is the 1st and D3 the 24th element on the above printed board.
This is simillarly represented on the integer list.

## Releases (options):
v1.0: ""./Morabaraba v1.0.rar" in repo
v0.75: ""./Morabaraba v0.75.rar"" in repo